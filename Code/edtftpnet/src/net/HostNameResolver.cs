using System;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

using EnterpriseDT.Util.Debug;

namespace EnterpriseDT.Net
{
    /// <summary>
    /// Utility class for resolving names on all versions of the .NET framework.
    /// </summary>
    internal class HostNameResolver
    {
        /// <summary>
        /// Logger
        /// </summary>
        private static Logger log = Logger.GetLogger("HostNameResolver");

        /// <summary>
        /// Used for determining whether a host-name is actually an IP address.
        /// </summary>
        private const string IP_ADDRESS_REGEX = @"[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}";

        /// <summary>
        /// Returns the IP address matching the given host-name or IP address-string.
        /// </summary>
        /// <param name="hostName">Host-name or IP address-string.</param>
        /// <returns></returns>
        public static IPAddress GetAddress(string hostName)
        {
            if (log.DebugEnabled)
                log.Debug("Resolving {0}", hostName);
            if (hostName == null)
                throw new ArgumentNullException();
            IPAddress address = null;
            if (Regex.IsMatch(hostName, IP_ADDRESS_REGEX))
                address = IPAddress.Parse(hostName);
            else
            {
#if NET20
                IPAddress[] addresses = Dns.GetHostEntry(hostName).AddressList;
                if (log.DebugEnabled)
                    log.Debug("Obtained {0} addresses", addresses.Length);
                // see if there's an IPv4 address
                foreach (IPAddress a in addresses)
                {
                    if (log.DebugEnabled)
                        log.Debug("IP address: {0}", a);
                    if (a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        address = a;
                }
                // otherwise throw an exception coz we don't handle IP yet.
                if (address == null)
                {
                    string msg = string.Format("{0} resolves to an unsupported protocol.", hostName);
                    log.Error(msg);
                    throw new ArgumentException(msg);
                }
#else
                address = Dns.Resolve(hostName).AddressList[0];
#endif
            }
            if (log.DebugEnabled)
                log.Debug(hostName + " resolved to " + address.ToString());
            return address;
        }
    }
}
