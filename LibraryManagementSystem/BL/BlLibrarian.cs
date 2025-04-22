using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LibraryManagementSystem.BL
{
    internal class BlLibrarian
    {
        public int LibrarianId { get; set; }
        public string FIrstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Cnic { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Otp { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public string OTP { get; set; }
        public static int Save(BlLibrarian obj)
        {
            SqlParameter[] prm = new SqlParameter[13];
            prm[0] = new SqlParameter("@Type", "Insert");
            prm[1] = new SqlParameter("@FirstName", obj.FIrstName);
            prm[2] = new SqlParameter("@LastName", obj.LastName);
            prm[3] = new SqlParameter("@UserName", obj.UserName);
            prm[4] = new SqlParameter("@Email", obj.Email);
            prm[5] = new SqlParameter("@MobileNo", obj.MobileNo);
            prm[6] = new SqlParameter("@Cnic", obj.Cnic);
            prm[7] = new SqlParameter("@Password", obj.Password);
            prm[8] = new SqlParameter("@Address", obj.Address);
            prm[9] = new SqlParameter("@Role", obj.Role);
            prm[10] = new SqlParameter("@Otp", "null");
            prm[11] = new SqlParameter("@Image", obj.Image);
            prm[12] = new SqlParameter("@CreatedAt", DateTime.Now);
            return DataAccess.SpExecuteQuery("SpTblLibrarian", prm);
        }
        public static int Update(BlLibrarian obj)
        {
            SqlParameter[] prm = new SqlParameter[14];
            prm[0] = new SqlParameter("@Type", "Update");
            prm[1] = new SqlParameter("@FirstName", obj.FIrstName);
            prm[2] = new SqlParameter("@LastName", obj.LastName);
            prm[3] = new SqlParameter("@UserName", obj.UserName);
            prm[4] = new SqlParameter("@Email", obj.Email);
            prm[5] = new SqlParameter("@MobileNo", obj.MobileNo);
            prm[6] = new SqlParameter("@Cnic", obj.Cnic);
            prm[7] = new SqlParameter("@Password", obj.Password);
            prm[8] = new SqlParameter("@Address", obj.Address);
            prm[9] = new SqlParameter("@Role", obj.Role);
            prm[10] = new SqlParameter("@OTP", "null");
            prm[11] = new SqlParameter("@Image", obj.Image);
            prm[12] = new SqlParameter("@CreatedAt", DateTime.Now);
            prm[13] = new SqlParameter("@LibrarianId", obj.LibrarianId);
            return DataAccess.SpExecuteQuery("SpTblLibrarian", prm);
        }
        public static int Delete(int LibrarianId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Delete");
            prm[1] = new SqlParameter("@LibrarianId", LibrarianId);
            return DataAccess.SpExecuteQuery("SpTblLibrarian", prm);
        }
        public static DataTable GetData(string Email=null, string MobileNo = null, string UserName = null)
        {
            SqlParameter[] prm = new SqlParameter[4];
            prm[0] = new SqlParameter("@Type", "Select");
            prm[1] = new SqlParameter("@Email", Email);
            prm[2] = new SqlParameter("@MobileNo", MobileNo);
            prm[3] = new SqlParameter("@UserName", UserName);
            return DataAccess.SpGetData("SpTblLibrarian", prm);
        }
       
        public static DataTable Searching(string ColumnName, string Value)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Search");
            prm[1] = new SqlParameter("@" + ColumnName, Value);
            return DataAccess.SpGetData("SpTblLibrarian", prm);
        }
        public static DataTable CheckUser(string ColumnName, string Value)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "GetDuplicateUser");
            prm[1] = new SqlParameter("@" + ColumnName, Value);
            return DataAccess.SpGetData("SpTblLibrarian", prm);
        }
        public static DataTable CheckUserInUpdate(string ColumnName, string Value, int LibrarianId)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", "GetDuplicateUserInUpdate");
            prm[1] = new SqlParameter("@" + ColumnName, Value);
            prm[2] = new SqlParameter("@LibrarianId", LibrarianId);
            return DataAccess.SpGetData("SpTblLibrarian", prm);
        }
        public static DataTable Login(string value)
        {
            SqlParameter[] prm = new SqlParameter[4];
            prm[0] = new SqlParameter("@Type", "CheckForLogin");
            prm[1] = new SqlParameter("@UserName", value);
            prm[2] = new SqlParameter("@MobileNo", value);
            prm[3] = new SqlParameter("@Email", value);
            return DataAccess.SpGetData("SpTblLibrarian", prm);
        }
        public static DataTable Login(string value, string Password)
        {
            SqlParameter[] prm = new SqlParameter[5];
            prm[0] = new SqlParameter("@Type", "CheckForLoginWithPassword");
            prm[1] = new SqlParameter("@UserName", value);
            prm[2] = new SqlParameter("@MobileNo", value);
            prm[3] = new SqlParameter("@Email", value);
            prm[4] = new SqlParameter("@Password", Password);
            return DataAccess.SpGetData("SpTblLibrarian", prm);
        }
        public static DataTable ChangePassword(string value)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", "SelectUser");
            prm[1] = new SqlParameter("@Email", value);
            prm[2] = new SqlParameter("@MobileNo", value);
            return DataAccess.SpGetData("SpTblLibrarian", prm);
        }
        public static DataTable ChangePassword(string value, string password)
        {
            SqlParameter[] prm = new SqlParameter[4];
            prm[0] = new SqlParameter("@Type", "SelectUserAndPassword");
            prm[1] = new SqlParameter("@Email", value);
            prm[2] = new SqlParameter("@MobileNo", value);
            prm[3] = new SqlParameter("@Password", password);
            return DataAccess.SpGetData("SpTblLibrarian", prm);
        }
        public static int UpdatePassword(string password, string value)
        {
            SqlParameter[] prm = new SqlParameter[4];
            prm[0] = new SqlParameter("@Type", "ChangePassword");
            prm[1] = new SqlParameter("@Password", password);
            prm[2] = new SqlParameter("@Email", value);
            prm[3] = new SqlParameter("@MobileNo", value);
           return DataAccess.SpExecuteQuery("SpTblLibrarian", prm);
        }
        public static DataTable CheckOtp(string Email, string OTP)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", "CheckOtp");
            prm[1] = new SqlParameter("@Email", Email);
            prm[2] = new SqlParameter("@OTP", OTP);
            return DataAccess.SpGetData("SpTblLibrarian", prm);
        }
        public static int GenerateOTP(string Email, string OTP)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", "SaveOtp");
            prm[1] = new SqlParameter("@Email", Email);
            prm[2] = new SqlParameter("@OTP", OTP);
            int check = DataAccess.SpExecuteQuery("SpTblLibrarian", prm);
            return check;
        }
        public static DataTable GetDuplicateUserInTblStudent(string value)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", "GetDuplicateUserInTblStudent");
            prm[1] = new SqlParameter("@ContactNo", value);
            prm[2] = new SqlParameter("@Cnic", value);
            return DataAccess.SpGetData("SpTblLibrarian", prm);
        }
        public static DataTable LoadLibrarian()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", "LoadLibrarian");
            return DataAccess.SpGetData("SpTblLibrarian", prm);
        }
    }
}
