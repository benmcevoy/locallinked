using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace LocalLinked.Umbraco.Data
{
    public class IndustryRepository : Repository
    {
        public IndustryRepository()
            : base()
        {

        }

        public IQueryable<Industry> Get(string industryName, int count)
        {
            return _context.Industries
                .Where(i => i.Name.StartsWith(industryName))
                .OrderBy(i => i.Name)
                .Take(count);
        }
    }
}