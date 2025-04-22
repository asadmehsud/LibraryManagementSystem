using LibraryManagementSystem.BL;
using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class FrmAuthor : Form
    {
        public FrmAuthor()
        {
            InitializeComponent();

        }
        private byte[] GetImage()
        {
            MemoryStream stream = new MemoryStream();
            ImgAuthor.Image.Save(stream, ImgAuthor.Image.RawFormat);
            return stream.GetBuffer();
        }
        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int ID;
        public void Edit(int id, string Name, int Status)
        {
            ID = id;
            txtAuthorName.Text = Name;
            ImgAuthor.Image = FrmLibrarianList.GetImageForUpdate(FrmAuthorList.PictureInByte);
            ddlStatus.Text = Status == 1 ? "Active" : "Inactive";
            btnSubmit.Text = "Update";
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtAuthorName.Text == "")
            {
                lblAuthorName.Text = "Required";
            }
            else if (ddlStatus.Text == "")
            {
                lblStatus.Text = "Required";
            }
            else
            {
                try
                {
                    BlTblAuthor obj = new BlTblAuthor();
                    obj.AuthorName = txtAuthorName.Text;
                    obj.Image = GetImage();
                    obj.Status = ddlStatus.Text;
                    if (btnSubmit.Text == "Update")
                    {
                        if (BlTblAuthor.CheckInUpdate(obj.AuthorName, ID).Rows.Count > 0)
                        {
                            MessageBox.Show("This Author is Already ext");
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                obj.AuthorId = ID;
                                if (BlTblAuthor.Register(obj) == 1)
                                {
                                    BlLog log = new BlLog();
                                    log.UserId = FrmLogin.LibrarianId;
                                    log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Updated an Author record successfully";
                                    log.datetime = DateTime.Now;
                                    BlLog.Save(log);
                                    txtAuthorName.Text = "";
                                    ID = 0;
                                    ImgAuthor.Image = Resources.icons8_click_here;
                                }
                            }
                        }

                    }

                    else
                    {
                        if (BlTblAuthor.Check(obj.AuthorName).Rows.Count > 0)
                        {
                            MessageBox.Show("This Author is Already ext");
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                if (BlTblAuthor.Register(obj) == 1)
                                {
                                    BlLog log = new BlLog();
                                    log.UserId = FrmLogin.LibrarianId;
                                    log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Inseretd an Author record successfully";
                                    log.datetime = DateTime.Now;
                                    BlLog.Save(log);
                                    txtAuthorName.Text = "";
                                    ImgAuthor.Image = Resources.icons8_click_here;
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


        private void ImgAuthor_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG Files|*.jpg|PNG Files|*.png|GIF Files|*.gif|All Files|*.*;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImgAuthor.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ImgAuthor.Image = Resources.icons8_click_here;
        }

        private void txtAuthorName_TextChanged(object sender, EventArgs e)
        {
            if (lblAuthorName.Text == "Required")
            {
                lblAuthorName.Text = "";
            }
        }

        private void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblStatus.Text == "Required")
            {
                lblStatus.Text = "";
            }
        }

        private void lblList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ID = 0;
            FrmAuthorList obj = new FrmAuthorList();
            this.Hide();
            obj.ShowDialog();
        }

        private void txtAuthorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'A' || e.KeyChar > 'z') & (e.KeyChar != 8) & (e.KeyChar != 32))
            {
                e.Handled = true;
            }
        }
    }
}
