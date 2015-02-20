using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App_Code.Handlers
{
    public class HomeHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod == "GET")
            {
                if (context.Request.Path == "/Home/Index")
                {
                    this.Index(context);
                }
            }
        }

        private void Index(HttpContext context)
        {

            context.Response.WriteFile("~/index.html");
        }
    }
}