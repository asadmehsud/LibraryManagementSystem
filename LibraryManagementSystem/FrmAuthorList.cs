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
    public partial class FrmAuthorList : Form
    {
        public FrmAuthorList()
        {
            InitializeComponent();
            if (FrmLogin.LibrarianRole == "Operator")
            {
                dgvAuthorList.Columns[0].Visible = false;
                dgvAuthorList.Columns[1].Visible = false;
            }
            try
            {
                dgvAuthorList.DataSource = BlTblAuthor.LoadData();
            }
            catch 
            {

            }
        }
        public static byte[] PictureInByte;
        public static string AuthorName;
        int AuthorId;
        public static int Status;
        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dgvAuthorList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                AuthorId = Convert.ToInt32(dgvAuthorList.Rows[e.RowIndex].Cells["AuthorId"].Value);
                if (e.ColumnIndex == 1)
                {
                    if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        if (BlTblAuthor.Delete(AuthorId) == 1)
                        {
                            dgvAuthorList.DataSource = BlTblAuthor.LoadData();
                            BlLog log = new BlLog();
                            log.UserId = FrmLogin.LibrarianId;
                            log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Deleted an Author record successfully";
                            log.datetime = DateTime.Now;
                            BlLog.Save(log);
                        }
                    }

                }
                else if (e.ColumnIndex == 0)
                {

                    AuthorName = Convert.ToString(dgvAuthorList.Rows[e.RowIndex].Cells["AuthorName"].Value);
                    Status = Convert.ToInt32(dgvAuthorList.Rows[e.RowIndex].Cells["Status"].Value);
                    PictureInByte = (byte[])(dgvAuthorList.Rows[e.RowIndex].Cells["Image"].Value);
                    FrmAuthor obj = new FrmAuthor();
                    obj.Edit(AuthorId, AuthorName, Status);
                    this.Hide();
                    obj.ShowDialog();
                }
            }
            catch
            {

            }

        }

        private void btnAuthor_Click(object sender, EventArgs e)
        {
            FrmAuthor obj = new FrmAuthor();
            this.Hide();
            obj.ShowDialog();
        }

        private void txtAuthorName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvAuthorList.DataSource = BlTblAuthor.Searching(txtAuthorName.Text);
            }
            catch 
            {

            }
        }
    }
}
