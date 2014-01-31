using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umbraco.Membership.Statistics
{
    public class CumulativeMonthlyFrequency
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<KeyValuePair<int, SignUpFrequency>> FrequencyPerMonth { get; set; }

        public IEnumerable<KeyValuePair<int, SignUpFrequency>> CumulativePerEndOfMonth { get; set; }
    }

    public class SignUpFrequency
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public int Frequency { get; set; }
    }
}



