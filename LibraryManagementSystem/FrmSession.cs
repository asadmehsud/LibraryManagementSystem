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
    public partial class FrmSession : Form
    {
        public FrmSession()
        {
            InitializeComponent();
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         int SessionID;
        public void Update(int SessionId, string Session, int status)
        {
            SessionID = SessionId;
            txtSession.Text = Session;
            ddlStatus.Text=status == 1 ? "Active" : "Inactive";
            btnSubmit.Text = "Update";

        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtSession.Text == "")
            {
                lblSession.Text = "Required";
            }
            else if (ddlStatus.Text == "")
            {
                lblStatus.Text = "Required";
            }
            else
            {
                try
                {
                    BlTblSession Session = new BlTblSession();
                    Session.SessionName = txtSession.Text;
                    Session.Status = ddlStatus.Text;
                    if (btnSubmit.Text == "Update")
                    {
                        Session.SessionId = SessionID;
                        DataTable dt = BlTblSession.CheckSession(txtSession.Text, SessionID);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("This Session is already Exist");
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                if (BlTblSession.Submit(Session) == 1)
                                {
                                    BlLog log = new BlLog();
                                    log.UserId = FrmLogin.LibrarianId;
                                    log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Updated a Session record successfully";
                                    log.datetime = DateTime.Now;
                                    BlLog.Save(log);
                                    txtSession.Text = "";
                                }
                            }
                        }
                    }
                    else
                    {
                        DataTable dt = BlTblSession.LoadData(txtSession.Text);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("This Session Already Exist");
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                if (BlTblSession.Submit(Session) == 1)
                                {
                                    BlLog log = new BlLog();
                                    log.UserId = FrmLogin.LibrarianId;
                                    log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Inseretd a Session record successfully";
                                    log.datetime = DateTime.Now;
                                    BlLog.Save(log);
                                    txtSession.Text = "";
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

        private void lblList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SessionID = 0;
            FrmSessionList obj = new FrmSessionList();
            this.Hide();
            obj.ShowDialog();
        }

        private void txtSession_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') & (e.KeyChar != '-') & (e.KeyChar != 08))
            {
                e.Handled = true;
            }
            if ((txtSession.TextLength == 0) & (e.KeyChar == 32))
            {
                e.Handled = true;
            }
        }

        private void txtSession_TextChanged(object sender, EventArgs e)
        {
            lblSession.Text = "";
        }

        private void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }
    }
}
