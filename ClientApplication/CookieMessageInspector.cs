using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.Net;
using System.Windows.Forms;

namespace ClientApplication
{
    public class CookieMessageInspector : IClientMessageInspector
    {
        private string cookie;

        public CookieMessageInspector()
        {

        }

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply,
            object correlationState)
        {
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            if (string.IsNullOrEmpty(cookie))
            {
                MessageBox.Show("No Cookie Information found! Please Authenticate.");
                return null;
            }

            HttpRequestMessageProperty requestMessageProperty = new HttpRequestMessageProperty();
            requestMessageProperty.Headers[HttpResponseHeader.SetCookie] = cookie;
            request.Properties[HttpRequestMessageProperty.Name] = requestMessageProperty;

            return null;
        }
    }
}
