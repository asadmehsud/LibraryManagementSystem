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
    public partial class FrmStudentList : Form
    {
        public FrmStudentList()
        {
            InitializeComponent();
            if (FrmLogin.LibrarianRole == "Operator")
            {
                dgvStudentList.Columns[0].Visible = false;
                dgvStudentList.Columns[1].Visible = false;
            }
            try
            {
                dgvStudentList.DataSource = BlTblStudent.LoadData();
            }
            catch 
            {

            }
        }
        public static string StudentName, FatherName, RollNo, Contact, Cnic, FatherCnic, Gender, Address;

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            FrmStudent obj=new FrmStudent();
            this.Hide();
            obj.ShowDialog();
        }

        public static int StudentId, DepartmentId, SessionId, ProgramId;
        public static byte[] PictureInByte;
        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvStudentList.DataSource = BlTblStudent.Searching("ContactNo",txtContactNo.Text);
            }
            catch
            {

            }
        }

        private void txtStudentName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvStudentList.DataSource = BlTblStudent.Searching("StudentName", txtStudentName.Text);
            }
            catch
            {

            }
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvStudentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                StudentId = Convert.ToInt32(dgvStudentList.Rows[e.RowIndex].Cells["StudentId"].Value);
                if (e.ColumnIndex==0)
                {
                    StudentName = Convert.ToString(dgvStudentList.Rows[e.RowIndex].Cells["StudentName"].Value);
                    DepartmentId = Convert.ToInt32(dgvStudentList.Rows[e.RowIndex].Cells["DepartmentId"].Value);
                    ProgramId = Convert.ToInt32(dgvStudentList.Rows[e.RowIndex].Cells["Program"].Value);
                    SessionId = Convert.ToInt32(dgvStudentList.Rows[e.RowIndex].Cells["SessionId"].Value);
                    FatherName = Convert.ToString(dgvStudentList.Rows[e.RowIndex].Cells["FatherName"].Value);
                    RollNo = Convert.ToString(dgvStudentList.Rows[e.RowIndex].Cells["RollNO"].Value);
                    Contact = Convert.ToString(dgvStudentList.Rows[e.RowIndex].Cells["ContactNo"].Value);
                    Address = Convert.ToString(dgvStudentList.Rows[e.RowIndex].Cells["Address"].Value);
                    Cnic = Convert.ToString(dgvStudentList.Rows[e.RowIndex].Cells["Cnic"].Value);
                    Gender = Convert.ToString(dgvStudentList.Rows[e.RowIndex].Cells["Gender"].Value);
                    FatherCnic = Convert.ToString(dgvStudentList.Rows[e.RowIndex].Cells["FatherCnic"].Value);
                    PictureInByte = (byte[])(dgvStudentList.Rows[e.RowIndex].Cells["Image"].Value);
                    FrmStudent obj=new FrmStudent();
                    this.Hide();
                    obj.ShowDialog();

                }
                else if (e.ColumnIndex==1) 
                {
                    int check = BlTblStudent.Delete(StudentId);
                    if (check==1)
                    {
                        if (MessageBox.Show("Are you sure!","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation)==DialogResult.Yes)
                        {
                            dgvStudentList.DataSource = BlTblStudent.LoadData();
                            BlLog log = new BlLog();
                            log.UserId = FrmLogin.LibrarianId;
                            log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Deleted a student record successfully";
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
