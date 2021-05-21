using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace IpInfo.Extensions
{
    internal static class NetworkInterfaceRelated
    {
        public static IPAddress? IpV4Address(this NetworkInterface value)
        {
            return value.FirstOrDefaultByFamily(AddressFamily.InterNetwork);
        }

        public static IPAddress? IpV6Address(this NetworkInterface value)
        {
            return value.FirstOrDefaultByFamily(AddressFamily.InterNetworkV6);
        }

        private static IPAddress? FirstOrDefaultByFamily(this NetworkInterface value, AddressFamily family)
        {
            return value
                .GetIPProperties()
                .UnicastAddresses
                .FirstOrDefault(i=>i.Address.AddressFamily == family)?.Address;
        }
        
    }
}