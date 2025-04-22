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
    public partial class FrmLog : Form
    {
        public FrmLog()
        {
            InitializeComponent();
            dgvLog.DataSource = BlLog.LoadData();
        }

        private void btnGoToHome_Click(object sender, EventArgs e)
        {
            FrmHome obj=new FrmHome();
            this.Hide();
            obj.ShowDialog();
        }
         int LogId;
        private void dgvLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        LogId = Convert.ToInt32(dgvLog.Rows[e.RowIndex].Cells["LogId"].Value);
                        int check = BlLog.Delete(LogId);
                        if (check == 1)
                        {
                            dgvLog.DataSource = BlLog.LoadData();
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
