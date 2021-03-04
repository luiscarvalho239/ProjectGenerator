
namespace ProjectGenerator.data
{
    partial class FormViewDoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webNav = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webNav)).BeginInit();
            this.SuspendLayout();
            // 
            // webNav
            // 
            this.webNav.CreationProperties = null;
            this.webNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webNav.Location = new System.Drawing.Point(0, 0);
            this.webNav.Name = "webNav";
            this.webNav.Size = new System.Drawing.Size(800, 450);
            this.webNav.TabIndex = 0;
            this.webNav.ZoomFactor = 1D;
            // 
            // FormViewDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.webNav);
            this.Name = "FormViewDoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver documentação do projeto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormViewDoc_FormClosing);
            this.Load += new System.EventHandler(this.FormViewDoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webNav)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webNav;
    }
}