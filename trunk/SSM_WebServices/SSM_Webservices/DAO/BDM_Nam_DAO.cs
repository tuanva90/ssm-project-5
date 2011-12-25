using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class BDM_Nam_DAO
    {
        ConectData conectData = new ConectData();
        public int Insert(BDM_NamDTO Bdm_nam)
        {
            string sql = "insert into BDM_NAM values (@MaHS,@MaLop,@CT_KLMH,@DTBMon_Nam,@MaNam)";
            SqlParameter[] sp = new SqlParameter[5];
            sp[0]= new SqlParameter("@MaHS", Bdm_nam.MaHS);
            sp[1] = new SqlParameter("@MaLop", Bdm_nam.MaLop);
            sp[2] = new SqlParameter("@CT_KLMH", Bdm_nam.CT_KLMH);
            sp[3] = new SqlParameter("@DTBMon_Nam", Bdm_nam.DTBMon_Nam);
            sp[4] = new SqlParameter("@MaNam", Bdm_nam.MaNam);
            return conectData.Insert_Update_Delete(sql, sp);
        }

        public int Update(int maBDM_Nam, float dtbm_nam)
        {
            string sql = "update BDM_NAM set DTBMon_Nam=@DTBMon_Nam where MaBDM_Nam=@MaBDM_Nam";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaBDM_Nam",maBDM_Nam);
           sp[1] = new SqlParameter("@DTBMon_Nam", dtbm_nam);
            return conectData.Insert_Update_Delete(sql, sp);
        }
      
        public int Delete(string mabdm_nam)
        {
            string sql = "delete from BDM_NAM where MaBDM_Nam=@MaBDM_Nam";
            SqlParameter sp = new SqlParameter("@MaBDM_Nam", mabdm_nam);
             return conectData.Insert_Update_Delete(sql, sp);
        }
        public int Get_MaBDMNam(string mahs, string malop, int ctklmh, string manam) // lấy về MaBDMNam cua bang BDM_NAM, neu gia tri tra ve la khong thi bảng nay chua duoc tạo(có thể dugn2 để kiểm tra một bảng nay, voi cac tham so truyenvao nhu tren da duoc tao hay chua)
        {
            string sql = "select MaBDM_NAM from BDM_NAM where MaHS=@MaHS and MaLop=@MaLop and CT_KLMH=@CTKLMH and MaNam=@MaNam";
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@MaHS", mahs);
            sp[1] = new SqlParameter("@MaLop", malop);
            sp[2] = new SqlParameter("@CTKLMH", ctklmh);
            sp[3] = new SqlParameter("@MaNam", manam);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt.Rows.Count == 0)
                return 0;
            else
                return int.Parse(dt.Rows[0][0].ToString());

        }
          public DataTable List()
        {
            string sql = "select * from BDM_NAM";
            return conectData.LoadData(sql);
        }
    }
}
