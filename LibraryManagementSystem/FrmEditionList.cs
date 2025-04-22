using LibraryManagementSystem.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class FrmEditionList : Form
    {
        public FrmEditionList()
        {
            InitializeComponent();
            if (FrmLogin.LibrarianRole == "Operator")
            {
                dgvEditionList.Columns[0].Visible = false;
                dgvEditionList.Columns[1].Visible = false;
            }
            try
            {
                dgvEditionList.DataSource = BlTblEdition.LoadData();
            }
            catch 
            {

            }
        }
          int EditionId;
        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEditionName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvEditionList.DataSource = BlTblEdition.Searching(txtEditionName.Text);
            }
            catch
            {

            }
        }

        private void dgvEditionList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                EditionId = Convert.ToInt32(dgvEditionList.Rows[e.RowIndex].Cells["EditionId"].Value);
                if (e.ColumnIndex == 1)
                {
                    if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        if (BlTblEdition.Delete(EditionId) == 1)
                        {
                            dgvEditionList.DataSource = BlTblEdition.LoadData();
                            BlLog log = new BlLog();
                            log.UserId = FrmLogin.LibrarianId;
                            log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Deleted an Edition record successfully";
                            log.datetime = DateTime.Now;
                            BlLog.Save(log);
                        }
                    }
                }
                else if (e.ColumnIndex == 0)
                {
                    string Name;
                    int Status;
                    EditionId = Convert.ToInt32(dgvEditionList.Rows[e.RowIndex].Cells["EditionId"].Value);
                    Name = Convert.ToString(dgvEditionList.Rows[e.RowIndex].Cells["EditionName"].Value);
                    Status = Convert.ToInt32(dgvEditionList.Rows[e.RowIndex].Cells["Status"].Value);
                    FrmEdition obj = new FrmEdition();
                    obj.Edit(EditionId, Name, Status);
                    this.Hide();
                    obj.ShowDialog();
                }
            }
            catch
            {


            }
        }

        private void btnAddEdition_Click(object sender, EventArgs e)
        {
            FrmEdition obj = new FrmEdition();
            this.Hide();
            obj.ShowDialog();
        }
    }
}
