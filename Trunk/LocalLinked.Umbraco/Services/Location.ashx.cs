using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using LocalLinked.Umbraco.Data;
using System.Text;

namespace LocalLinked.Umbraco.Services
{
    public class Location : Handler
    {
        private static LocationRepository _repository = new LocationRepository();

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
        
            var query = context.Request["q"];

            var data = ToPlainText(_repository.Get(query, 10));

            WriteResponse(context, data);
        }

        private string ToPlainText(IQueryable<Data.Location> locations)
        {
            var result = new StringBuilder();

            foreach (var item in locations)
            {
                if (string.IsNullOrEmpty(item.RegionName))
                {
                    result.AppendLine(item.CountryName);   
                }
                else
                {
                    result.AppendLine(item.RegionName);
                }
            }

            return result.ToString();
        }
    }
}