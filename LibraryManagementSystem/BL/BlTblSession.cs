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
    internal class BlTblSession
    {
        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public string Status { get; set; }

        public static int Submit(BlTblSession Session)
        {
            SqlParameter[] prm = new SqlParameter[4];
            if (Session.SessionId > 0)
            {
                prm[0] = new SqlParameter("@Type", "Update");
            }
            else
            {
                prm[0] = new SqlParameter("@Type", "Insert");
            }
            prm[1] = new SqlParameter("@SessionId", Session.SessionId);
            prm[2] = new SqlParameter("@SessionName", Session.SessionName);
            prm[3] = new SqlParameter("@Status", Session.Status == "Active" ? 1 : 0);
            return DataAccess.SpExecuteQuery("SpTblSession", prm);
        }
        public static int Delete(int SessionId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Delete");
            prm[1] = new SqlParameter("@SessionId", SessionId);
            return DataAccess.SpExecuteQuery("SpTblSession", prm);
        }
        public static DataTable LoadData()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", "Select");
            return DataAccess.SpGetData("SpTblSession", prm);
        }

        public static DataTable LoadData(string SessionName)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Select");
            prm[1] = new SqlParameter("@SessionName", SessionName);
            return DataAccess.SpGetData("SpTblSession", prm);
        }
        public static DataTable Searching(string SessionName = null, int? SessionId = null)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", "Search");
            prm[1] = new SqlParameter("@SessionId", SessionId);
            prm[2] = new SqlParameter("@SessionName", SessionName);
            return DataAccess.SpGetData("SpTblSession", prm);
        }
        public static DataTable CheckSession(string SessionName, int SessionId)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", "Select Session");
            prm[1] = new SqlParameter("@SessionName", SessionName);
            prm[2] = new SqlParameter("@SessionId", SessionId);
            return DataAccess.SpGetData("SpTblSession", prm);
        }
    }
}
