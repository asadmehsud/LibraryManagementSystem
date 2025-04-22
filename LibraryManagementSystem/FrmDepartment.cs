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
    public partial class FrmDepartment : Form
    {
        public FrmDepartment()
        {
            InitializeComponent();
            txtDepartmentName.Text = FrmDepartmentList.DepartmentName;
            ddlStatus.Text = FrmDepartmentList.Status;
            if (FrmDepartmentList.DepartmentId > 0)
            {
                ImgDeparment.Image = FrmLibrarianList.GetImageForUpdate(FrmDepartmentList.PictureInByte);
            }
            FrmDepartmentList.DepartmentName = "";
            FrmDepartmentList.Status = "";
        }
        BlTblDepartment Dept = new BlTblDepartment();
       // Bitmap DefaultImg = Resources.icons8_click_here;
        private byte[] GetImage()
        {
            MemoryStream stream = new MemoryStream();
            ImgDeparment.Image.Save(stream, ImgDeparment.Image.RawFormat);
            return stream.GetBuffer();
        }
        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if (txtDepartmentName.Text == "")
            {
                lblDepartmentName.Text = "Required";
            }
            else if (ddlStatus.Text == "")
            {
                lblStatus.Text = "Required";
            }
            //else if (ImgDeparment.Image == DefaultImg)
            //{
            //    lblDepartmentImage.Text = "Required";
            //}
            else
            {
                try
                {
                    string status = "";
                    if (ddlStatus.Text == "Active")
                    {
                        status = "1";
                    }
                    else
                    {
                        status = "0";
                    }
                    if (FrmDepartmentList.DepartmentId > 0)
                    {
                        if (BlTblDepartment.CheckDepartment(FrmDepartmentList.DepartmentId, txtDepartmentName.Text).Rows.Count > 0)
                        {
                            MessageBox.Show("This Department is already exist");
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                BlTblDepartment obj = new BlTblDepartment();
                                obj.DepartmentName = txtDepartmentName.Text;
                                obj.Status = Convert.ToInt32(status);
                                obj.Image = GetImage();
                                obj.DepartmentId = FrmDepartmentList.DepartmentId;
                                if (BlTblDepartment.Submit(obj) == 1)
                                {
                                    BlLog log = new BlLog();
                                    log.UserId = FrmLogin.LibrarianId;
                                    log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Updated a Department record successfully";
                                    log.datetime = DateTime.Now;
                                    BlLog.Save(log);
                                    txtDepartmentName.Text = "";
                                    ImgDeparment.Image = Resources.icons8_click_here;
                                    FrmDepartmentList.DepartmentId = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (BlTblDepartment.LoadData(txtDepartmentName.Text).Rows.Count > 0)
                        {
                            MessageBox.Show("This Department is already exist");
                        }
                        else
                        {

                            if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                BlTblDepartment obj = new BlTblDepartment();
                                obj.DepartmentName = txtDepartmentName.Text;
                                obj.Status = Convert.ToInt32(status);
                                obj.Image = GetImage();
                                if (BlTblDepartment.Submit(obj) == 1)
                                {
                                    BlLog log = new BlLog();
                                    log.UserId = FrmLogin.LibrarianId;
                                    log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Inseretd a Department record successfully";
                                    log.datetime = DateTime.Now;
                                    BlLog.Save(log);
                                    txtDepartmentName.Text = "";
                                    ImgDeparment.Image = Resources.icons8_click_here;
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
        private void ImgDeparment_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG Files|*.jpg|PNG Files|*.png|GIF Files|*.gif|All Files|*.*;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImgDeparment.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ImgDeparment.Image = Resources.icons8_click_here;
        }

        private void lblList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDepartmentList.DepartmentId = 0;
            FrmDepartmentList obj = new FrmDepartmentList();
            this.Hide();
            obj.ShowDialog();
        }

        private void txtDepartmentName_TextChanged(object sender, EventArgs e)
        {
            lblDepartmentName.Text = "";
        }

        private void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }
        private void txtDepartmentName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((txtDepartmentName.TextLength == 0) & (e.KeyChar == 32))
            {
                e.Handled = true;
            }
        }
    }
}
