using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApplication
{
    public partial class Form1 : Form
    {
        private string cookie;
        public Form1()
        {
            InitializeComponent();
        }

        private void Authenticate_Click(object sender, EventArgs e)
        {
            AuthSvc.AuthenticationServiceClient client = new AuthSvc.AuthenticationServiceClient();

            using (new OperationContextScope(client.InnerChannel))
            {
                bool result = client.Login("user", "pass", string.Empty, true);
                var responseMessageProperty = (HttpResponseMessageProperty)OperationContext.Current.IncomingMessageProperties
                [HttpResponseMessageProperty.Name];

                if (result)
                {
                    cookie = responseMessageProperty.Headers.Get("Set-Cookie");
                    MessageBox.Show(result.ToString() + Environment.NewLine + cookie);
                }
            }
        }

        private void Utility_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cookie))
            {
                MessageBox.Show("Please click Authenticate first.");
                return;
            }

            UtilitySvc.UtilityServiceClient utilClient = new UtilitySvc.UtilityServiceClient();

            using (new OperationContextScope(utilClient.InnerChannel))
            {

                HttpRequestMessageProperty request = new HttpRequestMessageProperty();
                request.Headers[HttpResponseHeader.SetCookie] = cookie;
                OperationContext.Current.OutgoingMessageProperties
                         [HttpRequestMessageProperty.Name] = request;

                string result = utilClient.GetData(10);
                MessageBox.Show(result);
            }
        }
    }
}
