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
    public partial class FrmLanguageList : Form
    {
        public FrmLanguageList()
        {
            InitializeComponent();
            if (FrmLogin.LibrarianRole == "Operator")
            {
                dgvLanguageList.Columns[0].Visible = false;
                dgvLanguageList.Columns[1].Visible = false;
            }
            try
            {
                dgvLanguageList.DataSource = BlTblLanguage.LoadData();
            }
            catch
            {

            }
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int id;
        private void dgvLanguageList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dgvLanguageList.Rows[e.RowIndex].Cells["LanguageId"].Value);
                if (e.ColumnIndex == 1)
                {
                    if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        if (BlTblLanguage.Delete(id) == 1)
                        {
                            dgvLanguageList.DataSource = BlTblLanguage.LoadData();
                            BlLog log = new BlLog();
                            log.UserId = FrmLogin.LibrarianId;
                            log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Deleted a Language record successfully";
                            log.datetime = DateTime.Now;
                            BlLog.Save(log);
                        }
                    }
                }
                else if (e.ColumnIndex == 0)
                {
                    string Name;
                    int Status;
                    Name = Convert.ToString(dgvLanguageList.Rows[e.RowIndex].Cells["LanguageName"].Value);
                    Status = Convert.ToInt32(dgvLanguageList.Rows[e.RowIndex].Cells["Status"].Value);
                    FrmLanguage obj = new FrmLanguage();
                    obj.Edit(id, Name, Status);
                    this.Hide();
                    obj.ShowDialog();
                }
            }
            catch
            {


            }
        }

        private void txtLanguage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvLanguageList.DataSource = BlTblLanguage.Searching(txtLanguage.Text);
            }
            catch
            {

            }
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {
            FrmLanguage obj = new FrmLanguage();
            this.Hide();
            obj.ShowDialog();
        }
    }
}
