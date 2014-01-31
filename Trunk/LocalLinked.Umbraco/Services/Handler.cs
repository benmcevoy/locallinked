using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalLinked.Umbraco.Services
{
    public abstract class Handler : IHttpHandler
    {
        protected void WriteResponse(HttpContext context, string data)
        {
            context.Response.Clear();
            context.Response.Write(data);
            context.Response.Flush();
        }

        public bool IsReusable { get { return false; } }


        public virtual void ProcessRequest(HttpContext context)
        {
            
        }
    }
}