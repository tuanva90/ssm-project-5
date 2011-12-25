using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;


namespace DAO
{
   public class KhoiLop_MonHocDAO
    {
        ConectData conectData = new ConectData();

        public int Insert(string manam, string makhoi)
        {
            string sql = "insert into KHOILOP_MONHOC values (@manam,@makhoi)";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@manam", manam);
            sp[1] = new SqlParameter("@makhoi", makhoi);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int Delete(string manam, string makhoi)
        {
            string sql = "delete from KHOILOP_MONHOC where MaNam=@manam and MaKhoiLop=@makl";// xoa bang KHOILOP_MON theo ma nam va ma kl
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@manam", manam);
            sp[1] = new SqlParameter("@makhoi", makhoi);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int GetMa(string manam, string makhoi) // lay ma KhoiLop_mon dua vao ma nam va ma khoi lop
        {
            string sql = "select * from KHOILOP_MONHOC where MaNam=@manam and MaKhoiLop=@makl";//
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@manam", manam);
            sp[1] = new SqlParameter("@makl", makhoi);
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql, sp);
            dt.TableName = "dt";
            return int.Parse(dt.Rows[0][0].ToString());
            
        }
    }
}
