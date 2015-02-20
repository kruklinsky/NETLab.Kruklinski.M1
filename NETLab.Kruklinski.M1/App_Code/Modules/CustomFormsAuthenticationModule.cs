using System;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;

using App_Code.Domain;
using App_Code.Providers;
using System.Text;
using System.Security.Principal;



namespace App_Code.Modules
{
    public class CustomFormsAuthenticationModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(this.ApplicationAuthenticateRequest);
        }

        private void ApplicationAuthenticateRequest(Object source, EventArgs e)
        {
            var application = (HttpApplication)source;
            var context = application.Context;
            this.Authenticate(context);
        }

        private void Authenticate (HttpContext context)
        {
            FormsAuthProvider.AuthenticateUser(context);
        }
    }
}