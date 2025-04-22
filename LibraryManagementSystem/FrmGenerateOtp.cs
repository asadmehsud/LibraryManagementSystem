using LibraryManagementSystem.BL;
using LibraryManagementSystem.Custom_Classes;
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
    public partial class FrmGenerateOtp : Form
    {
        public FrmGenerateOtp()
        {
            InitializeComponent();
        }
        public static string Email;
        private void btnGenerateOTP_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                lblEmail.Text = "Required";
            }
            else
            {
                try
                {
                    if (BlLibrarian.ChangePassword(txtEmail.Text).Rows.Count > 0)
                    {
                        Email = txtEmail.Text;
                        string Otp = ClsEmailOtp.GenerateOtp();
                        int check = ClsEmailOtp.EmailSender(txtEmail.Text, "emailsender785@gmail.com", "Forget Password", "Don't share your <h1>OTP</h1> Code '" + Otp + "' with anyone");
                        if (check == 1)
                        {
                            if (BlLibrarian.GenerateOTP(txtEmail.Text, Otp) > 0)
                            {
                                FrmForgetPassword frmForgetPassword = new FrmForgetPassword();
                                this.Hide();
                                frmForgetPassword.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Failed updating OTP");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Check Your Internet Connection");
                        }
                    }
                    else
                    {
                        if (txtEmail.Text.Contains("@gmail.com") == false)
                        {
                            MessageBox.Show("Email must contain @gmail.com");
                        }
                        else
                        {
                            MessageBox.Show("Email not found, Please enter correct Email");
                        }
                    }
                }
                catch 
                {
                   
                }

            }

        }

        private void LinkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLogin obj = new FrmLogin();
            this.Hide();
            obj.ShowDialog();
        }
    }
}
