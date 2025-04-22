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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystem
{
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int ID;
        public void Edit(int id, string Name, int Status)
        {
            ID = id;
            txtCategoryName.Text = Name;
            ddlStatus.Text = Status == 1 ? "Active" : "Inactive";
            btnSubmit.Text = "Update";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text == "")
            {
                lblCategoryName.Text = "Required";
            }
            else if (ddlStatus.Text == "")
            {
                lblStatus.Text = "Required";
            }
            else
            {
                try
                {
                    BlTblCategory obj = new BlTblCategory();
                    obj.CategoryName = txtCategoryName.Text;
                    obj.Status = ddlStatus.Text;
                    if (btnSubmit.Text == "Update")
                    {
                        if (BlTblCategory.CheckInUpdate(obj.CategoryName,ID).Rows.Count > 0)
                        {
                            MessageBox.Show("This Category is Already ext");
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                obj.CategoryId = ID;
                                if (BlTblCategory.Submit(obj) == 1)
                                {
                                    BlLog log = new BlLog();
                                    log.UserId = FrmLogin.LibrarianId;
                                    log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Updated a Category record successfully";
                                    log.datetime = DateTime.Now;
                                    BlLog.Save(log);
                                    txtCategoryName.Text = "";
                                    ID = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (BlTblCategory.Check(txtCategoryName.Text).Rows.Count > 0)
                        {
                            MessageBox.Show("This Category is already exist");
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                if (BlTblCategory.Submit(obj) == 1)
                                {
                                    BlLog log = new BlLog();
                                    log.UserId = FrmLogin.LibrarianId;
                                    log.Log = "This Librarian '" + FrmLogin.LibrarianName + "' has Inserted a Category record successfully";
                                    log.datetime = DateTime.Now;
                                    BlLog.Save(log);
                                    txtCategoryName.Text = "";
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

        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            if (lblCategoryName.Text == "Required")
            {
                lblCategoryName.Text = "";
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
            FrmCategoryList obj = new FrmCategoryList();
            this.Hide();
            obj.ShowDialog();
        }

        private void txtCategoryName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((txtCategoryName.TextLength == 0) & (e.KeyChar == 32))
            {
                e.Handled = true;
            }
        }
    }
}
