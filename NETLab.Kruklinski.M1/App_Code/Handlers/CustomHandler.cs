using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App_Code.Handlers
{
    public class CustomHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "aplication/json";
            context.Response.WriteFile("~/App_Data/data.json");
        }
    }
}