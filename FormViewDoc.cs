using System;
using System.Windows.Forms;

namespace ProjectGenerator.data
{
    public partial class FormViewDoc : Form
    {
        private string _url;
        public FormViewDoc(string url = "https://docs.microsoft.com/")
        {
            InitializeComponent();
            _url = url;
        }

        private void FormViewDoc_Load(object sender, EventArgs e)
        {
            this.Icon = new System.Drawing.Icon(Functions.GetDir() + @"\Resources\icons\winformsapp.ico");
            if (webNav != null)
            {
                //webNav.CoreWebView2.Navigate(_url);
                webNav.Source = new Uri(_url);
            }
        }

        private void FormViewDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}
