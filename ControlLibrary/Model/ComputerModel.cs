using ControlLibrary.Service;
using ControlLibrary.Wrapper;
using System;
using System.Configuration;
using System.Management;
using System.Threading.Tasks;

namespace ControlLibrary
{
    /// <summary>
    /// Represents computer.
    /// </summary>
    public class ComputerModel
    {
        /// <summary>
        /// The unique identifier for the computer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the name for this particular computer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents the domain (host) for this particular computer.
        /// </summary>
        public string Domain { get; }

        /// <summary>
        /// Represents the MAC address for this particular computer.
        /// </summary>
        public MacAddress MacAddress { get; }

        /// <summary>
        /// Represents formatted computer's name, domain and mac address. It's used to display info about particular computer.
        /// </summary>
        public string ComputerName { get; }

        /// <summary>
        /// ComputerService to control particular computer.
        /// </summary>
        private readonly IComputerService ComputerService;

        /// <summary>
        ///  Initializes a new instance of the ControlLibrary.ComputerModel class representing 
        ///    the specified computer, with the specified options.
        /// </summary>
        /// <param name="computerService">Initialized ComputerService with domain and MAC address</param>
        /// <param name="name">Name of this particular computer</param>
        /// <param name="domain">Domain of this particular computer</param>
        /// <param name="macAddress">MAC address of this particular computer</param>
        public ComputerModel(IComputerService computerService, string name, string domain, MacAddress macAddress)
        {
            Name = name;
            ComputerService = computerService;
            Domain = domain;
            MacAddress = macAddress;
            ComputerName = $"{ Name }: { domain }, { macAddress }";
        }

        /// <summary>
        /// Start the specified computer. 
        /// </summary>
        public void Start()
        {
            ComputerService.Start();
        }

        /// <summary>
        /// Shutdown the specified computer.
        /// </summary>
        /// <returns>True if signal to shutdown computer was sent sucessfully. False if it failed.</returns>
        public bool Shutdown()
        {
            return ComputerService.Shutdown();
        }

        /// <summary>
        /// Check if computer is online.
        /// </summary>
        /// <returns>True if computer is online. False if it's not.</returns>
        public async Task<bool> IsRunning()
        {
            return await ComputerService.IsRunning();
        }
    }
}
