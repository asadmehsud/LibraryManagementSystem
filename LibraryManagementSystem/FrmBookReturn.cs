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
    public partial class FrmBookReturn : Form
    {
        public FrmBookReturn()
        {
            InitializeComponent();
            LoadLibrarians();
            LoadStudents();
            LoadBooks();
            if (FrmBookReturnList.BookReturnId > 0)
            {
                ddlLibrarian.SelectedValue = FrmBookReturnList.LibrarianId;
                ddlBook.SelectedValue = FrmBookReturnList.BookId;
                ddlStudent.SelectedValue = FrmBookReturnList.StudentId;
            }
            dtReturnDate.Text = FrmBookReturnList.ReturnDate;
        }
        public void LoadLibrarians()
        {
            DataTable dt = BlLibrarian.LoadLibrarian();
            ddlLibrarian.DataSource = dt;
            ddlLibrarian.ValueMember = "LibrarianId";
            ddlLibrarian.DisplayMember = "LibrarianName";
        }
        public void LoadStudents()
        {
            DataTable dt = BlTblStudent.LoadStudent();
            ddlStudent.DataSource = dt;
            ddlStudent.ValueMember = "StudentId";
            ddlStudent.DisplayMember = "StudentName";
        }
        public void LoadBooks()
        {
            DataTable dt = BlTblBook.LoadData();
            ddlBook.DataSource = dt;
            ddlBook.ValueMember = "BookId";
            ddlBook.DisplayMember = "BookName";
        }
        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlLibrarian.Text == "")
            {
                lblLibrarian.Text = "Required";
            }
            else if (ddlStudent.Text == "")
            {
                lblStudent.Text = "Required";
            }
            else if (ddlBook.Text == "")
            {
                lblBook.Text = "Required";
            }
            else if (dtReturnDate.Text == "")
            {
                dtReturnDate.Text = "Required";
            }
            else
            {
                try
                {
                    if (FrmBookReturnList.BookReturnId > 0)
                    {
                        if (MessageBox.Show("Are You sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            BlTblBookReturn obj = new BlTblBookReturn();
                            obj.LibrarianId = Convert.ToInt32(ddlLibrarian.SelectedValue);
                            obj.StudentId = Convert.ToInt32(ddlStudent.SelectedValue);
                            obj.BookId = Convert.ToInt32(ddlBook.SelectedValue);
                            obj.ReturnDate = dtReturnDate.Value.ToString("Y");
                            obj.BookReturnId = FrmBookReturnList.BookReturnId;
                            if (BlTblBookReturn.Return(obj) == 1)
                            {
                                BlLog log = new BlLog();
                                log.UserId = FrmLogin.LibrarianId;
                                log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Updated a Bookreturn record successfully";
                                log.datetime = DateTime.Now;
                                BlLog.Save(log);
                                FrmBookReturnList.BookReturnId = 0;
                            }
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Are You sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            BlTblBookReturn obj = new BlTblBookReturn();
                            obj.LibrarianId = Convert.ToInt32(ddlLibrarian.SelectedValue);
                            obj.StudentId = Convert.ToInt32(ddlStudent.SelectedValue);
                            obj.BookId = Convert.ToInt32(ddlBook.SelectedValue);
                            obj.ReturnDate = dtReturnDate.Value.ToString("Y");
                            if (BlTblBookReturn.Return(obj) == 1)
                            {

                                DataTable dt = BlTblBook.LoadData(Convert.ToInt32(ddlBook.SelectedValue));
                                int stock = Convert.ToInt32(dt.Rows[0]["Stock"]);
                                stock++;
                                BlTblBook.UpdateStock(stock, Convert.ToInt32(ddlBook.SelectedValue));
                                BlLog log = new BlLog();
                                log.UserId = FrmLogin.LibrarianId;
                                log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Inserted a Bookreturn record successfully";
                                log.datetime = DateTime.Now;
                                BlLog.Save(log);
                                FrmBookReturnList.BookReturnId = 0;
                            }
                        }
                    }
                }
                catch 
                {

                }
            }
        }

        private void ddlLibrarian_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblLibrarian.Text = "";
        }

        private void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStudent.Text = "";
        }

        private void ddlBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblBook.Text = "";
        }

        private void lblList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBookReturnList.BookReturnId = 0;
            FrmBookReturnList list = new FrmBookReturnList();
            this.Hide();
            list.ShowDialog();
        }
    }
}
