
namespace ProjectGenerator
{
    partial class ucProjetos
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnEditProjectsFrm = new System.Windows.Forms.Button();
            this.btnExecuteProject = new System.Windows.Forms.Button();
            this.cbListProjects = new System.Windows.Forms.ComboBox();
            this.pbimg = new System.Windows.Forms.PictureBox();
            this.btnViewDoc = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbimg)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnViewDoc, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnEditProjectsFrm, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnExecuteProject, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbListProjects, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbimg, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(975, 278);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // btnEditProjectsFrm
            // 
            this.btnEditProjectsFrm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditProjectsFrm.Font = new System.Drawing.Font("Segoe Script", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnEditProjectsFrm.Location = new System.Drawing.Point(490, 141);
            this.btnEditProjectsFrm.Name = "btnEditProjectsFrm";
            this.btnEditProjectsFrm.Size = new System.Drawing.Size(482, 44);
            this.btnEditProjectsFrm.TabIndex = 8;
            this.btnEditProjectsFrm.Text = "Editar projetos";
            this.btnEditProjectsFrm.UseVisualStyleBackColor = true;
            this.btnEditProjectsFrm.Click += new System.EventHandler(this.btnEditProjectsFrm_Click);
            // 
            // btnExecuteProject
            // 
            this.btnExecuteProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecuteProject.Font = new System.Drawing.Font("Segoe Script", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnExecuteProject.Location = new System.Drawing.Point(3, 141);
            this.btnExecuteProject.Name = "btnExecuteProject";
            this.btnExecuteProject.Size = new System.Drawing.Size(481, 44);
            this.btnExecuteProject.TabIndex = 6;
            this.btnExecuteProject.Text = "Execute";
            this.btnExecuteProject.UseVisualStyleBackColor = true;
            this.btnExecuteProject.Click += new System.EventHandler(this.btnExecuteProject_Click);
            // 
            // cbListProjects
            // 
            this.cbListProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.cbListProjects, 2);
            this.cbListProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListProjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbListProjects.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbListProjects.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbListProjects.FormattingEnabled = true;
            this.cbListProjects.ItemHeight = 30;
            this.cbListProjects.Location = new System.Drawing.Point(3, 97);
            this.cbListProjects.MaxDropDownItems = 30;
            this.cbListProjects.Name = "cbListProjects";
            this.cbListProjects.Size = new System.Drawing.Size(969, 38);
            this.cbListProjects.TabIndex = 5;
            this.cbListProjects.SelectedIndexChanged += new System.EventHandler(this.cbListProjects_SelectedIndexChanged);
            this.cbListProjects.SelectedValueChanged += new System.EventHandler(this.cbListProjects_SelectedValueChanged);
            // 
            // pbimg
            // 
            this.pbimg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel1.SetColumnSpan(this.pbimg, 2);
            this.pbimg.Image = global::ProjectGenerator.Properties.Resources.winformsapp;
            this.pbimg.Location = new System.Drawing.Point(437, 3);
            this.pbimg.Name = "pbimg";
            this.pbimg.Size = new System.Drawing.Size(100, 63);
            this.pbimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbimg.TabIndex = 9;
            this.pbimg.TabStop = false;
            // 
            // btnViewDoc
            // 
            this.btnViewDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnViewDoc, 2);
            this.btnViewDoc.Font = new System.Drawing.Font("Segoe Script", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnViewDoc.Location = new System.Drawing.Point(3, 210);
            this.btnViewDoc.Name = "btnViewDoc";
            this.btnViewDoc.Size = new System.Drawing.Size(969, 65);
            this.btnViewDoc.TabIndex = 10;
            this.btnViewDoc.Text = "Ver documentação";
            this.btnViewDoc.UseVisualStyleBackColor = true;
            this.btnViewDoc.Click += new System.EventHandler(this.btnViewDoc_Click);
            // 
            // ucProjetos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucProjetos";
            this.Size = new System.Drawing.Size(1012, 309);
            this.Load += new System.EventHandler(this.ucProjetos_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbimg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnExecuteProject;
        private System.Windows.Forms.ComboBox cbListProjects;
        private System.Windows.Forms.Button btnEditProjectsFrm;
        private System.Windows.Forms.PictureBox pbimg;
        private System.Windows.Forms.Button btnViewDoc;
    }
}
