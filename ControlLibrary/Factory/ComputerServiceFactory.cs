using ControlLibrary.Service;
using ControlLibrary.Wrapper;

namespace ControlLibrary.Factory
{
    public static class ComputerServiceFactory
    {
        public static IComputerService GetComputerService(string hostname, MacAddress macAddress)
        {
            IComputerService computerService = new ComputerService(hostname, macAddress);
            return computerService;
        }
    }
}
