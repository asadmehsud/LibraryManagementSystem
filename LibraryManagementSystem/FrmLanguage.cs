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
    public partial class FrmLanguage : Form
    {
        public FrmLanguage()
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
            txtLanguageName.Text = Name;
            ddlStatus.Text = Status == 1 ? "Active" : "Inactive";
            btnSubmit.Text = "Update";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtLanguageName.Text == "")
            {
                lblLanguageName.Text = "Required";
            }
            else if (ddlStatus.Text == "")
            {
                lblStatus.Text = "Required";
            }
            else
            {
                try
                {
                    BlTblLanguage obj = new BlTblLanguage();
                    obj.LanguageName = txtLanguageName.Text;
                    obj.Status = ddlStatus.Text;

                    if (btnSubmit.Text == "Update")
                    {
                        if (BlTblCategory.CheckInUpdate(obj.LanguageName, ID).Rows.Count > 0)
                        {
                            MessageBox.Show("This Langugae is Already exist");
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                obj.LanguageId = ID;
                                if (BlTblLanguage.Submit(obj) == 1)
                                {
                                    BlLog log = new BlLog();
                                    log.UserId = FrmLogin.LibrarianId;
                                    log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Updated a Language record successfully";
                                    log.datetime = DateTime.Now;
                                    BlLog.Save(log);
                                    txtLanguageName.Text = "";
                                    ID = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (BlTblLanguage.Check(txtLanguageName.Text).Rows.Count > 0)
                        {
                            MessageBox.Show("This Language is already exist");
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                if (BlTblLanguage.Submit(obj) == 1)
                                {
                                    BlLog log = new BlLog();
                                    log.UserId = FrmLogin.LibrarianId;
                                    log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Inserted a Language record successfully";
                                    log.datetime = DateTime.Now;
                                    BlLog.Save(log);
                                    txtLanguageName.Text = "";
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



        private void txtLanguageName_TextChanged(object sender, EventArgs e)
        {
            if (lblLanguageName.Text == "Required")
            {
                lblLanguageName.Text = "";
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
            FrmLanguageList obj = new FrmLanguageList();
            this.Hide();
            obj.ShowDialog();
        }

        private void txtLanguageName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((txtLanguageName.TextLength == 0) & (e.KeyChar == 32))
            {
                e.Handled = true;
            }
        }
    }
}