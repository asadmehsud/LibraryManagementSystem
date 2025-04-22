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
    internal class BlTblDepartment
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int Status { get; set; }
        public byte[] Image { get; set; }

        public static int Submit(BlTblDepartment Department)
        {
            SqlParameter[] prm = new SqlParameter[5];
            if (Department.DepartmentId > 0)
            {
                prm[0] = new SqlParameter("@Type", "Update");
            }
            else
            {
                prm[0] = new SqlParameter("@Type", "Insert");
            }
            prm[1] = new SqlParameter("@DepartmentId", Department.DepartmentId);
            prm[2] = new SqlParameter("@DepartmentName", Department.DepartmentName);
            prm[3] = new SqlParameter("@Status", Department.Status);
            prm[4] = new SqlParameter("@Image", Department.Image);
            return DataAccess.SpExecuteQuery("SpTblDepartment", prm);
        }
        public static int Delete(int DepartmentId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Delete");
            prm[1] = new SqlParameter("@DepartmentId", DepartmentId);
            return DataAccess.SpExecuteQuery("SpTblDepartment", prm);
        }
        public static DataTable LoadData()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", "Select");
            return DataAccess.SpGetData("SpTblDepartment", prm);
        }
        public static DataTable LoadData(string DepartmentName=null, int? DepartmentId = null)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", "Select");
            prm[1] = new SqlParameter("@DepartmentId", DepartmentId);
            prm[2] = new SqlParameter("@DepartmentName", DepartmentName);
            return DataAccess.SpGetData("SpTblDepartment", prm);
        } 
        public static DataTable Searching(string DepartmentName)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Search");
            prm[1] = new SqlParameter("@DepartmentName", DepartmentName);
            return DataAccess.SpGetData("SpTblDepartment", prm);
        }
       
        public static DataTable CheckDepartment(int DepartmentId, string DepartmentName)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", "Select Department");
            prm[1] = new SqlParameter("@DepartmentId", DepartmentId);
            prm[2] = new SqlParameter("@DepartmentName", DepartmentName);
            return DataAccess.SpGetData("SpTblDepartment", prm);
        }
    }
}
