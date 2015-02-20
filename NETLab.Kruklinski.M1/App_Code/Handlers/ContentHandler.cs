using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App_Code.Handlers
{
    public class ContentHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod == "GET")
            {
                context.Response.ContentType = context.Request.ContentType;
                context.Response.WriteFile(context.Request.Path);
            }
        }
    }
}