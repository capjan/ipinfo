using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using Core.Extensions.NetRelated;
using Core.Net.Impl;
using Core.Parser.Arguments;
using IpInfo.Extensions;
using IpInfo.Model;

namespace IpInfo
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var parser = new OptionParser<Options>();
            if (!parser.TryParse(args, out var options))
                return;

            try
            {

                var table = new List<NetworkIpInfo>();
                if (!options.LocalOnly && new DefaultPublicIpResolver().TryResolve(out var publicIp))
                    table.Add("Internet (Public)", publicIp, null);

                var activeNetworkInterfaces = NetworkInterface
                    .GetAllNetworkInterfaces()
                    .Where(i => i.OperationalStatus == OperationalStatus.Up)
                    .ToArray();
                
                table.AddRange(activeNetworkInterfaces.Where(i => i.NetworkInterfaceType == NetworkInterfaceType.Ethernet));
                table.AddRange(activeNetworkInterfaces.Where(i => i.NetworkInterfaceType == NetworkInterfaceType.Wireless80211));
                table.AddRange(activeNetworkInterfaces.Where(i => i.NetworkInterfaceType == NetworkInterfaceType.Loopback));
                
                table.WriteTable(Console.Out, options.ShowIpv6);

            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                parser.WriteUsage();
            }
        }
    }
}