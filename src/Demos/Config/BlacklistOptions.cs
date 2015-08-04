using System.Collections.Generic;

namespace Demos.Middleware
{
    public class BlacklistOptions
    {
        public IList<string> IpAddresses { get; protected set; }

        public BlacklistOptions()
        {
            IpAddresses = new List<string>();
        }
    }
}