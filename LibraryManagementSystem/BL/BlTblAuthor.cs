using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BL
{
    internal class BlTblAuthor
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }
        public byte[] Image {  get; set; }

        public static int Register(BlTblAuthor Author)
        {
            SqlParameter[] prm = new SqlParameter[6];
            if(Author.AuthorId>0)
            {
                prm[0] = new SqlParameter("@Type", "Update");
            }
            else
            {
                prm[0] = new SqlParameter("@Type", "insert");
            }
            prm[1] = new SqlParameter("@AuthorId", Author.AuthorId);
            prm[2] = new SqlParameter("AuthorName", Author.AuthorName);
            prm[3] = new SqlParameter("Status", Author.Status == "Active" ? 1 : 0) ;
            prm[4] = new SqlParameter("CreatedAt", DateTime.Now);
            prm[5] = new SqlParameter("Image", Author.Image);
            return DataAccess.SpExecuteQuery("SpTblAuthor", prm);
        }
        public static int Delete(int id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Delete");
            prm[1] = new SqlParameter("@AuthorId", id);
            return DataAccess.SpExecuteQuery("SpTblAuthor", prm);
        }
        public static DataTable LoadData()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", "Select");
            return DataAccess.SpGetData("SpTblAuthor", prm);
        }
        public static DataTable Check(string Name)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Check User");
            prm[1] = new SqlParameter("@AuthorName", Name);
            return DataAccess.SpGetData("SpTblAuthor", prm);
        } 
        public static DataTable CheckInUpdate(string Name,int Authorid)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", "CheckUserInUpdate");
            prm[1] = new SqlParameter("@AuthorName", Name);
            prm[2] = new SqlParameter("@AuthorId", Authorid);
            return DataAccess.SpGetData("SpTblAuthor", prm);
        }
        public static DataTable Searching(string AuthorName)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Search");
            prm[1] = new SqlParameter("@AuthorName", AuthorName);
            return DataAccess.SpGetData("SpTblAuthor", prm);
        }
    }
}
