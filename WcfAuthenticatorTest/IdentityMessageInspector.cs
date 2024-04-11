using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;
using System.Web.Security;
using WcfAuthenticatorTest.Models;

namespace WcfAuthenticatorTest
{
    public class IdentityMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.
            InstanceContext instanceContext)
        {
            // Extract Cookie (name=value) from messageproperty  
            var messageProperty = (HttpRequestMessageProperty)
                OperationContext.Current.IncomingMessageProperties[HttpRequestMessageProperty.Name];
            string cookie = messageProperty.Headers.Get("Set-Cookie");
            string[] nameValue = cookie.Split('=', ',');
            string value = string.Empty;

            // Set User Name from cookie  
            if (nameValue.Length >= 2)
                value = nameValue[5];

            var unencryptedValue = FormsAuthentication.Decrypt(value);

            string userName = GetUserName(unencryptedValue.UserData);
            string[] roles = GetRoles(unencryptedValue.UserData);

            // Set Thread Principal to User Name  
            CustomIdentity customIdentity = new CustomIdentity();
            GenericPrincipal threadCurrentPrincipal = new GenericPrincipal(customIdentity, roles);
            customIdentity.IsAuthenticated = true;
            customIdentity.Name = userName;
            customIdentity.Role = roles[0];
            System.Threading.Thread.CurrentPrincipal = threadCurrentPrincipal;

            return null;
        }

        private string[] GetRoles(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                List<string> roles = new List<string>();

                int ix = 0;
                foreach (string item in value.Split(';'))
                {
                    if (ix > 0)
                        if (item.Trim().Length > 0)
                            roles.Add(item);

                    ix++;
                }

                return roles.ToArray<string>();
            }

            return new string[0];
        }

        private string GetUserName(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                foreach (string item in value.Split(';'))
                    return item;
            }

            return string.Empty;
        }
        public void BeforeSendReply(ref Message reply, object correlationState)
        {

        }
    }
}