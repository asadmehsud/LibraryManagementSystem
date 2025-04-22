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
    internal class BlTblBookReturn
    {
      public int BookReturnId { get; set; }
        public int LibrarianId { get; set; }
        public int BookId { get; set; }
        public int StudentId { get; set; }
        public string ReturnDate { get; set; }

        public static int Return(BlTblBookReturn Return)
        {
            SqlParameter[] prm = new SqlParameter[6];
            if(Return.BookReturnId>0)
            {
                prm[0] = new SqlParameter("@Type", "Update");
            }
            else
            {
                prm[0] = new SqlParameter("@Type", "Insert");
            }
            prm[1] = new SqlParameter("@BookReturnId", Return.BookReturnId);
            prm[2] = new SqlParameter("@LibrarianId", Return.LibrarianId);
            prm[3] = new SqlParameter("@BookId", Return.BookId);
            prm[4] = new SqlParameter("@StudentId", Return.StudentId);
            prm[5] = new SqlParameter("@ReturnDate", Return.ReturnDate);
           return  DataAccess.SpExecuteQuery("SpTblBookReturn", prm);
        }
        public static int Delete(int BookReturnId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Delete");
            prm[1] = new SqlParameter("@BookReturnId", BookReturnId);
            return DataAccess.SpExecuteQuery("SpTblBookReturn", prm);
        }
        public static DataTable LoadData()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", "Select");
            return DataAccess.SpGetData("SpTblBookReturn", prm);
        }
        public static DataTable Searching(string Bookname)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Search");
            prm[1] = new SqlParameter("@BookName", Bookname);
            return DataAccess.SpGetData("SpTblBookReturn", prm);
        }
    }
}
