using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LocalLinked.Umbraco.Data;
using System.Text;

namespace LocalLinked.Umbraco.Services
{
    /// <summary>
    /// Summary description for Industry
    /// </summary>
    public class Industry : Handler
    {
        private static IndustryRepository _repository = new IndustryRepository();

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);

            var query = context.Request["q"];

            var data = ToPlainText(_repository.Get(query, 10));

            WriteResponse(context, data);
        }

        private string ToPlainText(IQueryable<Data.Industry> industries)
        {
            var result = new StringBuilder();

            foreach (var item in industries)
            {
                result.AppendLine(item.Name);
            }

            return result.ToString();
        }
    }
}