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
    public partial class FrmForgetPassword : Form
    {
        public FrmForgetPassword()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtOtp.Text=="") 
            {
                lblOTP.Text = "Required";
            }
            else if (txtCreatePassword.Text=="")
            {
                lblCreatePassword.Text = "Required";
            }
            else if (txtConfirmPassword.Text=="")
            {
                lblConfirmPassword.Text = "Required";
            }
            else
            {
                if (txtCreatePassword.Text!=txtConfirmPassword.Text)
                {
                    lblConfirmPassword.Text = "Re-Confirm your Password";
                }
                else
                {
                    try
                    {
                        if (BlLibrarian.CheckOtp(FrmGenerateOtp.Email, txtOtp.Text).Rows.Count > 0)
                        {
                            if (BlLibrarian.UpdatePassword(txtCreatePassword.Text, FrmGenerateOtp.Email) == 1)
                            {
                                MessageBox.Show("Password updated successfully");
                                txtOtp.Text = "";
                                txtCreatePassword.Text = "";
                                txtConfirmPassword.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Unable to update Password due to some issues");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Incorrect OTP ");
                        }
                    }
                    catch 
                    {

                    }
                }
               
            }
        }

        private void txtOtp_TextChanged(object sender, EventArgs e)
        {
            if (txtOtp.Text!="")
            {
                lblOTP.Text = "";
            }
        }

        private void txtCreatePassword_TextChanged(object sender, EventArgs e)
        {
            if (txtCreatePassword.Text!="")
            {
                lblCreatePassword.Text = "";
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text!="")
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

        private void lblGotoLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLogin obj = new FrmLogin();
            this.Hide();
            obj.ShowDialog();
        }

        private void lblSendOtpAgain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmGenerateOtp obj = new FrmGenerateOtp();
            this.Hide();
            obj.ShowDialog();
        }
    }
}
