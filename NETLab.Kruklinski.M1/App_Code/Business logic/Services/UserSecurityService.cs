using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using App_Code.Domain;
using App_Code.Business_logic.Helpers;
using System.Web.Helpers;

namespace App_Code.Business_logic.Services
{
    public class UserSecurityService
    {
        static Regex emailValidationRegex = new Regex(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}");

        public static bool ValidateUser(string email, string password, IEqualityComparer<string> passwordComparer)
        {
            UserExceptionsHelper.GetEmailExceptions(email, emailValidationRegex);
            UserExceptionsHelper.GetPasswordExceptions(password);
            bool result = false;
            using (var context = new EFDbContext())
            {
                var query = context.Users.Where(u => u.Email == email);
                if (query.Count() != 0)
                {
                    var user = query.First();
                    result = passwordComparer.Equals(user.Password, password);
                }
                else
                {
                    context.Users.Add(new Domain.Model.Membership.User { Email = email, Password = Crypto.HashPassword(password) });
                    context.SaveChanges();
                }
            }
            return result;
        }
    }
}