using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BL
{
    internal class BlTblBook
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
        public int EditionId { get; set; }
        public int AuthorId { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public static int Create(BlTblBook Book)
        {
            SqlParameter[] prm = new SqlParameter[11];
            if (Book.BookId > 0)
            {
                prm[0] = new SqlParameter("@Type", "Update");
            }
            else
            {
                prm[0] = new SqlParameter("@Type", "Insert");
            }
            prm[1] = new SqlParameter("@BookId", Book.BookId);
            prm[2] = new SqlParameter("@BookName", Book.BookName);
            prm[3] = new SqlParameter("@CategoryId", Book.CategoryId);
            prm[4] = new SqlParameter("@LanguageId", Book.LanguageId);
            prm[5] = new SqlParameter("@EditionId", Book.EditionId);
            prm[6] = new SqlParameter("@AuthorId", Book.AuthorId);
            prm[7] = new SqlParameter("@Stock", Book.Stock);
            prm[8] = new SqlParameter("@CreatedAt", Book.CreatedAt);
            prm[9] = new SqlParameter("@Description", Book.Description);
            prm[10] = new SqlParameter("@Image", Book.Image);
            return DataAccess.SpExecuteQuery("[SpTblBook]", prm);
        }
        public static int Delete(int BookId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Delete");
            prm[1] = new SqlParameter("@BookId", BookId);
            return DataAccess.SpExecuteQuery("SpTblBook", prm);
        }
        public static DataTable LoadData(int? BookID=null)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Select");
            prm[1] = new SqlParameter("@BookId", BookID);
            return DataAccess.SpGetData("SpTblBook", prm);
        }
        public static DataTable GetDuplicateRecod(string BookName,int CategoryId, int LanguageId, int EditionId, int AuthorId)
        {
            SqlParameter[] prm = new SqlParameter[6];
            prm[0] = new SqlParameter("@Type", "GetDuplicateRecod");
            prm[1] = new SqlParameter("@BookName", BookName);
            prm[2] = new SqlParameter("@CategoryId", CategoryId);
            prm[3] = new SqlParameter("@LanguageId", LanguageId);
            prm[4] = new SqlParameter("@EditionId", EditionId);
            prm[5] = new SqlParameter("@AuthorId", AuthorId);
            return DataAccess.SpGetData("SpTblBook", prm);
        }
        public static DataTable GetDuplicateRecodInUpdate(string BookName,int CategoryId, int LanguageId, int AuthorId, int EditionId, int BookId)
        {
            SqlParameter[] prm = new SqlParameter[7];
            prm[0] = new SqlParameter("@Type", "GetDuplicateRecodInUpdate");
            prm[1] = new SqlParameter("@BookName", BookName);
            prm[2] = new SqlParameter("@CategoryId", CategoryId);
            prm[3] = new SqlParameter("@LanguageId", LanguageId);
            prm[4] = new SqlParameter("@AuthorId", AuthorId);
            prm[5] = new SqlParameter("@EditionId", EditionId);
            prm[6] = new SqlParameter("@BookId", BookId);
            return DataAccess.SpGetData("SpTblBook", prm);
        }
        public static DataTable Searching(string Bookname)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Search");
            prm[1] = new SqlParameter("@BookName", Bookname);
            return DataAccess.SpGetData("SpTblBook", prm);
        } 
        public static int UpdateStock(int stock,int Bookid)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", "UpdateStock");
            prm[1] = new SqlParameter("@Stock", stock);
            prm[2] = new SqlParameter("@BookId", Bookid);
            return DataAccess.SpExecuteQuery("SpTblBook", prm);
        }
    }
}
