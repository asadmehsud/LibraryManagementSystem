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
    internal class BlTblCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public static int Submit(BlTblCategory Category)
        {
            SqlParameter[] prm = new SqlParameter[5];
            if (Category.CategoryId > 0)
            {
                prm[0] = new SqlParameter("@Type", "Update");
            }
            else
            {
                prm[0] = new SqlParameter("@Type", "Insert");
            }
            prm[1] = new SqlParameter("@CategoryId", Category.CategoryId);
            prm[2] = new SqlParameter("@CategoryName", Category.CategoryName);
            prm[3] = new SqlParameter("@Status", Category.Status == "Active" ? 1 : 0);
            prm[4] = new SqlParameter("@CreatedAt", DateTime.Now);
            return DataAccess.SpExecuteQuery("SpTblCategory", prm);
        }
        public static int Delete(int id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Delete");
            prm[1] = new SqlParameter("@CategoryId", id);
            return DataAccess.SpExecuteQuery("SpTblCategory", prm);
        }
        public static DataTable LoadData()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", "Select");
            return DataAccess.SpGetData("SpTblCategory", prm);
        }
        public static DataTable Check(string Name)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "CheckUser");
            prm[1] = new SqlParameter("@CategoryName", Name);
            return DataAccess.SpGetData("SpTblCategory", prm);
        }
        public static DataTable CheckInUpdate(string Name, int Id)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", "CheckInUpdate");
            prm[1] = new SqlParameter("@CategoryName", Name);
            prm[2] = new SqlParameter("@CategoryId", Id);
            return DataAccess.SpGetData("SpTblCategory", prm);
        }
        public static DataTable Searching(string CategoryName)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Search");
            prm[1] = new SqlParameter("@CategoryName", CategoryName);
            return DataAccess.SpGetData("SpTblCategory", prm);
        }

    }
}
