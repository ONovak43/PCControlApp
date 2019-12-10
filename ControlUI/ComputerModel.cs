using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControlUI
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
            if (!IsMacAddress(macAddress))
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


        private bool IsMacAddress(string address) => Regex.IsMatch(address, "^((([a-fA-F0-9][a-fA-F0-9]+[-]){5}|" +
                "([a-fA-F0-9][a-fA-F0-9]+[:]){5})([a-fA-F0-9][a-fA-F0-9])$)|" +
                "(^([a-fA-F0-9][a-fA-F0-9][a-fA-F0-9][a-fA-F0-9]+[.]){2}" +
                "([a-fA-F0-9][a-fA-F0-9][a-fA-F0-9][a-fA-F0-9]))$");
    }
}
