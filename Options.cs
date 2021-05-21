using Core.Parser.Arguments;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace IpInfo
{
    public class Options : CliOptions
    {
        [Option("v6|ipv6", "display also IPv6 results")]
        public bool ShowIpv6    { get; set; }

        [Option("l|local", "restrict to local ip info")]
        public bool LocalOnly   { get; set; }
    }
}
