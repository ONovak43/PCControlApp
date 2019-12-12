using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControlLibrary
{
    public class ComputerModel
    {
        /// <summary>
        /// Represents the domain (host) for this particular computer.
        /// </summary>
        public string Domain { get; }

        /// <summary>
        /// Represents the MAC address for this particular computer.
        /// </summary>
        public string MacAddress { get; }

        /// <summary>
        /// Value thats set on true for - - after computer starts.
        /// </summary>
        public bool isStarting = false;

        public ComputerModel(string domain, string macAddress)
        {
            if (!macAddress.IsMacAddress())
                throw new ArgumentException(message: "Invalid argument", paramName: nameof(macAddress));

            Domain = domain;
            MacAddress = macAddress;
        }

        public async void Start()
        {
            if (!isStarting)
            {
                await Network.WakeOnLan(MacAddress);
                isStarting = true;
                StopStarting();
            }
        }

        private async void StopStarting()
        {
            await Task.Delay(30000);
            isStarting = false;
        }

        public async Task<bool> IsRunning() => await Network.Ping(Domain);
    }
}
