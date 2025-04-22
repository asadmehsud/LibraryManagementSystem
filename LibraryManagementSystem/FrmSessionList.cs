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
    public partial class FrmSessionList : Form
    {
        public FrmSessionList()
        {
            InitializeComponent();
            if (FrmLogin.LibrarianRole == "Operator")
            {
                dgvSessionList.Columns[0].Visible = false;
                dgvSessionList.Columns[1].Visible = false;
            }
            try
            {
                dgvSessionList.DataSource = BlTblSession.LoadData();
            }
            catch
            {

            }
        }
        string Session; int SessionId, Status;
        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSessionList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SessionId = Convert.ToInt32(dgvSessionList.Rows[e.RowIndex].Cells["SessionId"].Value);
                if (e.ColumnIndex == 1)
                {
                    if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        if (BlTblSession.Delete(SessionId) == 1)
                        {
                            dgvSessionList.DataSource = BlTblSession.LoadData();
                            BlLog log = new BlLog();
                            log.UserId = FrmLogin.LibrarianId;
                            log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Deleted a Session record successfully";
                            log.datetime = DateTime.Now;
                            BlLog.Save(log);
                        }
                    }
                }
                else if (e.ColumnIndex == 0)
                {
                    Session = "" + dgvSessionList.Rows[e.RowIndex].Cells["SessionName"].Value;
                    Status = Convert.ToInt32(dgvSessionList.Rows[e.RowIndex].Cells["Status"].Value);
                    FrmSession ob = new FrmSession();
                    ob.Update(SessionId, Session, Status);
                    this.Hide();
                    ob.ShowDialog();
                }
            }
            catch
            {

            }
        }

        private void txtSession_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvSessionList.DataSource = BlTblSession.Searching(txtSession.Text);
            }
            catch
            {

            }
        }

        private void btnAddSession_Click(object sender, EventArgs e)
        {
            FrmSession obj = new FrmSession();
            this.Hide();
            obj.ShowDialog();
        }
    }
}
