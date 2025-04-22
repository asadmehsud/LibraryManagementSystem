using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryManagementSystem.BL
{
    internal class BlTblLanguage
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }

        public static int Submit(BlTblLanguage Language)
        {
            SqlParameter[] prm = new SqlParameter[5];
            if (Language.LanguageId > 0)
            {
                prm[0] = new SqlParameter("@Type", "Update");
            }
            else
            {
                prm[0] = new SqlParameter("@Type", "Insert");
            }
            prm[1] = new SqlParameter("@Languageid", Language.LanguageId);
            prm[2] = new SqlParameter("@LanguageName", Language.LanguageName);
            prm[3] = new SqlParameter("@Status", Language.Status == "Active" ? 1 : 0);
            prm[4] = new SqlParameter("@CreatedAt", DateTime.Now);
            return DataAccess.SpExecuteQuery("SpTblLanguage", prm);
        }
        public static int Delete(int id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Delete");
            prm[1] = new SqlParameter("@LanguageId", id);
            return DataAccess.SpExecuteQuery("SpTblLanguage", prm);
        }
        public static DataTable LoadData()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", "Select");
            return DataAccess.SpGetData("SpTblLanguage", prm);
        }
        public static DataTable Check(string Name)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "CheckUser");
            prm[1] = new SqlParameter("@LanguageName", Name);
            return DataAccess.SpGetData("SpTblLanguage", prm);
        }
        public static DataTable CheckInUpdate(string Name,int id)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", "CheckInUpdate");
            prm[1] = new SqlParameter("@LanguageName", Name);
            prm[2] = new SqlParameter("@LanguageId", id);
            return DataAccess.SpGetData("SpTblLanguage", prm);
        }
        public static DataTable Searching(string Language)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", "Search");
            prm[1] = new SqlParameter("@LanguageName", Language);
            return DataAccess.SpGetData("SpTblLanguage", prm);
        }

    }
}
