using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProjectGenerator.data;

namespace ProjectGenerator
{
    public partial class FormEditProj : Form
    {
        public FormEditProj()
        {
            InitializeComponent();
        }
        
        void GetLenDGV()
        {
            var ind = (dgvEditDataProj.RowCount > 0) ? (dgvEditDataProj.CurrentRow.Index + 1) : 0;
            var mlen = (dgvEditDataProj.RowCount > 0) ? dgvEditDataProj.RowCount : 0;
            tslLenProj.Text = ind + "/" + mlen;
        }

        List<Projects> SetOrderBy(List<Projects> list)
        {
            return list.OrderBy(x => x.Name).ToList();
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            this.Icon = new System.Drawing.Icon(Functions.GetDir() + @"\Resources\icons\winformsapp.ico");

            if (dgvEditDataProj.RowCount == 0)
            {
                var dt = Functions.GetDataJSON().ToList();
                dt = SetOrderBy(dt);
            
                dgvEditDataProj.DataSource = dt;
                dgvEditDataProj.MultiSelect = true;
                dgvEditDataProj.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
                if(dgvEditDataProj.RowCount > 0)
                {
                    dgvEditDataProj.ClearSelection();
                    dgvEditDataProj.Rows[dgvEditDataProj.CurrentRow.Index].Selected = true;
                    dgvEditDataProj.CurrentCell = dgvEditDataProj.Rows[dgvEditDataProj.CurrentRow.Index].Cells[0];
                }

                GetLenDGV();
            }
        }

