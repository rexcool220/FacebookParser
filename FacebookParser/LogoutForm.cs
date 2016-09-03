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
    public partial class LogoutForm : Form
    {
        public Form1 Mainform = null;
        public LogoutForm()
        {
            InitializeComponent();
        }

        private void LogoutForm_Load(object sender, EventArgs e)
        {
          Mainform.logoutUrl = Mainform.fb.GetLogoutUrl(new { access_token = Mainform.getAccessToken(), next = "https://www.facebook.com/connect/login_success.html" });
            webBrowser1.Navigate(Mainform.logoutUrl); 
        }
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.Close();
        }
    }
}
