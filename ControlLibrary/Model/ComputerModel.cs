using ControlLibrary.Factory;
using ControlLibrary.Service;
using ControlLibrary.Wrapper;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlLibrary
{
    /// <summary>
    /// Představuje počítač a poskytuje metody k jeho ovládání.
    /// </summary>
    public class ComputerModel
    {
        /// <summary>
        /// Unikátní identifikační kód počítače.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Představuje název konkrétního počítače.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Představuje hostname (adresu) konkrétního počítače.
        /// </summary>
        public string Hostname { get; }

        /// <summary>
        /// Představuje MAC adresu konrétního počítače.
        /// </summary>
        public MacAddress MacAddress { get; }

        /// <summary>
        /// Představuje zformátovaný název počítače, hostname a MAC adresu. Slouží k 
        ///     zobrazení dat konkrétního počítače.
        /// </summary>
        public string ComputerName { get; }

        /// <summary>
        /// ComputerService obsahuje metody k ovládání počítače
        /// </summary>
        private readonly IComputerService ComputerService;

        /// <summary>
        ///  Inicializuje novou instanci třídy ControlLibrary.ComputerModel reprezentující 
        ///    konkrétní počítač.
        /// </summary>
        /// <param name="name">Název počítače.</param>
        /// <param name="hostname">Hostname (adresa) počítače.</param>
        /// <param name="macAddress">MAC adresa počítače.</param>
        public ComputerModel(string name, string hostname, MacAddress macAddress)
        {
            Name = name;
            Hostname = hostname;
            MacAddress = macAddress;
            ComputerService = ComputerServiceFactory.GetComputerService(Hostname, MacAddress);
            ComputerName = $"{ Name }: { Hostname }, { MacAddress.Address }";
        }

        /// <summary>
        /// Zapne konkrétní počítač
        /// </summary>
        public void Start()
        {
            ComputerService.Start();
        }

        /// <summary>
        /// Vypne konkrétní počítač.
        /// </summary>
        /// <returns>Vrátí true v případě, že byl signál k vypnutí počítače úspěšně odeslán.
        ///     Vrátí false pokud odeslání signálu selhalo.</returns>
        public bool Shutdown()
        {
            MessageBox.Show("asd");
            return ComputerService.Shutdown();
        }

        /// <summary>
        /// Ověří, zda je počítač online.
        /// </summary>
        /// <returns>Vrátí true v případě, že je počítač online.  Vrátí false pokud je počítač offline.</returns>
        public async Task<bool> IsRunning()
        {
            return await ComputerService.IsRunning();
        }
    }
}
