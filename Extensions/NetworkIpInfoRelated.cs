using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using IpInfo.Model;

namespace IpInfo.Extensions
{
    internal static class NetworkIpInfoRelated
    {
                public static void Add(this IList<NetworkIpInfo> list, string name, string? ipv4, string? ipv6)
                {
                    list.Add(new NetworkIpInfo
                    {
                        Name = name,
                        Ipv4 = ipv4 ?? "",
                        Ipv6 = ipv6 ?? ""
                    });
                }
        
                public static void AddRange(this IList<NetworkIpInfo> list, IEnumerable<NetworkInterface> values)
                {
                    foreach (var item in values)
                    {
                        var name = item.Name;
                        var ipv4 = item.IpV4Address()?.ToString() ?? string.Empty;
                        var ipv6 = item.IpV6Address()?.ToString() ?? string.Empty;
                        // skip entries that we can't render properly
                        if (string.IsNullOrWhiteSpace(ipv4) && string.IsNullOrWhiteSpace(ipv6)) continue;
                        list.Add(name, ipv4, ipv6);
                    }
                }
        
                public static void WriteTable(this IList<NetworkIpInfo> list, TextWriter writer, bool showIpv6)
                {
                    var col1Len = list.Select(i => i.Ipv4.Length).Max();
                    var col2Len = list.Select(i => i.Ipv6.Length).Max();
                    var indent = new string(' ', 4);
                    foreach (var entry in list)
                    {
                        var col1 = entry.Ipv4.PadRight(col1Len);
                        var col2 = entry.Ipv6.PadRight(col2Len);
                        writer.Write(indent);
                        if (showIpv6)
                        {
                            writer.WriteLine($"{col1}  {col2}  {entry.Name}");
                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(entry.Ipv4)) continue;
                            writer.WriteLine($"{col1}  {entry.Name}");
                        }
                    }
                }
    }
}