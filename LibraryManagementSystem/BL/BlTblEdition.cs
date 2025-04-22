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
    internal class BlTblEdition
    {
        public int EditionId { get; set; }
        public string EditionName { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }

        public static int Submit(BlTblEdition Edition)
        {
            SqlParameter[] prm = new SqlParameter[5];
            if (Edition.EditionId > 0)
            {
                prm[0] = new SqlParameter("@Type", "Update");
            }
            else
            {
                prm[0] = new SqlParameter("@Type", "Insert");
            }
            prm[1] = new SqlParameter("@EditionId", Edition.EditionId);
            prm[2] = new SqlParameter("@EditionName", Edition.EditionName);
            prm[3] = new SqlParameter("@Status", Edition.Status == "Active" ? 1 : 0);
            prm[4] = new SqlParameter("@CreatedAt", DateTime.Now);
            return DataAccess.SpExecuteQuery("SpTblEdition", prm);
        }
        public static int Delete(int id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Delete");
            prm[1] = new SqlParameter("@EditionId", id);
            return DataAccess.SpExecuteQuery("SpTblEdition", prm);
        }
        public static DataTable LoadData()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", "Select");
            return DataAccess.SpGetData("SpTblEdition", prm);
        }
        public static DataTable Check(string Name)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "CheckUser");
            prm[1] = new SqlParameter("@EditionName", Name);
            return DataAccess.SpGetData("SpTblEdition", prm);
        }
        public static DataTable CheckInUpdate(string Name,int id)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", "CheckInUpdate");
            prm[1] = new SqlParameter("@EditionName", Name);
            prm[2] = new SqlParameter("@EditionId", id);
            return DataAccess.SpGetData("SpTblEdition", prm);
        }
        public static DataTable Searching(string EditionName)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Search");
            prm[1] = new SqlParameter("@EditionName", EditionName);
            return DataAccess.SpGetData("SpTblEdition", prm);
        }
    }
}
