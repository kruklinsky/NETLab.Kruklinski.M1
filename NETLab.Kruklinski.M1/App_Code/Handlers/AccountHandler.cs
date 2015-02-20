using App_Code.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App_Code.Handlers
{
    public class AccountHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod == "GET")
            {
                if (context.Request.Path == "/Account/Authenticated")
                {
                    this.Authenticated(context);
                }
            }
            else if (context.Request.HttpMethod == "POST")
            {
                if (context.Request.Path == "/Account/LogIn")
                {
                    this.LogIn(context);
                }
                else if (context.Request.Path == "/Account/LogOut")
                {
                    this.LogOut();
                }
            }
        }

        private void Authenticated(HttpContext context)
        {
            context.Response.ContentType = "text";
            context.Response.Write(context.User.Identity.IsAuthenticated ? "true" : "false");
        }

        private void LogIn(HttpContext context)
        {
            var email = context.Request.Form["email"];
            var password = context.Request.Form["password"];
            if (!String.IsNullOrWhiteSpace(email) && !String.IsNullOrWhiteSpace(password))
            {
                FormsAuthProvider.LogIn(email, password);
            }
        }

        private void LogOut()
        {
            FormsAuthProvider.LogOut();
        }
    }
}