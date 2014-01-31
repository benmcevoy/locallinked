using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Umbraco.Membership.Statistics.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var service = new Service();

            var f = service.GetProfileFrequency("SiteMember", "member_location", "Location");
            var s = service.GetStatistics("SiteMember");

            var m = service.GetCumulativeMonthlyFrequency("SiteMember");

        }
    }
}
