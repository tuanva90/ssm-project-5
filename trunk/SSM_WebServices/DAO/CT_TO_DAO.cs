using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class CT_TO_DAO
    {
        ConectData conectData = new ConectData();
               
          public int Insert(CT_ToDTO Ct_to)
        {
            string sql = "insert into CT_TO values (@MaTo,@MaMon)";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaTo", Ct_to.MaTo);
            sp[1] = new SqlParameter("@MaMon", Ct_to.MaMon);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int Delete(string MaTo, string MaMon)
        {
            string sql = "delete from CT_TO where MaTo=@MaTo and MaMon=@MaMon)";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaTo", MaTo);
            sp[1] = new SqlParameter("@MaMon",MaMon);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        // cac ham select se duoc viet tiep o day.
    }
}
