using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            {
                throw new ArgumentException(message: "Invalid argument", paramName: nameof(macAddress));
            }               

            Domain = domain;
            MacAddress = macAddress;
        }

        public async void Start()
        {
            await Network.WakeOnLan(MacAddress);
            IsStarting = true;
            StopStarting();
        }

        public void Shutdown()
        {

            System.Management.ConnectionOptions options = new System.Management.ConnectionOptions
            {
                    EnablePrivileges = true,
                    Username = "User",
                    Password = ""
                };

                ManagementScope scope = new ManagementScope(
                    $"\\\\{ Domain }\\root\\cimv2", options);

                scope.Connect();

                //Query system for Operating System information
                ObjectQuery query = new ObjectQuery(
                    "SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection queryCollection = searcher.Get();

                MessageBox.Show("adad");

                foreach (ManagementObject m in queryCollection)
                {
                    // Display the remote computer information
                    MessageBox.Show($"Computer Name : { m["csname"] }+{ m["Version"] }+{ m["Manufacturer"] }");
                }

                /*SelectQuery query = new SelectQuery("Win32_OperatingSystem");
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject os in searcher.Get())
                {
                    // Obtain in-parameters for the method
                    ManagementBaseObject inParams =
                        os.GetMethodParameters("Win32Shutdown");

                    // Add the input parameters.
                    inParams["Flags"] = 2;

                    // Execute the method and obtain the return values.
                    ManagementBaseObject outParams =
                        os.InvokeMethod("Win32Shutdown", inParams, null);*/

        }

        public async Task<bool> IsRunning()
        {
            return await Network.Ping(Domain);
        }

        private async void StopStarting()
        {
            await Task.Delay(60000);
            IsStarting = false;
        } 

    }
}
