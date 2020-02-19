using ControlLibrary.Wrapper;
using System;
using System.Configuration;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlLibrary.Service
{
    /// <summary>
    /// Poskytuje metody pro odesílání signálů do konkrétního počítače.
    /// </summary>
    internal class ComputerService : IComputerService
    {
        /// <summary>
        /// Představuje hostname (adresu) konkrétního počítače.
        /// </summary>
        public string Hostname { get; }

        /// <summary>
        /// Představuje MAC adresu konrétního počítače.
        /// </summary>
        public MacAddress MacAddress { get; }

        /// <summary>
        /// Slouží k identikaci stavu počítače. Její hodnota je nastavena na true po dobu 60 sekund 
        ///    od startu počítače.
        /// </summary>
        private bool IsStarting = false;

        /// <summary>
        /// Slouží jako "cache" po dobu 30 s se stavem stanice
        /// </summary>
        private bool IsOnline = false;

        /// <summary>
        /// Obsahuje čas, kdy byl do IsOnline nastaven stav počítače
        /// </summary>
        private DateTime Cached = new DateTime(1970, 1, 1, 0, 0, 0);


        /// <summary>
        /// Inicializuje novou instanci třídy ControlLibrary.Service.ComputerModel reprezentující 
        ///     služby k ovládání počítače a získání informací o jeho stavu.
        /// </summary>
        /// <param name="hostname">Hostname konkrétního počítače.</param>
        /// <param name="macAddress">MAC adresa konkrétního počítače.</param>
        public ComputerService(string hostname, MacAddress macAddress)
        {
            Hostname = hostname;
            MacAddress = macAddress;
        }

        /// <summary>
        /// Spustí počítač.
        /// </summary>
        public async Task Start()
        {
            if (IsStarting || await IsRunning())
            {
                return;
            }

            await Network.WakeOnLan(MacAddress);
            IsStarting = true;
            IsOnline = true;
            await StopStarting();
        }

        /// <summary>
        /// Vypne počítač.
        /// </summary>
        /// <returns>Vrátí true v případě, že byl signál k vypnutí počítače úspěšně odeslán.
        ///     Vrátí false pokud odeslání signálu selhalo.</returns>
        public bool Shutdown()
        {            
            try
            {
                ManagementScope scope;
                ConnectionOptions options = new ConnectionOptions
                {
                    Impersonation = ImpersonationLevel.Impersonate,
                    EnablePrivileges = true
                };                

                if (Hostname.ToUpper() == Environment.MachineName.ToUpper()) //lokální stanice
                {
                    scope = new ManagementScope(@"\ROOT\CIMV2", options);
                }
                else //stanice na síti
                {
                    options.Username = ConfigurationManager.AppSettings["userName"];
                    options.Password = ConfigurationManager.AppSettings["userPassword"];
                    scope = new ManagementScope(@"\\" + Hostname + @"\ROOT\CIMV2", options);
                }

                scope.Connect();

                ObjectQuery objQuery = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");

                ManagementObjectSearcher objSearcher = new ManagementObjectSearcher(scope, objQuery);

                foreach (ManagementObject operatingSystem in objSearcher.Get())
                {
                    ManagementBaseObject outParams = operatingSystem.InvokeMethod("Shutdown", null, null);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            IsOnline = false;
            return true;
        }

        /// <summary>
        /// Ověří, zda je počítač online.
        /// </summary>
        /// <returns>Vrátí true v případě, že je počítač online.  Vrátí false pokud je počítač offline.</returns>
        public async Task<bool> IsRunning()
        {
            DateTime now = DateTime.Now;

            if((now - Cached).TotalSeconds < 10)
            {
                return IsOnline;
            }

            IsOnline = await Network.Ping(Hostname);
            Cached = DateTime.Now;
            return IsOnline;
        }

        /// <summary>
        /// Metoda nastaví po 60 sekundách hodnotu property IsStarting na false. Instance třídy 
        ///     tedy bude uvažovat, že počítač již nastartoval.
        /// </summary>
        private async Task StopStarting()
        {
            await Task.Delay(60000);
            IsStarting = false;
        }

    }
}
