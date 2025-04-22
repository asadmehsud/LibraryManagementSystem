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
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtEmailContact.Text == "")
            {
                lblUserNameEmailContact.Text = "Required";
            }
            else if (txtPassword.Text == "")
            {
                lblPassword.Text = "Required";
            }
            else if(txtCreatePassword.Text=="")
            {
                lblCreatePassword.Text = "Required";
            }
            else if (txtConfirmPassword.Text=="")
            {
                lblConfirmPassword.Text = "Required";
            }
            else
            {
                if (txtConfirmPassword.Text!=txtCreatePassword.Text)
                {
                    lblConfirmPassword.Text = "Re-Confirm password";
                }
                else
                {
                    try
                    {
                        if (BlLibrarian.ChangePassword(txtEmailContact.Text).Rows.Count > 0)
                        {
                            if (BlLibrarian.ChangePassword(txtEmailContact.Text, txtPassword.Text).Rows.Count > 0)
                            {
                                int check = BlLibrarian.UpdatePassword(txtCreatePassword.Text, txtEmailContact.Text);
                                if (check == 1)
                                {
                                    MessageBox.Show("Password changed successfully");
                                    txtEmailContact.Text = "";
                                    txtPassword.Text = "";
                                    txtConfirmPassword.Text = "";
                                }
                                else
                                {
                                    MessageBox.Show("Unable to change the password");
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Email or Phone No");
                        }
                    }
                    catch 
                    {

                    }
                }
            }
        }

        private void txtUserNameEmailContact_TextChanged(object sender, EventArgs e)
        {
            if (txtEmailContact.Text != "")
            {
                lblUserNameEmailContact.Text = "";
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != "")
            {
                lblPassword.Text = "";
            }
        }

        private void txtCreatePassword_TextChanged(object sender, EventArgs e)
        {
            if (txtCreatePassword.Text != "")
            {
                lblCreatePassword.Text = "";
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text != "")
            {
                lblConfirmPassword.Text = "";
            }
        }

        private void LinkGotoLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            this.Hide();
            frmLogin.ShowDialog();
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
