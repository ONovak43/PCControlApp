using System;
using System.Text.RegularExpressions;
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
        public string MacAddress { get; }

        public string ComputerName
        {
            get => $"{ Name }: { Domain }, { MacAddress }";
        }

        /// <summary>
        /// Value thats set on true for - - after computer starts.
        /// </summary>
        public bool IsStarting = false;

        public ComputerModel(string domain, string macAddress)
        {
            if (!macAddress.IsMacAddress())
                throw new ArgumentException(message: "Invalid argument", paramName: nameof(macAddress));

            Domain = domain;
            MacAddress = macAddress;
        }

        public async void Start()
        {
            if (!IsStarting)
            {
                await Network.WakeOnLan(MacAddress);
                IsStarting = true;
                StopStarting();
            }
        }

        private async void StopStarting()
        {
            await Task.Delay(30000);
            IsStarting = false;
        }

        public async Task<bool> IsRunning() => await Network.Ping(Domain);
    }
}
