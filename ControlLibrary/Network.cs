using ControlLibrary.Wrapper;
using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControlLibrary
{
    public static class Network
    {
        public static async Task WakeOnLan(MacAddress macAddress, string ip = "255.255.255.255", int port = 7)
        {
            byte[] magicPacket = BuildMagicPacket(macAddress);

            using (UdpClient client = new UdpClient())
            {
                client.Connect(IPAddress.Parse(ip), port);
                await client.SendAsync(magicPacket, magicPacket.Length);
            }

        }

        public static async Task<bool> Ping(string host)
        {
            var hostname = host;
            var timeout = 1000;

            using (Ping ping = new Ping())
            {
                try
                {
                    PingReply pingreply = await ping.SendPingAsync(hostname, timeout);

                    if (pingreply.Status == IPStatus.Success)
                    {
                        return true;
                    }
                }
                catch (PingException)
                {
                    return false;
                }
            }

            return false;
        }

        private static byte[] BuildMagicPacket(MacAddress macAddress) // MacAddress in any standard HEX format.
        {
            string address = Regex.Replace(macAddress.Address, "[: -]", "");
            var macBytes = new byte[6];

            for (var i = 0; i < 6; i++)
            {
                macBytes[i] = Convert.ToByte(address.Substring(i * 2, 2), 16);
            }

            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    for (var i = 0; i < 6; i++)  // First 6 times 0xff.
                    {
                        bw.Write((byte)0xff);
                    }
                    for (var i = 0; i < 16; i++) // Then 16 times MacAddress.
                    {
                        bw.Write(macBytes);
                    }
                }
                return ms.ToArray(); // 102 bytes magic packet.
            }
        }

    }
}
