using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.presentation.umbracobase;
using System.Web.Script.Serialization;
using Umbraco.Membership.Statistics;

namespace LocalLinked.Umbraco.Services
{
    [RestExtension("stats")]
    public class Statistics
    {
        private static JavaScriptSerializer _serializer = new JavaScriptSerializer();

        [RestExtensionMethod(returnXml = false)]
        public static string getIndustry()
        {
            var service = new Service();

            return _serializer.Serialize(service.GetProfileFrequency("SiteMember", "member_industry", "Industry"));
        }

        [RestExtensionMethod(returnXml = false)]
        public static string getLocation()
        {
            var service = new Service();

            return _serializer.Serialize(service.GetProfileFrequency("SiteMember", "member_location", "Location"));
        }

        [RestExtensionMethod(returnXml = false)]
        public static string getStatistics()
        {
            var service = new Service();

            return _serializer.Serialize(service.GetStatistics("SiteMember"));
        }

        [RestExtensionMethod(returnXml = false)]
        public static string getCumulative()
        {
            var service = new Service();

            return _serializer.Serialize(service.GetCumulativeMonthlyFrequency("SiteMember", 6));
        }
    }
}