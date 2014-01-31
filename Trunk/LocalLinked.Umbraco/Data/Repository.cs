using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Diagnostics;

namespace LocalLinked.Umbraco.Data
{
    public abstract class Repository
    {
        protected readonly DataModelDataContext _context;

        public Repository()
        {
            _context = new DataModelDataContext(ConfigurationManager.AppSettings["umbracoDbDSN"]);

            AttachLogger();
        }

        [Conditional("DEBUG")]
        private void AttachLogger()
        {
            _context.Log = new DebugTextWriter();
        }
    }
}
