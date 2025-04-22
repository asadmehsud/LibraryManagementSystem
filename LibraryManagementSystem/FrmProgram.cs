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
    public partial class FrmProgram : Form
    {
        public FrmProgram()
        {
            InitializeComponent();
        }
        BlTblProgram Program = new BlTblProgram();
         int ProgramID;

        public void Update(int programId)
        {
            ProgramID = programId;
            DataTable dt = BlTblProgram.LoadData(ProgramID);
            if(dt.Rows.Count > 0 )
            {
                txtProgramName.Text = dt.Rows[0]["ProgramName"].ToString();
                int Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                if(Status==1)
                {
                    ddlStatus.Text = "Active";
                }
                else if(Status==0) {

                    ddlStatus.Text = "InActive";
                } 
            }
             btnSubmit.Text = "Update";
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtProgramName.Text=="")
            {
                lblProgram.Text = "Required";
            }
            else if (ddlStatus.Text=="")
            {
                lblStatus.Text = "Required";
            }
            else
            {
                try
                {
                    Program.ProgramId = ProgramID;
                    Program.ProgramName = txtProgramName.Text;
                    Program.Status = ddlStatus.Text;

                    if (btnSubmit.Text == "Update")
                    {
                        DataTable dt = BlTblProgram.CheckProgram(ProgramID, txtProgramName.Text);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("This Program Already Exist");
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                BlTblProgram.Submit(Program);
                                BlLog log = new BlLog();
                                log.UserId = FrmLogin.LibrarianId;
                                log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Updated a Program record successfully";
                                log.datetime = DateTime.Now;
                                BlLog.Save(log);
                                txtProgramName.Text = "";
                            }
                        }
                    }
                    else
                    {
                        DataTable dt = BlTblProgram.LoadData(txtProgramName.Text);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("This Program Already Exist");
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                BlTblProgram.Submit(Program);
                                BlLog log = new BlLog();
                                log.UserId = FrmLogin.LibrarianId;
                                log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Inseretd a Program record successfully";
                                log.datetime = DateTime.Now;
                                BlLog.Save(log);
                                txtProgramName.Text = "";
                            }
                        }
                    }
                    btnSubmit.Text = "Submit";
                }
                catch 
                {

                }
            }
           
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           ProgramID = 0;
            FrmProgramList obj=new FrmProgramList();
            this.Hide();
            obj.ShowDialog();
        }

        private void txtProgramName_TextChanged(object sender, EventArgs e)
        {
            lblProgram.Text = "";
        }

        private void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }

        private void txtProgramName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((txtProgramName.TextLength == 0) & (e.KeyChar == 32))
            {
                e.Handled = true;
            }
        }
    }
}
