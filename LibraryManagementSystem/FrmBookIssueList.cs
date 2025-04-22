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
    public partial class FrmBookIssueList : Form
    {
        public FrmBookIssueList()
        {
            InitializeComponent();
            if (FrmLogin.LibrarianRole=="Operator")
            {
                dgvBookIssueList.Columns[0].Visible = false;
                dgvBookIssueList.Columns[1].Visible = false;
            }
            try
            {
                dgvBookIssueList.DataSource = BlTblBookIssue.LoadData();
            }
            catch
            {

            }
        }
        public static int LibrarianId, BookId, StudentId, BookIssueId;

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            FrmBookIssue obj=new FrmBookIssue();
            this.Hide();
            obj.ShowDialog();
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvBookIssueList.DataSource = BlTblBookIssue.Searching(txtBookName.Text);
            }
            catch 
            {

            }
        }

        public static string IssueDate;
        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvBookIssueList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                BookIssueId = Convert.ToInt32(dgvBookIssueList.Rows[e.RowIndex].Cells["BookIssueId"].Value);
                if (e.ColumnIndex==0)
                {
                    LibrarianId = Convert.ToInt32(dgvBookIssueList.Rows[e.RowIndex].Cells["LibrarianId"].Value);
                    StudentId = Convert.ToInt32(dgvBookIssueList.Rows[e.RowIndex].Cells["StudentId"].Value);
                    BookId = Convert.ToInt32(dgvBookIssueList.Rows[e.RowIndex].Cells["BookId"].Value);
                    IssueDate = Convert.ToString(dgvBookIssueList.Rows[e.RowIndex].Cells["IssueDate"].Value);
                    FrmBookIssue obj= new FrmBookIssue();
                    this.Hide();
                    obj.ShowDialog();

                }
                else if (e.ColumnIndex==1)
                {
                    if (MessageBox.Show("Are You sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        int check = BlTblBookIssue.Delete(BookIssueId);
                        if (check==1)
                        {
                            dgvBookIssueList.DataSource = BlTblBookIssue.LoadData();
                            BlLog log = new BlLog();
                            log.UserId = FrmLogin.LibrarianId;
                            log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Deleted a BookIssue record successfully";
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
