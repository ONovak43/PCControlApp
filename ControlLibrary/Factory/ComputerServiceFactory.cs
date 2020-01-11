using ControlLibrary.Service;
using ControlLibrary.Wrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlLibrary.Factory
{
    public static class ComputerServiceFactory
    {
        public static IComputerService GetComputerService(string domain, MacAddress macAddress)
        {
            IComputerService computerService = new ComputerService(domain, macAddress);
            return computerService;
        }
    }
}
