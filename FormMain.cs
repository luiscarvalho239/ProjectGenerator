using System;
using System.Windows.Forms;

namespace ProjectGenerator
{
    public partial class FormMain : Form
    {

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Icon = new System.Drawing.Icon(Functions.GetDir()+@"\Resources\icons\winformsapp.ico");
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
