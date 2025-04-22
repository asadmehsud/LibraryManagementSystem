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
    public partial class FrmDepartmentList : Form
    {
        public FrmDepartmentList()
        {
            InitializeComponent();
            if (FrmLogin.LibrarianRole == "Operator")
            {
                dgvDepartmentList.Columns[0].Visible = false;
                dgvDepartmentList.Columns[1].Visible = false;
            }
            try
            {
                dgvDepartmentList.DataSource = BlTblDepartment.LoadData();
            }
            catch 
            {

            }
        }
        public static string DepartmentName, Status;
        public static byte[] PictureInByte;
        public static int DepartmentId;
        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDepartment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvDepartmentList.DataSource=BlTblDepartment.Searching(txtDepartment.Text);
            }
            catch 
            {

            }
        }

        private void dgvDepartmentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DepartmentId = Convert.ToInt32(dgvDepartmentList.Rows[e.RowIndex].Cells["DepartmentId"].Value);
                if (e.ColumnIndex==0)
                {
                    DepartmentName = Convert.ToString(dgvDepartmentList.Rows[e.RowIndex].Cells["DepartmentName"].Value);
                    Status = Convert.ToString(dgvDepartmentList.Rows[e.RowIndex].Cells["Status"].Value);
                    PictureInByte = (byte[])(dgvDepartmentList.Rows[e.RowIndex].Cells["Image"].Value);
                    FrmDepartment obj = new FrmDepartment();
                    this.Hide();
                    obj.ShowDialog();

                }
                else if (e.ColumnIndex==1)
                {
                    if (MessageBox.Show("Are you sure!","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation)==DialogResult.Yes)
                    {
                        int check = BlTblDepartment.Delete(DepartmentId);
                        if (check==1)
                        {
                            dgvDepartmentList.DataSource = BlTblDepartment.LoadData();
                            BlLog log = new BlLog();
                            log.UserId = FrmLogin.LibrarianId;
                            log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Deleted a Department record successfully";
                            log.datetime = DateTime.Now;
                            BlLog.Save(log);
                        }
                    }
                }
            }
            catch 
            {

            }
        }
    }
}
