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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.DoubleBuffered = true;
        }
        public static string LibrarianRole, LibrarianName;
        public static int LibrarianId;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserNameEmailContact.Text=="") 
            {
                lblUserNameEmailContact.Text = "Required";
            }
            else if (txtPassword.Text=="")
            {
                lblPassword.Text = "Required";
            }
            else
            {
                try
                {
                    if (BlLibrarian.Login(txtUserNameEmailContact.Text).Rows.Count > 0)
                    {
                        DataTable dt = BlLibrarian.Login(txtUserNameEmailContact.Text, txtPassword.Text);
                        if (dt.Rows.Count > 0)
                        {
                            LibrarianRole = "" + dt.Rows[0]["Role"];
                            LibrarianName = "" + dt.Rows[0]["UserName"];
                            LibrarianId = Convert.ToInt32(dt.Rows[0]["LibrarianId"]);
                            BlLog log = new BlLog();
                            log.UserId = LibrarianId;
                            log.Log = "This Librarian '" + LibrarianName + "' has been login successfully";
                            log.datetime = DateTime.Now;
                            BlLog.Save(log);
                            FrmHome frmHome = new FrmHome();
                            this.Hide();
                            frmHome.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect UserName/Email or Contact");
                    }
                }
                catch 
                {

                }
            }
        }

        private void txtUserNameEmailContact_TextChanged(object sender, EventArgs e)
        {
            if (txtUserNameEmailContact.Text!="")
            {
                lblUserNameEmailContact.Text = "";
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text!="")
            {
                lblPassword.Text = "";
            }
        }

        private void LinkForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmGenerateOtp obj = new FrmGenerateOtp();
            this.Hide();
            obj.ShowDialog();
        }

        private void LinkChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmChangePassword frmChangePassword = new FrmChangePassword();
            this.Hide();
            frmChangePassword.ShowDialog();
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PnHideShow_MouseEnter(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0';
            PnHideShow.BackColor = Color.LightGray;
        }

        private void PnHideShow_MouseLeave(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            PnHideShow.BackColor = Color.White;
        }

        private void lblCreateNewaccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLibrarianRegistration obj= new FrmLibrarianRegistration();
            this.Hide();
            obj.ShowDialog();
        }
    }
}
