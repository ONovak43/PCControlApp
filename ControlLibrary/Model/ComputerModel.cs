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

        public string ComputerName
        {
            get => $"{ Name }: { Domain }, { MacAddress }";
        }

        /// <summary>
        /// Value thats set on true for - - after computer starts.
        /// </summary>
        public bool IsStarting = false;

        public ComputerModel(string domain, MacAddress macAddress, string name)
        {
            Domain = domain;
            MacAddress = macAddress;
            Name = name;
        }
        public async void Start()
        {
            await Network.WakeOnLan(MacAddress);
            IsStarting = true;
            StopStarting();
        }
        public bool Shutdown()
        {
            ConnectionOptions options = new ConnectionOptions
            {
                EnablePrivileges = true,
                Username = ConfigurationManager.AppSettings["userName"],
                Password = ConfigurationManager.AppSettings["userPassword"]
            };

            ManagementScope scope = new ManagementScope($"\\\\{ Domain }\\root\\cimv2", options);
            try
            {
                scope.Connect();
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }

            SelectQuery query = new SelectQuery("Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            foreach (ManagementObject os in searcher.Get())
            {
                // Obtain in-parameters for the method
                ManagementBaseObject inParams =
                    os.GetMethodParameters("Win32Shutdown");

                // Add the input parameters.
                inParams["Flags"] = 1;

                // Execute the method.
                os.InvokeMethod("Win32Shutdown", inParams, null);
            }

            return true;
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
