using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NETLab.Kruklinski.M1
{
    public class CustomGenericHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "aplication/json";
            context.Response.WriteFile("~/App_Data/data.json");
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}