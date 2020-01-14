using ControlLibrary.Service;
using ControlLibrary.Wrapper;

namespace ControlLibrary.Factory
{
    /// <summary>
    /// Poskytuje metodu vracející instanci třídy pro ovládání počítačů.
    /// </summary>
    internal static class ComputerServiceFactory
    {
        /// <summary>
        /// Vrátí instanci třídy, která je využívána pro odesílání signálů do počítačů.
        /// </summary>
        /// <param name="hostname">Hostname počítače.</param>
        /// <param name="macAddress">MAC adresa počítače.</param>
        /// <returns>Instanci třídy implementující IComputerService.</returns>
        public static IComputerService GetComputerService(string hostname, MacAddress macAddress)
        {
            IComputerService computerService = new ComputerService(hostname, macAddress);
            return computerService;
        }
    }
}
