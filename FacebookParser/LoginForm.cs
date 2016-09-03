using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facebook;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacebookParser
{
    public partial class LoginForm : Form
    {
        public Form1 Mainform = null;
        public LoginForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Mainform.loginUrl = Mainform.fb.GetLoginUrl(new
            {
                client_id = Mainform.AppID,
                client_secret = Mainform.AppSecret,
                redirect_uri = "https://www.facebook.com/connect/login_success.html",
                response_type = "code",
                scope = "read_stream" // Add other permissions as needed
            });
            webBrowser1.Navigate(Mainform.loginUrl);
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            var q = HttpUtility.ParseQueryString(webBrowser1.Url.Query);
            var Accesscode = q["code"];
            if (Accesscode != null)
            {
                Mainform.Accesscode = Accesscode.ToString();
                this.Close();
            }
        }
    }
}
