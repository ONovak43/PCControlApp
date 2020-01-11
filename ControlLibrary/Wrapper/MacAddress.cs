using System;
using System.Text.RegularExpressions;

namespace ControlLibrary.Wrapper
{
    public class MacAddress
    {
        public string Address { get; }

        public MacAddress(string macAddress)
        {
            if(!IsMacAddress(macAddress))
            {
                throw new ArgumentException(message: "Invalid argument", paramName: nameof(macAddress));
            }

            Address = macAddress;
        }

        private bool IsMacAddress(string address)
        {
            return Regex.IsMatch(address, "^((([a-fA-F0-9][a-fA-F0-9]+[-]){5}|" +
                    "([a-fA-F0-9][a-fA-F0-9]+[:]){5})([a-fA-F0-9][a-fA-F0-9])$)|" +
                    "(^([a-fA-F0-9][a-fA-F0-9][a-fA-F0-9][a-fA-F0-9]+[.]){2}" +
                    "([a-fA-F0-9][a-fA-F0-9][a-fA-F0-9][a-fA-F0-9]))$");
        }
    }
}
