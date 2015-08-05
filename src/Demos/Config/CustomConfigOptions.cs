using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demos.Data;

namespace Demos.Config
{
    public class CustomConfigOptions
    {
        public string Conference { get; set; }
        public string Website { get; set; }
        public LocationOptions Location { get; set; }

        public class LocationOptions
        {
            public string Venue { get; set; }
            public string Address { get; set; }
            public string phone { get; set; }
        }
    }
}
