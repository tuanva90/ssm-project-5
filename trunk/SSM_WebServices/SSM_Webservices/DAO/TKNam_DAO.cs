using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
   public class TKNam_DAO
    {
        ConectData conectData = new ConectData();
        public int Insert(TKNAMDTO Tkn)
        {
            string sql = "insert into TKNAM values (@MaHS,@DiemCuoiNam,@HKCuoiNam,@MaNam)";
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@MaHS", Tkn.MaHS);
            sp[1] = new SqlParameter("@DiemCuoiNam", Tkn.DiemCuoiNam);
            sp[2] = new SqlParameter("@HKCuoiNam", Tkn.HKCuoiNam);
            sp[3] = new SqlParameter("@MaNam", Tkn.MaNam);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int UpdateDiemCuoiNam(string manam, string mahs, float diemcuoinam)
        {
            string sql = "update TKNAM set DiemCuoiNam=@DiemCuoiNam where MaHS=@MaHS and MaNam=@MaNam";
            SqlParameter[] sp = new SqlParameter[3];
             sp[0] = new SqlParameter("@MaHS", mahs);
            sp[1] = new SqlParameter("@DiemCuoiNam",diemcuoinam);
              sp[2] = new SqlParameter("@MaNam", manam);
            return conectData.Insert_Update_Delete(sql, sp);
        } 
       public int UpdateHKCuoiNam(string manam, string mahs, string hkcuoinam)
        {
            string sql = "update TKNAM set HKCuoiNam=@hkcuoinam where MaHS=@MaHS and MaNam=@MaNam";
            SqlParameter[] sp = new SqlParameter[3];
             sp[0] = new SqlParameter("@MaHS", mahs);
            sp[1] = new SqlParameter("@hkcuoinam", hkcuoinam);
              sp[2] = new SqlParameter("@MaNam", manam);
            return conectData.Insert_Update_Delete(sql, sp);
        } 
        public int Delete(string manam, string mahs)
        {
            string sql = "delete from TKNAM where MaHS=@MaHS and MaNam=@MaNam";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaHS", mahs);
            sp[1] = new SqlParameter("@MaNam", manam);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public DataTable List()
        {
            string sql = "select * from TKNAM";
            return conectData.LoadData(sql);
        }
        public int GetMaBTKN(string manam, string mahs) // lấy ma MaBTKN cua bảng TKNAM voi tham so truyen vao : manam, mahs, neu chua ton tai (tuc chua them bang nay voi manam,mahs duoc truyen vao) thi trả về 0 ( dùng để kiểm tra xem đã tồn tại bảng với giá tri truyền vào hay chưa
        {
            string sql = "select MaBTKN from TKNAM where MaHS=@MaHS and MaNam=@MaNam";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaHS", mahs);
            sp[1] = new SqlParameter("@MaNam", manam);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt.Rows.Count == 0)
                return 0;
            else
                return int.Parse(dt.Rows[0]["MaBTKN"].ToString());
        }
        public string get_HKCuoiNam(string manam, string mahs)
        {
            string sql = "select HKCuoiNam from TKNAM where MaHS=@MaHS and MaNam=@MaNam";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaHS", mahs);
            sp[1] = new SqlParameter("@MaNam", manam);
            DataTable dt = conectData.LoadData(sql, sp);
            return dt.Rows[0]["HKCuoiNam"].ToString();
        }
        public float get_DiemCuoiNam(string manam, string mahs)
        {
            string sql = "select DiemCuoiNam from TKNAM where MaHS=@MaHS and MaNam=@MaNam";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaHS", mahs);
            sp[1] = new SqlParameter("@MaNam", manam);
            DataTable dt = conectData.LoadData(sql, sp);
            return float.Parse(dt.Rows[0]["DiemCuoiNam"].ToString());
        }
       // cac ham select se duoc viet tiep o day. 
    }
}
