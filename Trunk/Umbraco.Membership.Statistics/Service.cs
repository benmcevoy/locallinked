using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Threading;

namespace Umbraco.Membership.Statistics
{
    public class Service
    {
        private readonly Repository _repository = new Repository();

        public Statistics GetStatistics(string memberType)
        {
            return _repository.GetStatistics(memberType);
        }

        public ProfileFrequency GetProfileFrequency(string memberType, string profilePropertyName, string label)
        {
            return _repository.GetProfileFrequency(memberType, profilePropertyName, label);
        }

        public CumulativeMonthlyFrequency GetCumulativeMonthlyFrequency(string memberType, int monthsToShow = 12)
        {
            return _repository.GetCumulativeMonthlyFrequency(memberType, monthsToShow);
        }
    }
}
