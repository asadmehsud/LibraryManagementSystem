using LibraryManagementSystem.BL;
using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class FrmProgramList : Form
    {
        public FrmProgramList()
        {
            InitializeComponent();
            if (FrmLogin.LibrarianRole == "Operator")
            {
                dgvProgramList.Columns[0].Visible = false;
                dgvProgramList.Columns[1].Visible = false;
            }
            try
            {
                dgvProgramList.DataSource = BlTblProgram.LoadData();
            }
            catch 
            {

            }
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProgramList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                int ProgramId = Convert.ToInt32(dgvProgramList.Rows[e.RowIndex].Cells["ProgramId"].Value);
                if(MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    BlTblProgram.Delete(ProgramId);
                    dgvProgramList.DataSource = BlTblProgram.LoadData();
                    BlLog log = new BlLog();
                    log.UserId = FrmLogin.LibrarianId;
                    log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Deleted a Program record successfully";
                    log.datetime = DateTime.Now;
                    BlLog.Save(log);
                }
            }
            else if (e.ColumnIndex == 0)
            {
                int ProgramId = Convert.ToInt32(dgvProgramList.Rows[e.RowIndex].Cells["ProgramId"].Value);
                FrmProgram ob = new FrmProgram();
                ob.Update(ProgramId);
                ob.ShowDialog();
                this.Close();
            }
        }

        private void btnAddProgram_Click(object sender, EventArgs e)
        {
            FrmProgram obj=new FrmProgram();
            this.Hide();
            obj.ShowDialog();
           
        }

        private void txtProgramName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Type", "Search");
                prm[1] = new SqlParameter("@ProgramName", txtProgramName.Text);
                dgvProgramList.DataSource = DataAccess.SpGetData("SpTblProgram", prm);
            }
            catch 
            {

            }
        }
    }
}
