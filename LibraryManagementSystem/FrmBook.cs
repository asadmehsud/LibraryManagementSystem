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
    public partial class FrmBook : Form
    {
        public FrmBook()
        {
            InitializeComponent();
            LoadCategory();
            LoadLanguage();
            LoadAuthor();
            LoadEdition();


            txtBookName.Text = FrmBookList.BookName;
            ddlCategoryName.SelectedValue = FrmBookList.CategoryId;
            ddlLanguage.SelectedValue = FrmBookList.LanguageId;
            ddlEdition.SelectedValue = FrmBookList.EditionId;
            ddlAuthor.SelectedValue = FrmBookList.Authorid;
            txtDescription.Text = FrmBookList.Description;
            if (FrmBookList.BookId > 0)
            {
                txtStock.Text =  FrmBookList.Stock;
                ImgBook.Image = FrmLibrarianList.GetImageForUpdate(FrmBookList.PictureInByte);
            }
            FrmBookList.BookName = "";
            FrmBookList.CategoryId = 0;
            FrmBookList.LanguageId = 0;
            FrmBookList.EditionId = 0;
            FrmBookList.Authorid = 0;
            FrmBookList.Description = "";
        }
      
        private byte[] GetImage()
        {
            MemoryStream stream = new MemoryStream();
            ImgBook.Image.Save(stream, ImgBook.Image.RawFormat);
            return stream.GetBuffer();

        }
        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadCategory()
        {
            ddlCategoryName.DataSource = BlTblCategory.LoadData();
            ddlCategoryName.ValueMember = "CategoryId";
            ddlCategoryName.DisplayMember = "CategoryName";
        }
        private void LoadLanguage()
        {
            ddlLanguage.DataSource = BlTblLanguage.LoadData();
            ddlLanguage.ValueMember = "LanguageId";
            ddlLanguage.DisplayMember = "LanguageName";
        }
        private void LoadAuthor()
        {
            ddlAuthor.DataSource = BlTblAuthor.LoadData();
            ddlAuthor.ValueMember = "AuthorId";
            ddlAuthor.DisplayMember = "AuthorName";
        }
        private void LoadEdition()
        {
            ddlEdition.DataSource = BlTblEdition.LoadData();
            ddlEdition.ValueMember = "EditionId";
            ddlEdition.DisplayMember = "EditionName";
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text == "")
            {
                lblBookName.Text = "Required";
            }
            else if (ddlCategoryName.Text == "")
            {
                lblCategoryName.Text = "Required";
            }
            else if (ddlLanguage.Text == "")
            {
                lblLanguage.Text = "Required";
            }
            else if (ddlAuthor.Text == "")
            {
                lblAuthor.Text = "Required";
            }
            else if (ddlEdition.Text == "")
            {
                lblEdition.Text = "Required";
            }
            else if (txtStock.Text == "")
            {
                lblStock.Text = "Required";
            }
            else if (txtStock.Text == "0")
            {
                lblStock.Text = "Enter '00'";
            }
            else if (txtDescription.Text == "")
            {
                lblDescription.Text = "Required";
            }
            else
            {
                try
                {
                    if (FrmBookList.BookId > 0)
                    {
                        DataTable dt = BlTblBook.GetDuplicateRecodInUpdate(txtBookName.Text, Convert.ToInt32(ddlCategoryName.SelectedValue), Convert.ToInt32(ddlLanguage.SelectedValue), Convert.ToInt32(ddlAuthor.SelectedValue), Convert.ToInt32(ddlEdition.SelectedValue), FrmBookList.BookId);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("This Category,Language,Author and Edition is already inseretd simultaneously");
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                BlTblBook obj = new BlTblBook();
                                obj.BookName = txtBookName.Text;
                                obj.CategoryId = Convert.ToInt32(ddlCategoryName.SelectedValue);
                                obj.LanguageId = Convert.ToInt32(ddlLanguage.SelectedValue);
                                obj.EditionId = Convert.ToInt32(ddlEdition.SelectedValue);
                                obj.AuthorId = Convert.ToInt32(ddlAuthor.SelectedValue);
                                obj.Stock = Convert.ToInt32(txtStock.Text);
                                obj.CreatedAt = DateTime.Now;
                                obj.Description = txtDescription.Text;
                                obj.BookId = FrmBookList.BookId;
                                obj.Image = GetImage();
                                if (BlTblBook.Create(obj) == 1)
                                {
                                    BlLog log = new BlLog();
                                    log.UserId = FrmLogin.LibrarianId;
                                    log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Updated a Book record successfully";
                                    log.datetime = DateTime.Now;
                                    BlLog.Save(log);
                                    txtBookName.Text = "";
                                    ddlCategoryName.Text = "";
                                    ddlLanguage.Text = "";
                                    ddlEdition.Text = "";
                                    ddlAuthor.Text = "";
                                    txtStock.Text = "";
                                    txtDescription.Text = "";
                                    ImgBook.Image = Resources.icons8_click_here;
                                    FrmBookList.BookId = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        DataTable dt = BlTblBook.GetDuplicateRecod(txtBookName.Text, Convert.ToInt32(ddlCategoryName.SelectedValue), Convert.ToInt32(ddlLanguage.SelectedValue), Convert.ToInt32(ddlAuthor.SelectedValue), Convert.ToInt32(ddlEdition.SelectedValue));
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("This Category,Language,Author and Edition is already inseretd simultaneously");
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                BlTblBook obj = new BlTblBook();
                                obj.BookName = txtBookName.Text;
                                obj.CategoryId = Convert.ToInt32(ddlCategoryName.SelectedValue);
                                obj.LanguageId = Convert.ToInt32(ddlLanguage.SelectedValue);
                                obj.AuthorId = Convert.ToInt32(ddlAuthor.SelectedValue);
                                obj.EditionId = Convert.ToInt32(ddlEdition.SelectedValue);
                                obj.Stock = Convert.ToInt32(txtStock.Text);
                                obj.CreatedAt = DateTime.Now;
                                obj.Description = txtDescription.Text;
                                obj.Image = GetImage();
                                if (BlTblBook.Create(obj) == 1)
                                {

                                    BlLog log = new BlLog();
                                    log.UserId = FrmLogin.LibrarianId;
                                    log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Inseretd a Book record successfully";
                                    log.datetime = DateTime.Now;
                                    BlLog.Save(log);
                                    txtBookName.Text = "";
                                    txtStock.Text = "";
                                    txtDescription.Text = "";
                                    ImgBook.Image = Resources.icons8_click_here;
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

        private void ImgBook_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG Files|*.jpg|PNG Files|*.png|GIF Files|*.gif|All Files|*.*;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImgBook.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ImgBook.Image = Resources.icons8_click_here;
        }

        private void lblList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBookList.BookId = 0;
            FrmBookList obj = new FrmBookList();
            this.Hide();
            obj.ShowDialog();
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') & (e.KeyChar != 08))
            {
                e.Handled = true;
            }
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            if (lblBookName.Text == "Required")
            {
                lblBookName.Text = "";
            }
        }

        private void ddlCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblCategoryName.Text == "Required")
            {
                lblCategoryName.Text = "";
            }
        }

        private void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblLanguage.Text == "Required")
            {
                lblLanguage.Text = "";
            }
        }

        private void ddlAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblAuthor.Text == "Required")
            {
                lblAuthor.Text = "";
            }
        }

        private void ddlEdition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblEdition.Text == "Required")
            {
                lblEdition.Text = "";
            }
        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {
            if (lblStock.Text == "Required" || lblStock.Text == "Enter '00'")
            {
                lblStock.Text = "";
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            if (lblDescription.Text == "Required")
            {
                lblDescription.Text = "";
            }
        }

        private void txtBookName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((txtBookName.TextLength == 0) & (e.KeyChar == 32))
            {
                e.Handled = true;
            }
        }
    }
}
