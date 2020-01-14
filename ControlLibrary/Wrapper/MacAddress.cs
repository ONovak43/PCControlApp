using System;
using System.Text.RegularExpressions;

namespace ControlLibrary.Wrapper
{
    /// <summary>
    /// Reprezentuje wrapper pro MAC adresu.
    /// </summary>
    public class MacAddress
    {
        /// <summary>
        /// Vrátí MAC adresu.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Incializuje novou instanci třídy ControlLibrary.Wrapper.MacAddress reprezentující
        ///     zadanou MAC adresu.
        /// </summary>
        /// <param name="macAddress"></param>
        public MacAddress(string macAddress)
        {
            if (!IsMacAddress(macAddress))
            {
                throw new ArgumentException(message: "Invalid argument", paramName: nameof(macAddress));
            }

            Address = macAddress;
        }

        /// <summary>
        /// Zkontroluje, zda je MAC adresa ve správném tvaru.
        /// </summary>
        /// <param name="address">MAC adresa.</param>
        /// <returns>Vrátí true v případě, že je MAC adresa ve správném formátu. 
        ///     Vrátí false v případtě, že je MAC adresa v chybném formátu.</returns>
        private bool IsMacAddress(string address)
        {
            return Regex.IsMatch(address, "^((([a-fA-F0-9][a-fA-F0-9]+[-]){5}|" +
                    "([a-fA-F0-9][a-fA-F0-9]+[:]){5})([a-fA-F0-9][a-fA-F0-9])$)|" +
                    "(^([a-fA-F0-9][a-fA-F0-9][a-fA-F0-9][a-fA-F0-9]+[.]){2}" +
                    "([a-fA-F0-9][a-fA-F0-9][a-fA-F0-9][a-fA-F0-9]))$");
        }
    }
}
