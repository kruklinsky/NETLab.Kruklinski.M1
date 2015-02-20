using System;
using System.Web.Helpers;
using System.Collections.Generic;
using App_Code.Business_logic.Services;

namespace App_Code.Providers
{
    public class MembershipProvider
    {
        public static bool ValidateUser(string username, string password)
        {
            return UserSecurityService.ValidateUser(username, password, new PasswordComparer(Crypto.VerifyHashedPassword));
        }

        private class PasswordComparer : IEqualityComparer<string>
        {
            private Func<string, string, bool> Compare;

            public PasswordComparer(Func<string, string, bool> comparefunction)
            {
                this.Compare = comparefunction;
            }

            public bool Equals(string x, string y)
            {
                return this.Compare(x, y);
            }

            public int GetHashCode(string obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}