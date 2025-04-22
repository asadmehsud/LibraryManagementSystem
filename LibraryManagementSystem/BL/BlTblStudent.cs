using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BL
{
    internal class BlTblStudent
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int DepartmentId { get; set; }
        public int ProgramId { get; set; }
        public int SessionId { get; set; }
        public string FatherName { get; set; }
        public int RollNO { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Cnic { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FatherCnic { get; set; }
        public byte[] Image { get; set; }

        public static int Register(BlTblStudent student)
        {
            SqlParameter[] prm = new SqlParameter[15];
            if (student.StudentId > 0)
            {
                prm[0] = new SqlParameter("@Type", "Update");
            }
            else
            {
                prm[0] = new SqlParameter("@Type", "Insert");
            }
            prm[1] = new SqlParameter("@StudentId", student.StudentId);
            prm[2] = new SqlParameter("@StudentName", student.StudentName);
            prm[3] = new SqlParameter("@DepartmentId", student.DepartmentId);
            prm[4] = new SqlParameter("@Program", student.ProgramId);
            prm[5] = new SqlParameter("@SessionId", student.SessionId);
            prm[6] = new SqlParameter("@FatherName", student.FatherName);
            prm[7] = new SqlParameter("@RollNO", student.RollNO);
            prm[8] = new SqlParameter("@ContactNO", student.ContactNo);
            prm[9] = new SqlParameter("@Address", student.Address);
            prm[10] = new SqlParameter("@Cnic", student.Cnic);
            prm[11] = new SqlParameter("@Gender", student.Gender);
            prm[12] = new SqlParameter("@CreatedAt", student.CreatedAt);
            prm[13] = new SqlParameter("@FatherCnic", student.FatherCnic);
            prm[14] = new SqlParameter("@Image", student.Image);
            return DataAccess.SpExecuteQuery("SpTblStudent", prm);
        }
        public static int Delete(int studentid)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Delete");
            prm[1] = new SqlParameter("@StudentId", studentid);
            return DataAccess.SpExecuteQuery("SpTblStudent", prm);
        }
        public static DataTable LoadData()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", "Select");
            return DataAccess.SpGetData("SpTblStudent", prm);
        } 
        public static DataTable LoadStudent()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", "LoadStudent");
            return DataAccess.SpGetData("SpTblStudent", prm);
        }
        public static DataTable Searching(string ColumnName, string value)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Search");
            prm[1] = new SqlParameter("@" + ColumnName, value);
            return DataAccess.SpGetData("SpTblStudent", prm);
        }
        public static DataTable LoadMaxStId()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", "LoadMaxStId");
            return DataAccess.SpGetData("SpTblStudent", prm);
        }
        public static DataTable CheckDuplicateRecord(string value)
        {
            SqlParameter[] prm = new SqlParameter[4];
            prm[0] = new SqlParameter("@Type", "CheckDuplicateRecord");
            prm[1] = new SqlParameter("@ContactNo", value);
            prm[2] = new SqlParameter("@Cnic", value);
            prm[3] = new SqlParameter("@FatherCnic", value);
            return DataAccess.SpGetData("SpTblStudent", prm);
        }
       
        public static DataTable CheckDuplicateRecordForUpdate(string value, int studentid)
        {
            SqlParameter[] prm = new SqlParameter[5];
            prm[0] = new SqlParameter("@Type", "CheckDuplicateRecordForUpdate");
            prm[1] = new SqlParameter("@ContactNo", value);
            prm[2] = new SqlParameter("@Cnic", value);
            prm[3] = new SqlParameter("@FatherCnic", value);
            prm[4] = new SqlParameter("@StudentId", studentid);
            return DataAccess.SpGetData("SpTblStudent", prm);
        }  
        public static DataTable CheckDuplicateRecordOverall(int RollNo, int Department, int Program, int session)
        {
            SqlParameter[] prm = new SqlParameter[5];
            prm[0] = new SqlParameter("@Type", "CheckDuplicateRecordOverall");
            prm[1] = new SqlParameter("@RollNo", RollNo);
            prm[2] = new SqlParameter("@DepartmentId", Department);
            prm[3] = new SqlParameter("@Program", Program);
            prm[4] = new SqlParameter("@SessionId", session);
            return DataAccess.SpGetData("SpTblStudent", prm);
        }
        public static DataTable CheckDuplicateRecordOverallForUpdate(int RollNo,int Department, int Program, int session,int studentid)
        {
            SqlParameter[] prm = new SqlParameter[6];
            prm[0] = new SqlParameter("@Type", "CheckDuplicateRecordOverallForUpdate");
            prm[1] = new SqlParameter("@RollNo", RollNo);
            prm[2] = new SqlParameter("@DepartmentId", Department);
            prm[3] = new SqlParameter("@Program", Program);
            prm[4] = new SqlParameter("@SessionId", session);
            prm[5] = new SqlParameter("@StudentId", studentid);
            return DataAccess.SpGetData("SpTblStudent", prm);
        }
    }
}
