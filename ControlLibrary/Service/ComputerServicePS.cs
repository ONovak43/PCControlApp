using ControlLibrary.Exceptions;
using ControlLibrary.Wrapper;
using System;
using System.Configuration;
using System.Management.Automation;
using System.Security;
using System.Threading.Tasks;
using System.Timers;

namespace ControlLibrary.Service
{
    /// <summary>
    /// Poskytuje metody pro odesílání signálů do konkrétního počítače.
    /// </summary>
    internal class ComputerServicePS : IComputerService
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
        /// Slouží k identikaci stavu počítače. Její hodnota je nastavena na true po dobu 60 sekund.
        ///    od startu počítače.
        /// </summary>
        private bool IsStarting = false;

        /// <summary>
        /// Slouží k identikaci stavu počítače. Její hodnota je nastavena na true po dobu 60 sekund (v této době neleze stanice znova vypnout).
        ///    od startu počítače.
        /// </summary>
        private bool IsShuttingDown = false;

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
        public ComputerServicePS(string hostname, MacAddress macAddress) =>        
            (Hostname, MacAddress) = (hostname, macAddress);
        

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
            Cache(true);
            await StopStarting();
        }

        /// <summary>
        /// Vypne počítač.
        /// </summary>
        /// <returns>Vrátí true.</returns>
        public void Shutdown()
        {
            if(IsShuttingDown)
            {
                throw new ComputerServiceException("Tato stanice se již vypíná. ");
            }

            SecureString securePwd = new SecureString();

            var pwd = ConfigurationManager.AppSettings["userPassword"]; // Tohle není bezpečné. 

            for (int x = 0; x < pwd.Length; x++)
            {
                securePwd.AppendChar(pwd[x]);
            }

            var cred = new PSCredential(ConfigurationManager.AppSettings["userName"], securePwd);
            using (PowerShell ps = PowerShell.Create())
            {
                ps.AddCommand("Stop-Computer")
                   .AddParameter("ComputerName", Hostname)
                   .AddParameter("Force")
                   .AddParameter("Credential", cred)
                   .AddParameter("AsJob")
                   .Invoke();
                ps.Dispose();
            }
            GC.Collect();
            Cache(false);

            IsShuttingDown = true;

            Timer aTimer = new Timer
            {
                Interval = 30000,
                Enabled = true
            };
            aTimer.Elapsed += (sender, args) =>
            {
                IsShuttingDown = false;
                aTimer.Dispose();
            };
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

            bool state = await Network.Ping(Hostname);
            Cache(state);            
            return IsOnline;
        }

        /// <summary>
        /// Metoda nastaví po 60 sekundách hodnotu property IsStarting na false. Instance třídy 
        ///     tedy bude uvažovat, že počítač již nastartoval.
        /// </summary>
        private async Task StopStarting()
        {
            await Task.Delay(20000);
            IsStarting = false;
        }

        private void Cache(bool state)
        {
            IsOnline = state;
            Cached = DateTime.Now;
        }

    }
}
