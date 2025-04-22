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
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void addLibrarianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLibrarianRegistration frmLibrarianRegistration = new FrmLibrarianRegistration();
            frmLibrarianRegistration.ShowDialog();
        }

        private void librarianListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLibrarianList frmLibrarianList = new FrmLibrarianList();
            frmLibrarianList.ShowDialog();
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBook frmBook = new FrmBook();
            frmBook.ShowDialog();
        }

        private void bookListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBookList frmBookList = new FrmBookList();
            frmBookList.ShowDialog();
        }

        private void addAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAuthor frmAuthor = new FrmAuthor();
            frmAuthor.ShowDialog();
        }

        private void authorListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAuthorList frmAuthorList = new FrmAuthorList();
            frmAuthorList.ShowDialog();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStudent frmStudent = new FrmStudent();
            frmStudent.ShowDialog();
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStudentList frmStudentList = new FrmStudentList();
            frmStudentList.ShowDialog();
        }

        private void addDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDepartment frmDepartment = new FrmDepartment();
            frmDepartment.ShowDialog();
        }

        private void deparToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDepartmentList frmDepartmentList = new FrmDepartmentList();
            frmDepartmentList.ShowDialog();
        }

        private void addSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSession frmSession = new FrmSession();
            frmSession.ShowDialog();
        }

        private void sessionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSessionList frmSessionList = new FrmSessionList();
            frmSessionList.ShowDialog();
        }

        private void addBookIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBookIssue frmBookIssue = new FrmBookIssue();
            frmBookIssue.ShowDialog();
        }

        private void bookIssueListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBookIssueList frmBookIssueList = new FrmBookIssueList();
            frmBookIssueList.ShowDialog();
        }

        private void addBookReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBookReturn frmBookReturn = new FrmBookReturn();
            frmBookReturn.ShowDialog();
        }

        private void bookReturnListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBookReturnList frmBookReturnList = new FrmBookReturnList();
            frmBookReturnList.ShowDialog();
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategory frmCategory = new FrmCategory();
            frmCategory.ShowDialog();
        }

        private void categoryListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategoryList frmCategoryList = new FrmCategoryList();
            frmCategoryList.ShowDialog();
        }

        private void addEditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEdition frmEdition = new FrmEdition();
            frmEdition.ShowDialog();
        }

        private void editionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEditionList frmEditionList = new FrmEditionList();
            frmEditionList.ShowDialog();
        }

        private void addLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLanguage frmLanguage = new FrmLanguage();
            frmLanguage.ShowDialog();
        }

        private void languageListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLanguageList frmLanguageList = new FrmLanguageList();
            frmLanguageList.ShowDialog();
        }

        private void ProgramtoolStrip_Click(object sender, EventArgs e)
        {
            FrmProgram obj = new FrmProgram();
            obj.ShowDialog();
        }

        private void programListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProgramList obj = new FrmProgramList();
            obj.ShowDialog();
        }
    }
}
