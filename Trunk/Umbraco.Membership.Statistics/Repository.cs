using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace Umbraco.Membership.Statistics
{
    internal class Repository
    {
        private readonly string _connectionString;

        public Repository()
        {
            _connectionString = ConfigurationManager.AppSettings["umbracoDbDSN"];
        }

        public ProfileFrequency GetProfileFrequency(string memberType, string profilePropertyName, string label)
        {
            var results = new ProfileFrequency()
            {
                ProfileProperty = profilePropertyName,
                Label = label,
            };

            var frequencies = new List<KeyValuePair<string, int>>();

            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["umbracoDbDSN"]))
            {
                using (var cmd = new SqlCommand(QueryResources.GetProfileFrequency, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@memberType", memberType);
                    cmd.Parameters.AddWithValue("@profilePropertyName", profilePropertyName);

                    conn.Open();

                    var dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        frequencies.Add(new KeyValuePair<string, int>((string)dr["PropertyValue"], (int)dr["Frequency"]));
                    }
                }
            }

            results.Frequencies = frequencies;

            return results;
        }

        public Statistics GetStatistics(string memberType)
        {
            var results = new Statistics()
            {
                MemberType = memberType
            };

            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["umbracoDbDSN"]))
            {
                using (var cmd = new SqlCommand(QueryResources.GetStatistics, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@memberType", memberType);

                    conn.Open();

                    var dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        results.Total = (int)dr["Total"];
                        results.ThisYear = (int)dr["ThisYear"];
                        results.ThisMonth = (int)dr["thisMonth"];
                        results.ThisWeek = (int)dr["ThisWeek"];
                        results.Today = (int)dr["Today"];
                    }
                }
            }

            return results;
        }

        public CumulativeMonthlyFrequency GetCumulativeMonthlyFrequency(string memberType, int monthsToshow = 12)
        {
            var endDate = DateTime.Now;
            var startDate = endDate.AddMonths(-monthsToshow);

            var results = new CumulativeMonthlyFrequency()
            {
                StartDate = startDate,
                EndDate = endDate
            };

            var monthlies = new List<KeyValuePair<int, SignUpFrequency>>();
            var cumulative = new List<KeyValuePair<int, SignUpFrequency>>();
            int cumulativeStart = 0;
            bool isFirst = true;

            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["umbracoDbDSN"]))
            {
                using (var cmd = new SqlCommand(QueryResources.CumulativeFrequency, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@memberType", memberType);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    conn.Open();

                    var dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        if (isFirst)
                        {
                            cumulativeStart = (int)dr["CumulativeStart"];
                            isFirst = false;
                        }

                        cumulativeStart += (int)dr["Frequency"];

                        monthlies.Add(new KeyValuePair<int, SignUpFrequency>((int)dr["DateKey"],
                                    new SignUpFrequency()
                                    {
                                        Frequency = (int)dr["Frequency"],
                                        Month = (int)dr["Month"],
                                        Year = (int)dr["Year"]
                                    }));

                        cumulative.Add(new KeyValuePair<int, SignUpFrequency>((int)dr["DateKey"],
                                new SignUpFrequency()
                                    {
                                        Frequency = cumulativeStart,
                                        Month = (int)dr["Month"],
                                        Year = (int)dr["Year"]
                                    }));
                    }
                }
            }

            results.FrequencyPerMonth = monthlies;
            results.CumulativePerEndOfMonth = cumulative;

            return results;
        }
    }
}
