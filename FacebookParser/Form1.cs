using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Facebook;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.CSharp.RuntimeBinder;


namespace FacebookParser
{

    public partial class Form1 : Form
    {

        public class FBFeed
        {
          public FBFeed()
            {
              Message = "";
              Comments = "";
              created_time = "";
            }
            public string created_time{ set; get; }
            public string Message { set; get; }
            public string Comments{ set; get; }
        }

        List<FBFeed> fbFeedList = new List<FBFeed>(); 

        public LoginForm MyLoginForm = new LoginForm();
        public LogoutForm MyLogoutForm = new LogoutForm();
        public CommentsForm MyCommentsForm = new CommentsForm();
        public Uri loginUrl;
        public Uri logoutUrl;
        public FacebookClient fb;
        //public string AppID = "1759333630959136";
        public string AppID = "722702851177541";
        
        //public string AppSecret = "936f635cd64842ef5fb10779b8fb4e11";
        public string AppSecret = "c009b094bed9f44dfed7aab9da872946";
        //public string UserId = "100000887089684";
        public string Accesscode = "";
        public string AccessToken = "";
        public String TotalData = "";


        public Dictionary<string,string> TitlevsMessage;
        public Form1()
        {
            InitializeComponent();
            TitlevsMessage = new Dictionary<string, string>();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MyLoginForm.Mainform = this;
            MyLogoutForm.Mainform = this;
            MyCommentsForm.Mainform = this;
            fb = new FacebookClient();
            button4.Enabled = true;
            button2.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          showData();
        }
        public void showData()
        {
          String pattern = "\"id\":\"\\d+_";
          string[] splitResult = Regex.Split(TotalData, pattern);
          dataGridView1.Rows.Clear();
          dataGridView1.Refresh();
          dataGridView1.ColumnCount = 3;
          dataGridView1.Columns[0].Name = "摘要";
          dataGridView1.Columns[1].Name = "時間";
          dataGridView1.Columns[2].Name = "回覆";
          dataGridView1.Columns[2].Visible = false;

          DataGridViewColumn column = dataGridView1.Columns[0];
          column.Width = 400;

          foreach (FBFeed fbFeed in fbFeedList)
          {
            if (fbFeed.Message.Contains(textBox1.Text))
            {
              dataGridView1.Rows.Add(fbFeed.Message, fbFeed.created_time, fbFeed.Comments);
            }
          }
        }

        public String getAccessToken()
        {
            try
            {
                dynamic result = fb.Post("oauth/access_token", new
                {
                    client_id = AppID,
                    client_secret = AppSecret,
                    redirect_uri = "https://www.facebook.com/connect/login_success.html",
                    code = Accesscode
                });
                return result.access_token;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Exception Message : {0}{1}", ex.Message, Environment.NewLine));
                return "";
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;

            if (fb.AccessToken == null)
            {
              MyLoginForm.ShowDialog();
              fb.AccessToken = getAccessToken();
            }
            dynamic result = fb.Get("me/picture?redirect=false&type=large");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Load(result.data.url);

            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 50;

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyLogoutForm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MyCommentsForm.ShowDialog();
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
          DateTime d = DateTime.Now;

          d = d.AddMonths(-2);
          //dynamic result = fb.Get("607414496082801/feed?limit=50&offset=0&fields=id,created_time,message,comments");
          dynamic result = fb.Get("607414496082801/feed?fields=id,created_time,message,comments&since=" + d.ToString("yyyy-MM-dd") + "&offset=0");
          while (result.paging != null)
          {
            foreach (dynamic post in result.data)
            {
              String comments = "";
              dynamic moreComments = post.comments;
              while(true)
              {
                comments = comments + moreComments;
                try
                {
                  if (moreComments.paging.next != null)
                  {
                    moreComments = fb.Get(moreComments.paging.next);
                  }
                  else
                  {
                    break;
                  }
                }
                catch (RuntimeBinderException ex)
                {
                  break;
                } 
              }
              FBFeed fbFeed = new FBFeed();
              if (post.created_time != null)
              {
                try
                {
                  fbFeed.created_time = post.created_time;
                }
                catch (RuntimeBinderException ex)
                {
                  //do nothing
                } 
              }
              if (post.message != null)
              {
                try
                {
                  fbFeed.Message = post.message;
                }
                catch (RuntimeBinderException ex)
                {
                  //do nothing
                } 
              }
              if (post.comments != null)
              {
                try
                {
                  fbFeed.Comments = comments;
                }
                catch (RuntimeBinderException ex)
                {
                  //do nothing
                } 
              }
              fbFeedList.Add(fbFeed);
            }
            result = fb.Get(result.paging.next);
          }
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
          progressBar1.MarqueeAnimationSpeed = 0;
          progressBar1.Style = ProgressBarStyle.Blocks;
          progressBar1.Value = progressBar1.Minimum;

          button1.Enabled = true;
          showData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
          MyLoginForm.ShowDialog();
          button4.Enabled = false;
          button2.Enabled = true;
          button3.Enabled = true;
        }


    }
}
