using ControlLibrary.Service;
using ControlLibrary.Wrapper;
using System;
using System.Collections.Generic;
using System.Text;

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
