using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.Text;
using WcfAuthenticatorTest.Models;

namespace WcfAuthenticatorTest.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UtilityService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UtilityService.svc or UtilityService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class UtilityService : IUtilityService
    {
        public UtilityService()
        {
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Read")]
        public string GetData(int i)
        {
            string result = "You Entered: " + i.ToString();

            return result;
        }

        private string Concatenate(string userName, IList<string> roles)
        {
            string result = userName + ";";

            foreach (string role in roles)
                result += role + ";";

            return result;
        }
    }
}
