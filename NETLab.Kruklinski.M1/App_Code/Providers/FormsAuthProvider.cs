using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace App_Code.Providers
{
    public class FormsAuthProvider
    {
        public static bool LogIn(string email, string password, bool rememberMe = true)
        {
            bool result = false;
            if (MembershipProvider.ValidateUser(email, password))
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);
                result = true;
            }
            return result;
        }

        public static void LogOut()
        {
            FormsAuthentication.SignOut();
        }
        
        public static void AuthenticateUser(HttpContext context)
        {
            HttpCookie authCookie = context.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            if (authCookie != null && !string.IsNullOrWhiteSpace(authCookie.Value))
            {
                var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                if (ticket != null && !string.IsNullOrWhiteSpace(ticket.Name))
                {
                    context.User = new GenericPrincipal(new GenericIdentity(ticket.Name), null);
                }
            }
        }
    }
}