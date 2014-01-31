using System;
using System.Linq;
using System.Collections.Generic;

namespace Umbraco.Membership.Statistics
{
    public class ProfileFrequency
    {
        public ProfileFrequency()
        {
            Frequencies = new List<KeyValuePair<string, int>>();
        }

        public int Total { get { return Frequencies.Sum(f => f.Value); } }

        public IEnumerable<KeyValuePair<string, int>> Frequencies { get; set; }

        public string ProfileProperty { get; set; }

        public string Label { get; set; }
    }
}
