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
    internal class BlLog
    {
        public int LogId { get; set; }
        public int UserId { get; set; }
        public string Log { get; set; }
        public DateTime datetime { get; set; }
        public static int Save(BlLog obj)
        {
            SqlParameter[] prm = new SqlParameter[4];
            prm[0] = new SqlParameter("@Type", "Insert");
            prm[1] = new SqlParameter("@UserId", obj.UserId);
            prm[2] = new SqlParameter("@Log", obj.Log);
            prm[3] = new SqlParameter("@Datetime", obj.datetime);
            return DataAccess.SpExecuteQuery("SpLog", prm);
        } 
        public static int Delete(int logid)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type","Delete");
            prm[1] = new SqlParameter("@LogId", logid);
            return DataAccess.SpExecuteQuery("SpLog", prm);
        } 
        public static DataTable LoadData()
        {
            SqlParameter prm = new SqlParameter("@Type","Select");
            return DataAccess.SpGetData("SpLog", prm);
        }
    }
}
