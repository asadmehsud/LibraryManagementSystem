using LibraryManagementSystem.BL;
using LibraryManagementSystem.DAL;
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
    public partial class FrmCategoryList : Form
    {
        public FrmCategoryList()
        {
            InitializeComponent();
            if (FrmLogin.LibrarianRole == "Operator")
            {
                dgvCategoryList.Columns[0].Visible = false;
                dgvCategoryList.Columns[1].Visible = false;
            }
            try
            {
                dgvCategoryList.DataSource = BlTblCategory.LoadData();
            }
            catch
            {

            }
        }
          int CategoryId;
        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            FrmCategory obj = new FrmCategory();
            this.Hide();
            obj.ShowDialog();
        }

        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvCategoryList.DataSource = BlTblCategory.Searching(txtCategoryName.Text);
            }
            catch 
            {

            }
        }

        private void dgvCategoryList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CategoryId = Convert.ToInt32(dgvCategoryList.Rows[e.RowIndex].Cells["CategoryId"].Value);
                if (e.ColumnIndex == 1)
                {
                    if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        if (BlTblCategory.Delete(CategoryId) == 1)
                        {
                            dgvCategoryList.DataSource = BlTblCategory.LoadData();
                            BlLog log = new BlLog();
                            log.UserId = FrmLogin.LibrarianId;
                            log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Deleted a Category record successfully";
                            log.datetime = DateTime.Now;
                            BlLog.Save(log);
                        }

                    }


                }
                else if (e.ColumnIndex == 0)
                {
                    string Name;
                    int Status;
                    Name = Convert.ToString(dgvCategoryList.Rows[e.RowIndex].Cells["CategoryName"].Value);
                    Status = Convert.ToInt32(dgvCategoryList.Rows[e.RowIndex].Cells["Status"].Value);
                    FrmCategory obj = new FrmCategory();
                    obj.Edit(CategoryId, Name, Status);
                    this.Hide();
                    obj.ShowDialog();
                }
            }
            catch
            {

            }
        }
    }
}
