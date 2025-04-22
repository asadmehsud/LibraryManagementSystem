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
    public partial class FrmEdition : Form
    {
        public FrmEdition()
        {
            InitializeComponent();
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int ID;
        public void Edit(int id, string Name, int Status)
        {
            ID = id;
            txtEditionName.Text = Name;
            ddlStatus.Text = Status == 1 ? "Active" : "Inactive";
            btnSubmit.Text = "Update";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtEditionName.Text == "")
            {
                lblEditionName.Text = "Required";
            }
            else if (ddlStatus.Text == "")
            {
                lblStatus.Text = "Required";
            }
            else
            {
                try
                {
                    BlTblEdition obj = new BlTblEdition();
                    obj.EditionName = txtEditionName.Text;
                    obj.Status = ddlStatus.Text;

                    if (btnSubmit.Text == "Update")
                    {
                        if (BlTblEdition.Check(obj.EditionName).Rows.Count > 0)
                        {
                            MessageBox.Show("This Edition is Already ext");
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                obj.EditionId = ID;
                                if (BlTblEdition.Submit(obj) == 1)
                                {
                                    BlLog log = new BlLog();
                                    log.UserId = FrmLogin.LibrarianId;
                                    log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Updated a Edition record successfully";
                                    log.datetime = DateTime.Now;
                                    BlLog.Save(log);
                                    txtEditionName.Text = "";
                                    ID = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (BlTblEdition.CheckInUpdate(txtEditionName.Text, ID).Rows.Count > 0)
                        {
                            MessageBox.Show("This Edition is already exist");
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                if (BlTblEdition.Submit(obj) == 1)
                                {
                                    BlLog log = new BlLog();
                                    log.UserId = FrmLogin.LibrarianId;
                                    log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Inseretd an Edition record successfully";
                                    log.datetime = DateTime.Now;
                                    BlLog.Save(log);
                                    txtEditionName.Text = "";
                                }
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

        private void txtEditionName_TextChanged(object sender, EventArgs e)
        {
            if (lblEditionName.Text == "Required")
            {
                lblEditionName.Text = "";
            }
        }

        private void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblStatus.Text == "Required")
            {
                lblStatus.Text = "";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ID = 0;
            FrmEditionList obj = new FrmEditionList();
            this.Hide();
            obj.ShowDialog();
        }

        private void txtEditionName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((txtEditionName.TextLength == 0) & (e.KeyChar == 32))
            {
                e.Handled = true;
            }
        }
    }
}
