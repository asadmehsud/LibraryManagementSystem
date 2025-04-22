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
    public partial class FrmBookList : Form
    {
        public FrmBookList()
        {
            InitializeComponent();
            try
            {
                dgvBookList.DataSource = BlTblBook.LoadData();
            }
            catch 
            {

            }
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static string BookName, Description, Date;

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            FrmBook obj=new FrmBook();
            this.Hide();
            obj.ShowDialog();
        }

        public static int BookId, CategoryId, LanguageId, Authorid, EditionId;

        private void dgvBookList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvBookList.DataSource = BlTblBook.Searching(txtBookName.Text);
            }
            catch 
            {

            }
        }

        public static string Stock;
        public static byte[] PictureInByte;
       
        private void dgvBookList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                BookId = Convert.ToInt32(dgvBookList.Rows[e.RowIndex].Cells["BookId"].Value);
                if (e.ColumnIndex == 0)
                {
                    BookName = Convert.ToString(dgvBookList.Rows[e.RowIndex].Cells["BookName"].Value);
                    CategoryId = Convert.ToInt32(dgvBookList.Rows[e.RowIndex].Cells["CategoryId"].Value);
                    LanguageId = Convert.ToInt32(dgvBookList.Rows[e.RowIndex].Cells["LanguageId"].Value);
                    EditionId = Convert.ToInt32(dgvBookList.Rows[e.RowIndex].Cells["EditionId"].Value);
                    Authorid = Convert.ToInt32(dgvBookList.Rows[e.RowIndex].Cells["AuthorId"].Value);
                    Stock = Convert.ToString(dgvBookList.Rows[e.RowIndex].Cells["Stock"].Value);
                    Description = Convert.ToString(dgvBookList.Rows[e.RowIndex].Cells["Description"].Value);
                    PictureInByte =(byte[])( dgvBookList.Rows[e.RowIndex].Cells["Image"].Value);
                    FrmBook obj=new FrmBook();
                    this.Hide();
                    obj.ShowDialog();
                }
                else if (e.ColumnIndex == 1)
                {
                    if (MessageBox.Show("Are you sure!","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation)==DialogResult.Yes)
                    {
                        int check = BlTblBook.Delete(BookId);
                        if (check == 1)
                        {
                            dgvBookList.DataSource = BlTblBook.LoadData();
                            BlLog log = new BlLog();
                            log.UserId = FrmLogin.LibrarianId;
                            log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Deleted a Book record successfully";
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
