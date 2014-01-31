using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Examine;
using UmbracoExamine;
using Examine.LuceneEngine.SearchCriteria;

namespace LocalLinked.Umbraco.Data
{
    public class EmailListRepository
    {
        public IEnumerable<string> GetByLocation(string location)
        {
            var searcher = ExamineManager.Instance.SearchProviderCollection["InternalMemberSearcher"];

            var criteria = searcher.CreateSearchCriteria(IndexTypes.Member)
                .Field("member_location", location)
                .Compile();

            var searchResults = searcher.Search(criteria);

            return searchResults.Select(r => r.Fields["loginName"]);
        }

        public IEnumerable<string> GetByIndustry(string industry)
        {
            var searcher = ExamineManager.Instance.SearchProviderCollection["InternalMemberSearcher"];

            var criteria = searcher.CreateSearchCriteria(IndexTypes.Member)
                .Field("member_industry", industry)
                .Compile();

            var searchResults = searcher.Search(criteria);

            return searchResults.Select(r => r.Fields["loginName"]);
        }
    }
}