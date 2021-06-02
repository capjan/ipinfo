# ipinfo

[![.NET 5.0](https://github.com/capjan/ipinfo/actions/workflows/dotnet.yml/badge.svg)](https://github.com/capjan/ipinfo/actions/workflows/dotnet.yml)

ipinfo lists known ip addresses for your computer.

## Installation

ipinfo is a command line tool that can be installed as [.NET tool](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools)
```bash
dotnet tool install --global cap.ipinfo
```

## My Reasons for ipinfo

1. I don't like to think about whether I have to type `ifconfig` (OS X and Linux) or `ipconfig` (Windows) into the console to see the local IP address for my machine.
2. I always want to see my public IP address that I am using on the internet.
3. I want to see only IPv4 addresses, but if I need the IPv6 addresses, I just want to be able to display them optionally.

## Usage Exampe:

```
C:\>ipinfo
    xxx.xxx.xxx.xxx  Internet (Public)
    xxx.xxx.xxx.xxx  Ethernet
    xxx.xxx.xxx.xxx  VirtualBox Host-Only Network
    xxx.xxx.xxx.xxx  VMware Network Adapter VMnet1
    xxx.xxx.xxx.xxx  VMware Network Adapter VMnet8
    xxx.xxx.xxx.xxx  Loopback Pseudo-Interface 1
C:\>
```
With:
* The first column displays the IPv4 Address. (`xxx.xxx.xxx.xxx` is just a placeholder for this readme)
* The second column shows the name of the interface. The first line is your public internet address.

## Options

```
Usage:
 ipinfo [options]

Options:
      --v6, --ipv6           display also IPv6 results
  -l, --local                restrict to local ip info
  -h, -?, --help             display this help and exit
  -v, --version              show version information and exit
```

## Remarks:

- This tool depends on a core library called [CoreLib](https://github.com/capjan/CoreLib) (cap.core)
