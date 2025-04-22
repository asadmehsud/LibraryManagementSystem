using LibraryManagementSystem.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class FrmLibrarianList : Form
    {
        public FrmLibrarianList()
        {
            InitializeComponent();
            if (FrmLogin.LibrarianRole == "Operator")
            {
                dgvLibrarianList.Columns[0].Visible = false;
                dgvLibrarianList.Columns[1].Visible = false;
            }
            try
            {
                dgvLibrarianList.DataSource = BlLibrarian.GetData();
            }
            catch
            {

            }
        }
        public static string FirstName, LastName, Username, Email, MobileNo, Cnic, Role, Password, Address;
        public static byte[] PictureInByte;
        public static Image GetImageForUpdate(byte[] img)
        {
            MemoryStream stream = new MemoryStream(img);
            return Image.FromStream(stream);
        }

        private void btnAddLibrarian_Click(object sender, EventArgs e)
        {
            FrmLibrarianRegistration obj = new FrmLibrarianRegistration();
            this.Hide();
            obj.ShowDialog();
        }

        private void txtCnic_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvLibrarianList.DataSource = BlLibrarian.Searching("Cnic", txtCnic.Text);
            }
            catch 
            {

            }
        }

        private void txtMobileNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvLibrarianList.DataSource = BlLibrarian.Searching("MobileNo", txtMobileNo.Text);
            }
            catch
            {

            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvLibrarianList.DataSource = BlLibrarian.Searching("Email", txtEmail.Text);
            }
            catch
            {

            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvLibrarianList.DataSource = BlLibrarian.Searching("UserName", txtUserName.Text);
            }
            catch
            {

            }
        }

        private void dgvLibrarianList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LibrarianId = Convert.ToInt32(dgvLibrarianList.Rows[e.RowIndex].Cells["LibrarianId"].Value);
                if (e.ColumnIndex == 0)
                {
                    FirstName = "" + dgvLibrarianList.Rows[e.RowIndex].Cells["FirstName"].Value;
                    LastName = "" + dgvLibrarianList.Rows[e.RowIndex].Cells["LastName"].Value;
                    Username = "" + dgvLibrarianList.Rows[e.RowIndex].Cells["UserName"].Value;
                    Email = "" + dgvLibrarianList.Rows[e.RowIndex].Cells["Email"].Value;
                    MobileNo = "" + dgvLibrarianList.Rows[e.RowIndex].Cells["MobileNo"].Value;
                    Cnic = "" + dgvLibrarianList.Rows[e.RowIndex].Cells["Cnic"].Value;
                    Role = "" + dgvLibrarianList.Rows[e.RowIndex].Cells["Role"].Value;
                    Password = "" + dgvLibrarianList.Rows[e.RowIndex].Cells["Password"].Value;
                    Address = "" + dgvLibrarianList.Rows[e.RowIndex].Cells["Address"].Value;
                    PictureInByte =(byte[]) (dgvLibrarianList.Rows[e.RowIndex].Cells["Image"].Value);
                    FrmLibrarianRegistration frmLibrarianRegistration = new FrmLibrarianRegistration();
                    this.Hide();
                    frmLibrarianRegistration.ShowDialog();
                }
                else if (e.ColumnIndex == 1)
                {
                    if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {

                        int check = BlLibrarian.Delete(LibrarianId);
                        if (check > 0)
                        {
                            dgvLibrarianList.DataSource = BlLibrarian.GetData();
                            BlLog log = new BlLog();
                            log.UserId = FrmLogin.LibrarianId;
                            log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Deleted a User record successfully";
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



        public static int LibrarianId;
        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
