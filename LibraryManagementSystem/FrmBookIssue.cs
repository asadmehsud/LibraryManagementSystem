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
    public partial class FrmBookIssue : Form
    {
        public FrmBookIssue()
        {
            InitializeComponent();
            LoadLibrarians();
            LoadStudents();
            LoadBooks();
            if (FrmBookIssueList.BookIssueId > 0)
            {
                ddlLibrarian.SelectedValue = FrmBookIssueList.LibrarianId;
                ddlBook.SelectedValue = FrmBookIssueList.BookId;
                ddlStudent.SelectedValue = FrmBookIssueList.StudentId;
            }
            dtIssueDate.Text = FrmBookIssueList.IssueDate;
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
            int StudentId =Convert.ToInt32(BlTblStudent.LoadMaxStId().Rows[0]["StudentId"]);
         
            ddlStudent.SelectedValue= StudentId;
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
            else if (dtIssueDate.Text == "")
            {
                lblIssueDate.Text = "Required";
            }
            else
            {
                try
                {
                    if (FrmBookIssueList.BookIssueId > 0)
                    {
                        if (BlTblBook.LoadData(Convert.ToInt32(ddlBook.SelectedValue)).Rows.Count == 00)
                        {
                            MessageBox.Show("This Book is unavailabe");
                        }
                        else
                        {
                            if (MessageBox.Show("Are You sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                BlTblBookIssue obj = new BlTblBookIssue();
                                obj.LibrarianId = Convert.ToInt32(ddlLibrarian.SelectedValue);
                                obj.StudentId = Convert.ToInt32(ddlStudent.SelectedValue);
                                obj.BookId = Convert.ToInt32(ddlBook.SelectedValue);
                                obj.IssueDate = dtIssueDate.Value.ToString("Y");
                                obj.BookIssueId = FrmBookIssueList.BookIssueId;
                                if (BlTblBookIssue.Issue(obj) == 1)
                                {
                                    BlLog log = new BlLog();
                                    log.UserId = FrmLogin.LibrarianId;
                                    log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Updated a BookIssue record successfully";
                                    log.datetime = DateTime.Now;
                                    BlLog.Save(log);
                                    FrmBookIssueList.BookIssueId = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        DataTable dt = BlTblBook.LoadData(Convert.ToInt32(ddlBook.SelectedValue));
                        int stock = Convert.ToInt32(dt.Rows[0]["Stock"]);
                        if (stock == 00)
                        {
                            MessageBox.Show("This Book is not available");
                        }
                        else
                        {
                            if (MessageBox.Show("Are You sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                BlTblBookIssue obj = new BlTblBookIssue();
                                obj.LibrarianId = Convert.ToInt32(ddlLibrarian.SelectedValue);
                                obj.StudentId = Convert.ToInt32(ddlStudent.SelectedValue);
                                obj.BookId = Convert.ToInt32(ddlBook.SelectedValue);
                                obj.IssueDate = dtIssueDate.Value.ToString("Y");
                                if (BlTblBookIssue.Issue(obj) == 1)
                                {
                                    stock--;
                                    BlTblBook.UpdateStock(stock, Convert.ToInt32(ddlBook.SelectedValue));
                                    BlLog log = new BlLog();
                                    log.UserId = FrmLogin.LibrarianId;
                                    log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Inseretd a BookIssue record successfully";
                                    log.datetime = DateTime.Now;
                                    BlLog.Save(log);
                                }

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
            lblLibrarian.Text = "";
        }

        private void ddlBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblLibrarian.Text = "";
        }

        private void lblList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBookIssueList.BookIssueId = 0;
            FrmBookIssueList obj = new FrmBookIssueList();
            this.Hide();
            obj.ShowDialog();
        }
    }
}
