using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BL
{
    internal class BlTblBookIssue
    {
      public int BookIssueId { get; set; }
        public int LibrarianId {  get; set; }
        public int BookId { get; set; }
        public int StudentId {  get; set; }
        public string IssueDate { get; set; }

        public static int Issue(BlTblBookIssue issue)
        {
            SqlParameter[] prm = new SqlParameter[6];
            if(issue.BookIssueId>0)
            {
                prm[0] = new SqlParameter("@Type", "Update");
            }
            else
            {
                prm[0] = new SqlParameter("@Type", "Insert");
            }
            prm[1] = new SqlParameter("@BookIssueId",issue.BookIssueId);
            prm[2] = new SqlParameter("@LibrarianId",issue.LibrarianId);
            prm[3] = new SqlParameter("@BookId", issue.BookId);
            prm[4] = new SqlParameter("@StudentId", issue.StudentId);
            prm[5] = new SqlParameter("@IssueDate", issue.IssueDate);
            return DataAccess.SpExecuteQuery("SpTblBookIssue", prm);
        }
        public static int Delete(int BookIssueId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Delete");
            prm[1] = new SqlParameter("@BookIssueId", BookIssueId);
            return DataAccess.SpExecuteQuery("SpTblBookIssue", prm);
        }
        public static DataTable LoadData()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", "Select");
            return DataAccess.SpGetData("SpTblBookIssue", prm);
        }
        public static DataTable Searching(string Bookname)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Search");
            prm[1] = new SqlParameter("@BookName", Bookname);
            return DataAccess.SpGetData("SpTblBookIssue", prm);
        }
    }
}
