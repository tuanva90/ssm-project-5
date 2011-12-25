using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class HocSinh_LenCap_DAO
    {
        ConectData conectData = new ConectData();
         public int Insert(HocSinh_LenCapDTO Hs_lc)
        {
            string sql = "insert into HOCSINH_LENCAP values (@MaHS_LC,@MaHS,@DTB,@HanhKiem)";
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@MaHS_LC", Hs_lc.MaHS_LC);
            sp[1] = new SqlParameter("@MaHS", Hs_lc.MaHS);
            sp[2] = new SqlParameter("@DTB", Hs_lc.DTB);
            sp[3] = new SqlParameter("@HanhKiem", Hs_lc.HanhKiem);
            return conectData.Insert_Update_Delete(sql, sp);
        }

        public int Update(HocSinh_LenCapDTO Hs_lc)
        {
            string sql = "update HOCSINH_LENCAP set MaHS=@MaHS,DTB=@DTB,HanhKiem=@HanhKiem where MaHS_LC=@MaHS_LC";
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@MaHS_LC", Hs_lc.MaHS_LC);
            sp[1] = new SqlParameter("@MaHS", Hs_lc.MaHS);
            sp[2] = new SqlParameter("@DTB", Hs_lc.DTB);
            sp[3] = new SqlParameter("@HanhKiem", Hs_lc.HanhKiem);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int Delete(string mahslc)
        {
            string sql = "delete from HOCSINH_LENCAP where MaHS_LC=@MaHSLC";
            SqlParameter sp = new SqlParameter("@MaHSLC", mahslc);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public DataTable List()
        {
            string sql = "select * from HOCSINH_LENCAP";
            return conectData.LoadData(sql);
        }
        // cac ham select se duoc viet tiep o day.
    }
}
