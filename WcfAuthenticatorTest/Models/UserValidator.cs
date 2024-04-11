using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfAuthenticatorTest.Models
{
    public class UserValidator
    {
        public bool IsUserValid(string userName, string password, out IList<string> roles)
        {
            roles = new List<string>();

            bool result = (userName == "user") && (password == "pass");

            if (result) // If valid user return the Roles of user  
                roles.Add("Read");

            return result;
        }
    }
}