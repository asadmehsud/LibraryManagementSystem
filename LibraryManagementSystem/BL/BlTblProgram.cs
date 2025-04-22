using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystem.BL
{
    internal class BlTblProgram
    {

        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string Status { get; set; }

        public static void Submit(BlTblProgram Program)
        {
            SqlParameter[] prm = new SqlParameter[4];
            if (Program.ProgramId > 0)
            {
                prm[0] = new SqlParameter("@Type", "Update");
            }
            else
            {
                prm[0] = new SqlParameter("@Type", "Insert");
            }
            prm[1] = new SqlParameter("@ProgramId", Program.ProgramId);
            prm[2] = new SqlParameter("@ProgramName", Program.ProgramName);
            prm[3] = new SqlParameter("@Status", Program.Status == "Active" ? 1 : 0);
            DataAccess.SpExecuteQuery("SpTblProgram", prm);
        }
        public static void Delete(int ProgramId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Delete");
            prm[1] = new SqlParameter("@programId", ProgramId);
            DataAccess.SpExecuteQuery("SpTblProgram", prm);
        }
        public static DataTable LoadData()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", "Select");
            return DataAccess.SpGetData("SpTblProgram", prm);
        }
        public static DataTable LoadData(int ProgramId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Select");
            prm[1] = new SqlParameter("@programId", ProgramId);
            return DataAccess.SpGetData("SpTblProgram", prm);
        }
        public static DataTable LoadData(string ProgramName)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Select");
            prm[1] = new SqlParameter("@ProgramName", ProgramName);
            return DataAccess.SpGetData("SpTblProgram", prm);
        }
        public static DataTable CheckProgram(int ProgramId, string ProgramName)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", "Select Program");
            prm[1] = new SqlParameter("@ProgramId", ProgramId);
            prm[2] = new SqlParameter("@ProgramName", ProgramName);
            return DataAccess.SpGetData("SpTblProgram", prm);
        }
    }
}
