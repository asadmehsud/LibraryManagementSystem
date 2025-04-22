using LibraryManagementSystem.BL;
using LibraryManagementSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class FrmLibrarianRegistration : Form
    {
        public FrmLibrarianRegistration()
        {
            InitializeComponent();
            if (FrmLibrarianList.LibrarianId>0)
            {
                txtFirstName.Text = FrmLibrarianList.FirstName;
                txtLastName.Text = FrmLibrarianList.LastName;
                txtUserName.Text = FrmLibrarianList.Username;
                txtEmail.Text = FrmLibrarianList.Email;
                txtMobileNo.Text = FrmLibrarianList.MobileNo;
                txtCnic.Text = FrmLibrarianList.Cnic;
                ddlUserRole.Text = FrmLibrarianList.Role;
                txtPassword.Text = FrmLibrarianList.Password;
                txtAddress.Text = FrmLibrarianList.Address;
                ImgLibrarian.Image = FrmLibrarianList.GetImageForUpdate(FrmLibrarianList.PictureInByte);
            }
            FrmLibrarianList.FirstName = "";
            FrmLibrarianList.LastName = "";
            FrmLibrarianList.Username = "";
            FrmLibrarianList.Email = "";
            FrmLibrarianList.MobileNo = "";
            FrmLibrarianList.Cnic = "";
            FrmLibrarianList.Role = "";
            FrmLibrarianList.Password = "";
            FrmLibrarianList.Address = "";
        }
        private byte[] GetImage()
        {
            MemoryStream stream = new MemoryStream();
            ImgLibrarian.Image.Save(stream, ImgLibrarian.Image.RawFormat);
            return stream.GetBuffer();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                lblFirstName.Text = "Required";
            }
            else if (txtLastName.Text == "")
            {
                lblLastName.Text = "Required";
            }
            else if (txtUserName.Text == "")
            {
                lblUserName.Text = "Required";
            }
            else if (txtEmail.Text == "")
            {
                lblEmail.Text = "Required";
            }
            else if (txtMobileNo.Text == "")
            {
                lblMobileNo.Text = "Required";
            }
            else if (txtCnic.Text == "")
            {
                lblCnic.Text = "Required";
            }
            else if (ddlUserRole.Text == "")
            {
                lblUserRole.Text = "Required";
            }
            else if (txtPassword.Text == "")
            {
                lblPassword.Text = "Required";
            }
            else if (txtAddress.Text == "")
            {
                lblAddress.Text = "Required";
            }
            else if (txtMobileNo.TextLength < 11)
            {
                lblMobileNo.Text = "Invalid";
            }
            else if (txtCnic.TextLength < 13)
            {
                lblCnic.Text = "Invalid";
            }
            else if (ImgLibrarian.Image==Resources.icons8_click_here)
            {
                lblLibrarianImage.Text="Required";
            }
            else
            {
                string[] index = txtEmail.Text.Split('@');
                if (txtEmail.Text.Contains("@gmail.com") == false)
                {
                    lblEmail.Text = "Use example@gmail.com";
                }
                else if (index[0] == "")
                {
                    lblEmail.Text = "Enter example before @";
                }
                else if (index[1].Length > 9)
                {
                    lblEmail.Text = ".com is valid only";
                }
                else
                {
                    try
                    {
                        if (FrmLibrarianList.LibrarianId > 0)
                        {
                            DataTable dt1 = BlLibrarian.CheckUserInUpdate("UserName", txtUserName.Text, FrmLibrarianList.LibrarianId);
                            DataTable dt2 = BlLibrarian.CheckUserInUpdate("MobileNo", txtMobileNo.Text, FrmLibrarianList.LibrarianId);
                            DataTable dtS1 = BlLibrarian.GetDuplicateUserInTblStudent(txtMobileNo.Text);
                            DataTable dt3 = BlLibrarian.CheckUserInUpdate("Cnic", txtCnic.Text, FrmLibrarianList.LibrarianId);
                            DataTable dtS2 = BlLibrarian.GetDuplicateUserInTblStudent(txtCnic.Text);
                            DataTable dt4 = BlLibrarian.CheckUserInUpdate("Email", txtEmail.Text, FrmLibrarianList.LibrarianId);
                            if (dt1.Rows.Count > 0)
                            {
                                MessageBox.Show("This '" + txtUserName.Text + "' Username is already Exist");
                            }
                            else if (dt2.Rows.Count > 0)
                            {
                                MessageBox.Show("This  '" + txtMobileNo.Text + "' MobileNo is already Exist");
                            }
                            else if (dtS1.Rows.Count > 0)
                            {
                                MessageBox.Show("This  '" + txtMobileNo.Text + "' MobileNo is already Exist in Student table");
                            }
                            else if (dt3.Rows.Count > 0)
                            {
                                MessageBox.Show("This  '" + txtCnic.Text + "' CNIC is already Exist");
                            }
                            else if (dtS2.Rows.Count > 0)
                            {
                                MessageBox.Show("This  '" + txtCnic.Text + "' CNIC is already Exist in Student table");
                            }
                            else if (dt4.Rows.Count > 0)
                            {
                                MessageBox.Show("This  '" + txtEmail.Text + "' Email number is already Exist");
                            }
                            else
                            {
                                if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    BlLibrarian obj = new BlLibrarian();
                                    obj.FIrstName = txtFirstName.Text;
                                    obj.LastName = txtLastName.Text;
                                    obj.UserName = txtUserName.Text;
                                    obj.Email = txtEmail.Text;
                                    obj.MobileNo = txtMobileNo.Text;
                                    obj.Cnic = txtCnic.Text;
                                    obj.Role = ddlUserRole.Text;
                                    obj.Password = txtPassword.Text;
                                    obj.Address = txtAddress.Text;
                                    obj.Image = GetImage();
                                    obj.LibrarianId = FrmLibrarianList.LibrarianId;
                                    if (BlLibrarian.Update(obj) == 1)
                                    {
                                        BlLog log = new BlLog();
                                        log.UserId = FrmLogin.LibrarianId;
                                        log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Updated a User record successfully";
                                        log.datetime = DateTime.Now;
                                        BlLog.Save(log);
                                        txtFirstName.Text = "";
                                        txtLastName.Text = "";
                                        txtUserName.Text = "";
                                        txtEmail.Text = "";
                                        txtMobileNo.Text = "";
                                        txtCnic.Text = "";
                                        ImgLibrarian.Image = Resources.icons8_click_here;
                                        txtPassword.Text = "";
                                        txtAddress.Text = "";
                                        FrmLibrarianList.LibrarianId = 0;
                                    }

                                }
                            }
                        }
                        else
                        {
                            DataTable dt1 = BlLibrarian.CheckUser("UserName", txtUserName.Text);
                            DataTable dt2 = BlLibrarian.CheckUser("MobileNo", txtMobileNo.Text);
                            DataTable dtS1 = BlLibrarian.GetDuplicateUserInTblStudent(txtMobileNo.Text);
                            DataTable dt3 = BlLibrarian.CheckUser("Cnic", txtCnic.Text);
                            DataTable dtS2 = BlLibrarian.GetDuplicateUserInTblStudent(txtCnic.Text);
                            DataTable dt4 = BlLibrarian.CheckUser("Email", txtEmail.Text);
                            if (dt1.Rows.Count > 0)
                            {
                                MessageBox.Show("This  '" + txtUserName.Text + "' Username is already Exist");
                            }
                            else if (dt2.Rows.Count > 0)
                            {
                                MessageBox.Show("This  '" + txtMobileNo.Text + "' MobileNo is already Exist");
                            }
                            else if (dtS1.Rows.Count > 0)
                            {
                                MessageBox.Show("This  '" + txtMobileNo.Text + "' MobileNo is already Exist in Student table");
                            }
                            else if (dt3.Rows.Count > 0)
                            {
                                MessageBox.Show("This  '" + txtCnic.Text + "' CNIC is already Exist");
                            }
                            else if (dtS2.Rows.Count > 0)
                            {
                                MessageBox.Show("This  '" + txtCnic.Text + "' CNIC is already Exist in Student table");
                            }
                            else if (dt4.Rows.Count > 0)
                            {
                                MessageBox.Show("This  '" + txtEmail.Text + "' Email number is already Exist");
                            }
                            else
                            {
                                if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    BlLibrarian obj = new BlLibrarian();
                                    obj.FIrstName = txtFirstName.Text;
                                    obj.LastName = txtLastName.Text;
                                    obj.UserName = txtUserName.Text;
                                    obj.Email = txtEmail.Text;
                                    obj.MobileNo = txtMobileNo.Text;
                                    obj.Cnic = txtCnic.Text;
                                    obj.Role = ddlUserRole.Text;
                                    obj.Password = txtPassword.Text;
                                    obj.Address = txtAddress.Text;
                                    obj.Image = GetImage();
                                    if (BlLibrarian.Save(obj) == 1)
                                    {
                                        BlLog log = new BlLog();
                                        log.UserId = FrmLogin.LibrarianId;
                                        log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has inseretd a User record successfully";
                                        log.datetime = DateTime.Now;
                                        BlLog.Save(log);
                                        txtFirstName.Text = "";
                                        txtLastName.Text = "";
                                        txtUserName.Text = "";
                                        txtEmail.Text = "";
                                        txtMobileNo.Text = "";
                                        txtCnic.Text = "";
                                        ImgLibrarian.Image = Resources.icons8_click_here;
                                        txtPassword.Text = "";
                                        txtAddress.Text = "";
                                    }

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

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (txtFirstName.Text != "")
            {
                lblFirstName.Text = "";
            }
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtLastName.Text != "")
            {
                lblLastName.Text = "";
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                char ch = txtUserName.Text[0];
                if ((ch < 'a' || ch > 'z') & (ch != '_'))
                {
                    lblUserName.Text = "Invalid";
                }
            }
            catch
            {
                lblUserName.Text = "";
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
            {
                lblEmail.Text = "";
            }
        }

        private void txtMobileNo_TextChanged(object sender, EventArgs e)
        {
            if (txtMobileNo.Text != "")
            {
                lblMobileNo.Text = "";
            }
        }

        private void txtCnic_TextChanged(object sender, EventArgs e)
        {
            if (txtCnic.Text != "")
            {
                lblCnic.Text = "";
            }
        }

        private void ddlUserRole_TextChanged(object sender, EventArgs e)
        {
            if (ddlUserRole.Text != "")
            {
                lblUserRole.Text = "";
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != "")
            {
                lblPassword.Text = "";
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtAddress.Text != "")
            {
                lblAddress.Text = "";
            }
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'A' || e.KeyChar > 'z') & e.KeyChar != 8)
            {
                e.Handled = true;
            }

        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'A' || e.KeyChar > 'z') & e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'a' || e.KeyChar > 'z') & (e.KeyChar < '0' || e.KeyChar > '9') & e.KeyChar != 8 & e.KeyChar != '_')
            {
                e.Handled = true;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'a' || e.KeyChar > 'z') & (e.KeyChar < '0' || e.KeyChar > '9') & e.KeyChar != 8 & e.KeyChar != '@' & e.KeyChar != '.')
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.' & txtEmail.Text.Contains(".") == true)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '@' & txtEmail.Text.Contains("@") == true)
            {
                e.Handled = true;
            }
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImgLibrarian_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG Files|*.jpg|PNG Files|*.png|GIF Files|*.gif|All Files|*.*;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImgLibrarian.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            ImgLibrarian.Image = Resources.icons8_click_here;
        }

        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') & (e.KeyChar != 08) & (e.KeyChar != 32))
            {
                e.Handled = true;
            }
            if (txtMobileNo.TextLength > 10 & e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void txtCnic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') & (e.KeyChar != 08) & (e.KeyChar != 32))
            {
                e.Handled = true;
            }
            if (txtCnic.TextLength > 12 & e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLibrarianList.LibrarianId = 0;
            FrmLibrarianList obj = new FrmLibrarianList();
            this.Hide();
            obj.ShowDialog();
        }
    }
}
