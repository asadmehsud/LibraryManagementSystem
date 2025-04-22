using LibraryManagementSystem.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class FrmBookReturnList : Form
    {
        public FrmBookReturnList()
        {
            InitializeComponent();
            if (FrmLogin.LibrarianRole == "Operator")
            {
                dgvReturnBookList.Columns[0].Visible = false;
                dgvReturnBookList.Columns[1].Visible = false;
            }
            try
            {
                dgvReturnBookList.DataSource = BlTblBookReturn.LoadData();
            }
            catch 
            {
              
            }
        }
        public static int LibrarianId, BookId, StudentId, BookReturnId;

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            FrmBookReturn obj=new FrmBookReturn();
            this.Hide();
            obj.ShowDialog();
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvReturnBookList.DataSource=BlTblBookReturn.Searching(txtBookName.Text);
            }
            catch 
            {

            }
        }

        public static string ReturnDate;
        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvReturnBookList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                BookReturnId = Convert.ToInt32(dgvReturnBookList.Rows[e.RowIndex].Cells["BookReturnId"].Value);
                if (e.ColumnIndex == 0)
                {
                    LibrarianId = Convert.ToInt32(dgvReturnBookList.Rows[e.RowIndex].Cells["LibrarianId"].Value);
                    StudentId = Convert.ToInt32(dgvReturnBookList.Rows[e.RowIndex].Cells["StudentId"].Value);
                    BookId = Convert.ToInt32(dgvReturnBookList.Rows[e.RowIndex].Cells["BookId"].Value);
                    ReturnDate = Convert.ToString(dgvReturnBookList.Rows[e.RowIndex].Cells["ReturnDate"].Value);
                    FrmBookReturn obj = new FrmBookReturn();
                    this.Hide();
                    obj.ShowDialog();

                }
                else if (e.ColumnIndex == 1)
                {
                    if (MessageBox.Show("Are You sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        int check = BlTblBookReturn.Delete(BookReturnId);
                        if (check == 1)
                        {
                            dgvReturnBookList.DataSource = BlTblBookReturn.LoadData();
                            BlLog log = new BlLog();
                            log.UserId = FrmLogin.LibrarianId;
                            log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Deleted a Bookreturn record successfully";
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
