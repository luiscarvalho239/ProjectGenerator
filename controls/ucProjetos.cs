using ProjectGenerator.data;
using ProjectGenerator.features;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ProjectGenerator
{
    public partial class ucProjetos : UserControl
    {
        Projects[] pjson;

        public ucProjetos()
        {
            InitializeComponent();
            pbimg.SizeMode = PictureBoxSizeMode.StretchImage;
            if (cbListProjects.Items.Count == 0)
            {
                pjson = Functions.GetDataJSON();
            }
        }

        public string GetIconFromCBO()
        {
            var val_scr = pjson[cbListProjects.SelectedIndex].Name;
            return Functions.GetIcon(val_scr);
        }

        void LoadItems()
        {
            if (cbListProjects.Items.Count == 0)
            {
                pjson = pjson.OrderBy(x => x.Name).ToArray();
                cbListProjects.DisplayImagesAndText(pjson);

                if (cbListProjects.Items.Count > 0)
                {
                    cbListProjects.DropDownHeight = pjson.Length * 15;

                    if (cbListProjects.SelectedIndex == -1)
                    {
                        cbListProjects.SelectedIndex = 0;
                    }
                }
            }
        }

        void RunProject()
        {
            if (cbListProjects.Items.Count > 0 && cbListProjects.SelectedIndex != -1)
            {
                var val_scr = cbListProjects.SelectedValue.ToString();
                Functions.StartScript(val_scr);
            }
        }

        void ViewDocProject()
        {
            if (cbListProjects.Items.Count > 0 && cbListProjects.SelectedIndex != -1)
            {
                var val_scr = pjson[cbListProjects.SelectedIndex].Doc_Url;
                Functions.ViewDoc(val_scr);
            }
        }

        void ShowEditProjects()
        {
            FormEditProj fe = new FormEditProj();
            Form.ActiveForm.Hide();
            fe.Show();
        }

        private void ucProjetos_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void cbListProjects_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbListProjects_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbListProjects.Items.Count > 0 && cbListProjects.SelectedIndex != -1)
            {
                pbimg.Load(GetIconFromCBO());
            }
        }

        private void btnExecuteProject_Click(object sender, EventArgs e)
        {
            RunProject();
        }

        private void btnEditProjectsFrm_Click(object sender, EventArgs e)
        {
            ShowEditProjects();
        }

        private void btnViewDoc_Click(object sender, EventArgs e)
        {
            ViewDocProject();
        }
    }
}
