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
    public partial class FrmStudent : Form
    {
        public FrmStudent()
        {
            InitializeComponent();
            LoadDepartment();
            LoadProgram();
            LoadSession();
            if (FrmStudentList.StudentId > 0)
            {
                ddlDepartmentName.SelectedValue = FrmStudentList.DepartmentId;
                ddlProgram.SelectedValue = FrmStudentList.ProgramId;
                ddlSession.SelectedValue = FrmStudentList.SessionId;
                ImgStudent.Image = FrmLibrarianList.GetImageForUpdate(FrmStudentList.PictureInByte);
            }
            txtStudentName.Text = FrmStudentList.StudentName;
            txtFatherName.Text = FrmStudentList.FatherName;
            txtCnic.Text = FrmStudentList.Cnic;
            txtRollNo.Text = FrmStudentList.RollNo;
            txtFatherCnic.Text = FrmStudentList.FatherCnic;
            txtContact.Text = FrmStudentList.Contact;
            ddlGender.Text = FrmStudentList.Gender;
            txtAddress.Text = FrmStudentList.Address;
            FrmStudentList.DepartmentId = 0;
            FrmStudentList.ProgramId = 0;
            FrmStudentList.SessionId = 0;
            FrmStudentList.StudentName = "";
            FrmStudentList.FatherName = "";
            FrmStudentList.FatherCnic = "";
            FrmStudentList.Contact = "";
            FrmStudentList.Cnic = "";
            FrmStudentList.RollNo = "";
            FrmStudentList.Gender = "";
            FrmStudentList.Address = "";
        }
        private byte[] GetImage()
        {
            MemoryStream stream = new MemoryStream();
            ImgStudent.Image.Save(stream, ImgStudent.Image.RawFormat);
            return stream.GetBuffer();

        }
        private void LoadDepartment()
        {
            ddlDepartmentName.DataSource = BlTblDepartment.LoadData();
            ddlDepartmentName.ValueMember = "DepartmentId";
            ddlDepartmentName.DisplayMember = "DepartmentName";
        }
        private void LoadProgram()
        {
            ddlProgram.DataSource = BlTblProgram.LoadData();
            ddlProgram.ValueMember = "ProgramId";
            ddlProgram.DisplayMember = "ProgramName";
        }
        private void LoadSession()
        {
            ddlSession.DataSource = BlTblSession.LoadData();
            ddlSession.ValueMember = "SessionId";
            ddlSession.DisplayMember = "SessionName";
        }
        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImgStudent_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG Files|*.jpg|PNG Files|*.png|GIF Files|*.gif|All Files|*.*;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImgStudent.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ImgStudent.Image = Resources.icons8_click_here;
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') & (e.KeyChar != 08))
            {
                e.Handled = true;
            }
            if ((txtContact.TextLength > 10) & (e.KeyChar != 08))
            {
                e.Handled = true;
            }
        }

        private void txtCnic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') & (e.KeyChar != 08))
            {
                e.Handled = true;
            }
            if ((txtCnic.TextLength > 12) & (e.KeyChar != 08))
            {
                e.Handled = true;
            }
        }

        private void txtFatherCnic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') & (e.KeyChar != 08))
            {
                e.Handled = true;
            }
            if ((txtFatherCnic.TextLength > 12) & (e.KeyChar != 08))
            {
                e.Handled = true;
            }
        }

        private void txtRollNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') & (e.KeyChar != 08))
            {
                e.Handled = true;
            }

        }

        private void txtStudentName_TextChanged(object sender, EventArgs e)
        {
            if (lblStudentName.Text == "Required")
            {
                lblStudentName.Text = "";
            }
        }

        private void ddlDepartmentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblDepartmentName.Text == "Required")
            {
                lblDepartmentName.Text = "";
            }
        }

        private void ddlProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblProgram.Text = "";
        }

        private void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSession.Text = "";
        }

        private void txtFatherName_TextChanged(object sender, EventArgs e)
        {
            lblFatherName.Text = "";
        }

        private void txtRollNo_TextChanged(object sender, EventArgs e)
        {
            lblRollNo.Text = "";
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            if (lblContact.Text == "Required" || txtContact.Text == "Invalid")
            {
                lblContact.Text = "";
            }
        }

        private void txtCnic_TextChanged(object sender, EventArgs e)
        {
            if (lblCnic.Text == "Required" || lblCnic.Text == "Invalid")
            {
                lblCnic.Text = "";
            }
        }

        private void txtFatherCnic_TextChanged(object sender, EventArgs e)
        {
            if (lblFatherCnic.Text == "Required" || lblFatherCnic.Text == "Invalid")
            {
                lblFatherCnic.Text = "";
            }
        }

        private void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblGender.Text = "";
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            lblAddress.Text = "";
        }

        private void lblList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmStudentList.SessionId = 0;
            FrmStudentList obj = new FrmStudentList();
            this.Hide();
            obj.ShowDialog();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtStudentName.Text == "")
            {
                lblStudentName.Text = "Required";
            }
            //else if (ddlDepartmentName.Text == "")
            //{
            //    lblDepartmentName.Text = "Required";
            //}
            //else if (ddlProgram.Text == "")
            //{
            //    lblProgram.Text = "Required";
            //}
            //else if (ddlSession.Text == "")
            //{
            //    lblSession.Text = "Required";
            //}
            //else if (txtFatherName.Text == "")
            //{
            //    lblFatherName.Text = "Required";
            //}
            //else if (txtRollNo.Text == "")
            //{
            //    lblRollNo.Text = "Required";
            //}
            //else if (txtContact.Text == "")
            //{
            //    lblContact.Text = "Required";
            //}
            //else if (txtCnic.Text == "")
            //{
            //    lblCnic.Text = "Required";
            //}
            //else if (txtFatherCnic.Text == "")
            //{
            //    lblFatherCnic.Text = "Required";
            //}
            //else if (ddlGender.Text == "")
            //{
            //    lblGender.Text = "Required";
            //}
            //else if (txtAddress.Text == "")
            //{
            //    lblAddress.Text = "Required";
            //}
            //else if (txtContact.TextLength < 11)
            //{
            //    lblContact.Text = "Invalid";
            //}
            //else if (txtCnic.TextLength < 13)
            //{
            //    lblCnic.Text = "Invalid";
            //}
            //else if (txtFatherCnic.TextLength < 13)
            //{
            //    lblFatherCnic.Text = "Invalid";
            //}
            else
            {
                if (txtCnic.Text == txtFatherCnic.Text)
                {
                    MessageBox.Show("Student and his Father Cnic Can't be similar");
                }
                else
                {
                    try
                    {
                        if (FrmStudentList.StudentId > 0)
                        {
                            if ((BlTblStudent.CheckDuplicateRecordForUpdate(txtContact.Text, FrmStudentList.StudentId).Rows.Count > 0))
                            {
                                MessageBox.Show("This '" + txtContact.Text + "' ContactNo is already exist");
                            }
                            else if ((BlTblStudent.CheckDuplicateRecordForUpdate(txtCnic.Text, FrmStudentList.StudentId).Rows.Count > 0))
                            {
                                MessageBox.Show("This '" + txtCnic.Text + "' Cnic is already exist");
                            }
                            else if ((BlTblStudent.CheckDuplicateRecordForUpdate(txtFatherCnic.Text, FrmStudentList.StudentId).Rows.Count > 0))
                            {
                                MessageBox.Show("This '" + txtFatherCnic.Text + "' FatherCnic is already exist");
                            }
                            else if (BlTblStudent.CheckDuplicateRecordOverallForUpdate(Convert.ToInt32(txtRollNo.Text), Convert.ToInt32(ddlDepartmentName.SelectedValue), Convert.ToInt32(ddlProgram.SelectedValue), Convert.ToInt32(ddlSession.SelectedValue), FrmStudentList.SessionId).Rows.Count > 0)
                            {
                                MessageBox.Show("This student has already been inserted");
                            }
                            else
                            {
                                if (MessageBox.Show("Are you Sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    BlTblStudent obj = new BlTblStudent();
                                    obj.StudentId = FrmStudentList.StudentId;
                                    obj.StudentName = txtStudentName.Text;
                                    obj.DepartmentId = Convert.ToInt32(ddlDepartmentName.SelectedValue);
                                    obj.ProgramId = Convert.ToInt32(ddlProgram.SelectedValue);
                                    obj.SessionId = Convert.ToInt32(ddlSession.SelectedValue);
                                    obj.FatherName = txtFatherName.Text;
                                    obj.RollNO = Convert.ToInt32(txtRollNo.Text);
                                    obj.ContactNo = txtContact.Text;
                                    obj.Cnic = txtCnic.Text;
                                    obj.FatherCnic = txtFatherCnic.Text;
                                    obj.Gender = ddlGender.Text;
                                    obj.Address = txtAddress.Text;
                                    obj.CreatedAt = DateTime.Now;
                                    obj.Image = GetImage();
                                    if (BlTblStudent.Register(obj) == 1)
                                    {
                                        MessageBox.Show("Updated");
                                        BlLog log = new BlLog();
                                        log.UserId = FrmLogin.LibrarianId;
                                        log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Updated a student record successfully";
                                        log.datetime = DateTime.Now;
                                        BlLog.Save(log);
                                        txtStudentName.Text = "";
                                        txtRollNo.Text = "";
                                        txtCnic.Text = "";
                                        txtFatherName.Text = "";
                                        txtFatherCnic.Text = "";
                                        txtAddress.Text = "";
                                        txtContact.Text = "";
                                        ImgStudent.Image = Resources.icons8_click_here;
                                    }
                                }
                            }
                        }
                        else
                        {

                            if ((BlTblStudent.CheckDuplicateRecord(txtContact.Text).Rows.Count > 0))
                            {
                                MessageBox.Show("This '" + txtContact.Text + "' ContactNo is already exist");
                            }
                            else if ((BlTblStudent.CheckDuplicateRecord(txtCnic.Text).Rows.Count > 0))
                            {
                                MessageBox.Show("This '" + txtCnic.Text + "' Cnic is already exist");
                            }
                            else if ((BlTblStudent.CheckDuplicateRecord(txtFatherCnic.Text).Rows.Count > 0))
                            {
                                MessageBox.Show("This '" + txtFatherCnic.Text + "' FatherCnic is already exist");
                            }
                            else if (BlTblStudent.CheckDuplicateRecordOverall(Convert.ToInt32(txtRollNo.Text), Convert.ToInt32(ddlDepartmentName.SelectedValue), Convert.ToInt32(ddlProgram.SelectedValue), Convert.ToInt32(ddlSession.SelectedValue)).Rows.Count > 0)
                            {
                                MessageBox.Show("This student has already been inserted");
                            }
                            else
                            {
                                if (MessageBox.Show("Are you Sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    BlTblStudent obj = new BlTblStudent();
                                    obj.StudentName = txtStudentName.Text;
                                    obj.DepartmentId = Convert.ToInt32(ddlDepartmentName.SelectedValue);
                                    obj.ProgramId = Convert.ToInt32(ddlProgram.SelectedValue);
                                    obj.SessionId = Convert.ToInt32(ddlSession.SelectedValue);
                                    obj.FatherName = txtFatherName.Text;
                                    obj.RollNO = Convert.ToInt32(txtRollNo.Text);
                                    obj.ContactNo = txtContact.Text;
                                    obj.Cnic = txtCnic.Text;
                                    obj.FatherCnic = txtFatherCnic.Text;
                                    obj.Gender = ddlGender.Text;
                                    obj.Address = txtAddress.Text;
                                    obj.CreatedAt = DateTime.Now;
                                    obj.Image = GetImage();
                                    if (BlTblStudent.Register(obj) == 1)
                                    {
                                        MessageBox.Show("Inserted");
                                        BlLog log = new BlLog();
                                        log.UserId = FrmLogin.LibrarianId;
                                        log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Inseretd a student record successfully";
                                        log.datetime = DateTime.Now;
                                        BlLog.Save(log);
                                        txtStudentName.Text = "";
                                        txtRollNo.Text = "";
                                        txtCnic.Text = "";
                                        txtFatherName.Text = "";
                                        txtFatherCnic.Text = "";
                                        txtAddress.Text = "";
                                        txtContact.Text = "";
                                        ImgStudent.Image = Resources.icons8_click_here;
                                        FrmBookIssue objj= new FrmBookIssue();
                                        this.Hide();
                                        objj.ShowDialog();
                                    }
                                }
                            }

                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }

        private void txtStudentName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'A' || e.KeyChar > 'z') & e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if ((txtStudentName.TextLength == 0) & (e.KeyChar == 32))
            {
                e.Handled = true;
            }
        }

        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'A' || e.KeyChar > 'z') & e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if ((txtFatherName.TextLength == 0) & (e.KeyChar == 32))
            {
                e.Handled = true;
            }
        }
    }
}
