using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
   public class GhiChu_DAO
    {
        ConectData conectData = new ConectData();
             
        public int Insert(GhiChuDTO Gc)
        {
            string sql = "insert into GHICHU values (@MaGC,@MaHoc,@LyDo,@ChiTiet)";
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@MaGC", Gc.MaGC);
            sp[1] = new SqlParameter("@MaHoc", Gc.MaHoc);
            sp[2] = new SqlParameter("@LyDo", Gc.LyDo);
            sp[3] = new SqlParameter("@ChiTiet", Gc.ChiTiet);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int Update(GhiChuDTO Gc)
        {
            string sql = "update GHICHU set MaHoc=@MaHoc,LyDo=@LyDo,ChiTiet=@ChiTiet where MaGC=@MaGC";
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@MaGC", Gc.MaGC);
            sp[1] = new SqlParameter("@MaHoc", Gc.MaHoc);
            sp[2] = new SqlParameter("@LyDo", Gc.LyDo);
            sp[3] = new SqlParameter("@ChiTiet", Gc.ChiTiet);
            return conectData.Insert_Update_Delete(sql, sp);
        }
    
        public int Delete(string magc)
        {
            string sql = "delete from GHICHU where MaGC=@MaGC";
            SqlParameter sp = new SqlParameter("@MaGC", magc);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public DataTable List()
        {
            string sql = "select * from GHICHU";
            return conectData.LoadData(sql);
        }
    }
}
