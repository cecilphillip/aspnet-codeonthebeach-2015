using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Framework.Configuration;

namespace Demos.Config
{
    public class RethinkDbConfiguration : IConfigurationSource
    {
        //TODO: to this tonight
        public bool TryGet(string key, out string value)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, string value)
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> ProduceConfigurationSections(IEnumerable<string> earlierKeys, string prefix, string delimiter)
        {
            throw new NotImplementedException();
        }
    }
}
