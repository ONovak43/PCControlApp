using ControlLibrary.Wrapper;
using System;
using System.Configuration;
using System.Management;
using System.Threading.Tasks;

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
        public bool IsStarting = false;

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
        public async void Start()
        {
            if (IsStarting || await IsRunning())
            {
                return;
            }

            await Network.WakeOnLan(MacAddress);
            IsStarting = true;
            StopStarting();
        }

        /// <summary>
        /// Vypne počítač.
        /// </summary>
        /// <returns>Vrátí true v případě, že byl signál k vypnutí počítače úspěšně odeslán.
        ///     Vrátí false pokud odeslání signálu selhalo.</returns>
        public bool Shutdown()
        {
            ConnectionOptions options = new ConnectionOptions
            {
                EnablePrivileges = true,
                Username = ConfigurationManager.AppSettings["userName"],
                Password = ConfigurationManager.AppSettings["userPassword"]
            };

            ManagementScope scope = new ManagementScope($"\\\\{ Hostname }\\root\\cimv2", options);

            try
            {
                scope.Connect();
            }
            catch (UnauthorizedAccessException) // Pokud jsou zadané chybné údaje (options)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            SelectQuery query = new SelectQuery("Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            foreach (ManagementObject os in searcher.Get())
            {
                // Získá parametry pro metodu.
                ManagementBaseObject inParams =
                    os.GetMethodParameters("Win32Shutdown");

                // Přidá vstupní parametry.
                inParams["Flags"] = 1;

                // Spustí metodu.
                os.InvokeMethod("Win32Shutdown", inParams, null);
            }

            return true;
        }
        
        /// <summary>
        /// Ověří, zda je počítač online.
        /// </summary>
        /// <returns>Vrátí true v případě, že je počítač online.  Vrátí false pokud je počítač offline.</returns>
        public async Task<bool> IsRunning()
        {
            return await Network.Ping(Hostname);
        }

        /// <summary>
        /// Metoda nastaví po 60 sekundách hodnotu property IsStarting na false. Instance třídy 
        ///     tedy bude uvažovat, že počítač již nastartoval.
        /// </summary>
        private async void StopStarting()
        {
            await Task.Delay(60000);
            IsStarting = false;
        }

    }
}