        private void FormEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain fm = new FormMain();
            this.Hide();
            fm.Show();
        }

        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            if(dgvEditDataProj.DataSource != null)
            {
                List<Projects> li = (List<Projects>)dgvEditDataProj.DataSource;
                
                li.Add(new Projects() { 
                    Name = "myscript"+(dgvEditDataProj.RowCount+1), 
                    Desc = "myscript"+ (dgvEditDataProj.RowCount + 1), 
                    Script = "winforms_app_project.bat" 
                });

                li = SetOrderBy(li);

                dgvEditDataProj.DataSource = li;
                Functions.SaveDataJSON(li);
                
                if (dgvEditDataProj.RowCount > 0)
                {
                    dgvEditDataProj.ClearSelection();
                    dgvEditDataProj.Rows[dgvEditDataProj.CurrentRow.Index].Selected = true;
                    dgvEditDataProj.CurrentCell = dgvEditDataProj.Rows[dgvEditDataProj.CurrentRow.Index].Cells[0];
                }

                GetLenDGV();
            }
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEditDataProj.DataSource != null)
            {
                if (dgvEditDataProj.RowCount > 0)
                {
                    List<Projects> li = (List<Projects>)dgvEditDataProj.DataSource;
                    li = SetOrderBy(li);

                    dgvEditDataProj.DataSource = li;
                    Functions.SaveDataJSON(li);
                
                    dgvEditDataProj.ClearSelection();
                    dgvEditDataProj.Rows[dgvEditDataProj.CurrentRow.Index].Selected = true;
                    dgvEditDataProj.CurrentCell = dgvEditDataProj.Rows[dgvEditDataProj.CurrentRow.Index].Cells[0];
                }
                else
                {
                    MessageBox.Show("No rows to be edited!!!");
                }

                GetLenDGV();
            }
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEditDataProj.DataSource != null)
            {
                if (dgvEditDataProj.RowCount > 0)
                {
                    List<Projects> li = (List<Projects>)dgvEditDataProj.DataSource;
                
                    if (dgvEditDataProj.SelectedRows.Count > 0)
                    {
                        foreach (DataGridViewRow row in dgvEditDataProj.SelectedRows)
                        {
                            if(!row.IsNewRow && row.Index != -1)
                            {
                                li.RemoveAt(row.Index);
                            }
                        }
                    }

                    li = SetOrderBy(li);

                    dgvEditDataProj.DataSource = li;
                    Functions.SaveDataJSON(li);
                
                    if(dgvEditDataProj.RowCount > 0)
                    {
                        dgvEditDataProj.ClearSelection();
                        dgvEditDataProj.Rows[dgvEditDataProj.CurrentRow.Index].Selected = true;
                        dgvEditDataProj.CurrentCell = dgvEditDataProj.Rows[dgvEditDataProj.CurrentRow.Index].Cells[0];
                    }
                } 
                else
                {
                    MessageBox.Show("No rows to be deleted!!!");
                }

                GetLenDGV();
            }
        }

        private void dgvEditDataProj_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvEditDataProj_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvEditDataProj_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetLenDGV();
        }

        private void dgvEditDataProj_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            GetLenDGV();
        }

        private void dgvEditDataProj_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            GetLenDGV();
        }

        private void tslLoadDefData_Click(object sender, EventArgs e)
        {
            var dt = Functions.GetDefDataJSON().ToList();
            dt = SetOrderBy(dt);

            dgvEditDataProj.DataSource = dt;
            Functions.SaveDataJSON(dt);
            
            if (dgvEditDataProj.RowCount > 0)
            {
                dgvEditDataProj.Rows[dgvEditDataProj.CurrentRow.Index].Selected = true;
                dgvEditDataProj.CurrentCell = dgvEditDataProj.Rows[dgvEditDataProj.CurrentRow.Index].Cells[0];
            }
            
            GetLenDGV();
        }

        private void tsbtnFirst_Click(object sender, EventArgs e)
        {
            if(dgvEditDataProj.RowCount > 0)
            {
                var firstlen = dgvEditDataProj.RowCount - dgvEditDataProj.RowCount;
                dgvEditDataProj.ClearSelection();
                dgvEditDataProj.Rows[firstlen].Selected = true;
                dgvEditDataProj.CurrentCell = dgvEditDataProj.Rows[firstlen].Cells[0];
                GetLenDGV();
            }
        }

        private void tsbtnPrev_Click(object sender, EventArgs e)
        {
            if (dgvEditDataProj.RowCount > 0)
            {
                var prevlen = (dgvEditDataProj.CurrentRow.Index > 0) ? dgvEditDataProj.CurrentRow.Index - 1 : dgvEditDataProj.CurrentRow.Index;
                dgvEditDataProj.ClearSelection();
                dgvEditDataProj.Rows[prevlen].Selected = true;
                dgvEditDataProj.CurrentCell = dgvEditDataProj.Rows[prevlen].Cells[0];
                GetLenDGV();
            }
        }

        private void tsbtnNext_Click(object sender, EventArgs e)
        {
            if (dgvEditDataProj.RowCount > 0)
            {
                var nextlen = (dgvEditDataProj.CurrentRow.Index < (dgvEditDataProj.RowCount - 1)) ? dgvEditDataProj.CurrentRow.Index + 1 : dgvEditDataProj.CurrentRow.Index;
                dgvEditDataProj.ClearSelection();
                dgvEditDataProj.Rows[nextlen].Selected = true;
                dgvEditDataProj.CurrentCell = dgvEditDataProj.Rows[nextlen].Cells[0];
                GetLenDGV();
            }
        }

        private void tsbtnLast_Click(object sender, EventArgs e)
        {
            if (dgvEditDataProj.RowCount > 0)
            {
                var lastlen = dgvEditDataProj.RowCount - 1;
                dgvEditDataProj.ClearSelection();
                dgvEditDataProj.Rows[lastlen].Selected = true;
                dgvEditDataProj.CurrentCell = dgvEditDataProj.Rows[lastlen].Cells[0];
                GetLenDGV();
            }
        }

        private void tstbSearch_Click(object sender, EventArgs e)
        {
           
        }

        private void tstbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (dgvEditDataProj.DataSource != null)
            {
                var dt = Functions.GetDataJSON().ToList();
                dt = SetOrderBy(dt);
                dt = dt.Where(x => x.Name.Contains(tstbSearch.Text)).ToList();
                dgvEditDataProj.DataSource = null;
                dgvEditDataProj.DataSource = dt;
                GetLenDGV();

                if (dgvEditDataProj.RowCount > 0)
                {
                    dgvEditDataProj.ClearSelection();
                    dgvEditDataProj.Rows[dgvEditDataProj.CurrentRow.Index].Selected = true;
                    dgvEditDataProj.CurrentCell = dgvEditDataProj.Rows[dgvEditDataProj.CurrentRow.Index].Cells[0];
                }
            }
        }
    }
}
