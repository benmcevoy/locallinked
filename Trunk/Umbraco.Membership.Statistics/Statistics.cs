using System;

namespace Umbraco.Membership.Statistics
{
    public class Statistics
    {
        public int Total { get; set; }

        public int ThisYear { get; set; }

        public int ThisMonth { get; set; }

        public int ThisWeek { get; set; }

        public int Today { get; set; }

        public string MemberType { get; set; }
    }
}
