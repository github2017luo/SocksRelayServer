﻿using System.Linq;
using System.Threading.Tasks;

namespace SocksRelayServer.Dns
{
    using System.Net;

    internal class DefaultDnsResolver : IDnsResolver
    {
        public Task<IPAddress> TryResolve(string hostname)
        {
            IPAddress result = null;

            if (IPAddress.TryParse(hostname, out var address))
            {
                return Task.FromResult(address);
            }

            try
            {
                result = Dns.GetHostAddresses(hostname).FirstOrDefault();
            }
            catch
            {
                // ignore
            }

            return Task.FromResult(result);
        }
    }
}
