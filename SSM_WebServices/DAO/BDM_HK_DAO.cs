using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data.SqlClient;
using System.Data;


namespace DAO
{
   public class BDM_HK_DAO
    {

        ConectData conectData = new ConectData();      
        public int Insert(BDM_HKDTO Bdm_hk)
        {
            string sql = "insert into BDM_HK values (@MaHoc,@CT_KLMH,@DTBMon_HK,@DTBMon_KT)";
            SqlParameter[] sp = new SqlParameter[4];
              sp[0] = new SqlParameter("@MaHoc", Bdm_hk.MaHoc);
            sp[1] = new SqlParameter("@CT_KLMH", Bdm_hk.CT_KLMH);
            sp[2] = new SqlParameter("@DTBMon_HK", Bdm_hk.DTBMon_HK);
            sp[3] = new SqlParameter("@DTBMon_KT",Bdm_hk.DTBMon_KT);
            return conectData.Insert_Update_Delete(sql, sp);
        }

        public int UpdateDiemTBM(int mahoc, int ct_klmh,float diem)
        {
            string sql = "update BDM_HK set DTBMon_HK=@DTBMon_HK where MaHoc=@MaHoc and CT_KLMH=@ctklmh";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@MaHoc", mahoc);
            sp[1] = new SqlParameter("@ctklmh", ct_klmh);
            sp[2] = new SqlParameter("@DTBMon_HK", diem);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int UpdateDiemTBM_KT(int mahoc, int ct_klmh, float diem)
        {
            string sql = "update BDM_HK set DTBMon_KT=@DTBMon_KT where MaHoc=@MaHoc and CT_KLMH=@ctklmh";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@MaHoc", mahoc);
            sp[1] = new SqlParameter("@ctklmh", ct_klmh);
            sp[2] = new SqlParameter("@DTBMon_KT", diem);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public float GetDiemTBM_KT(int mahoc, int ct_klmh)
        {
            string sql = "select DTBMon_KT from BDM_HK where MaHoc=@MaHoc and CT_KLMH=@ctklmh";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaHoc", mahoc);
            sp[1] = new SqlParameter("@ctklmh", ct_klmh);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt.Rows.Count != 0)
                return float.Parse(dt.Rows[0][0].ToString());
            else
                return 0;
        }
        public float GetDiemTBM_HK(int mahoc, int ct_klmh)
        {
            string sql = "select DTBMon_HK from BDM_HK where MaHoc=@MaHoc and CT_KLMH=@ctklmh";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaHoc", mahoc);
            sp[1] = new SqlParameter("@ctklmh", ct_klmh);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt.Rows.Count == 0)
                return 0;
            else
                return float.Parse(dt.Rows[0][0].ToString());
        }
        public int Delete(int mahoc, int ctklmh )
        {
            string sql = "delete from BDM_HK where MaHoc=@mahoc and CT_KLMH=@ctklmh";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@mahoc", mahoc);
            sp[1] = new SqlParameter("@ctklmh",ctklmh);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int GetMaBDM_HK(int hoc, int ctklmh) // lay maBDMHK , khoa chinh cua bang BDM_HK
        {
            string sql = "Select MaBDM_HK from BDM_HK where MaHoc=@mahoc and CT_KLMH=@ctklmh";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@mahoc", hoc);
            sp[1] = new SqlParameter("@ctklmh", ctklmh);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt.Rows.Count == 0)
                return 0;
            else
                return int.Parse(dt.Rows[0][0].ToString());
        }
        public bool Check_MaCTKLMH_BDMHK( int ctklmh) // kiem tra xem mot mactklmh da co trong bang BDM_HK hay chua
        {
            string sql = "Select MaBDM_HK from BDM_HK where CT_KLMH=@ctklmh";
            SqlParameter sp = new SqlParameter("@ctklmh", ctklmh);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt.Rows.Count == 0)
                return false;
            else
                return true;

        }
        public DataTable getDiemCacMon(string manam, string tenhk, string makl, string mahs)// lay danh sach bang diem cua tat ca ca mon cua mot hoc sinh trong mot hoc ki
        {
            string sql = "select mh.MaMon, bdmhk.DTBMon_HK,mh.TenMon,mh.HeSo from HOC hoc , LOP lop, BDM_HK bdmhk,CT_KHOILOP_MONHOC ctklmh, MONHOC mh,HOCKY hk where ctklmh.MaMon=mh.MaMon and hk.MaHK=hoc.MaHK and hk.MaNam=@manam and hk.HocKy=@tenhk and hoc.MaLop=lop.MaLop and lop.MaKhoiLop=@makl and hoc.MaHoc = bdmhk.MaHoc and bdmhk.CT_KLMH=ctklmh.CT_KLMH and ctklmh.CT_KLMH in (select ctklmh1.CT_KLMH from CT_KHOILOP_MONHOC ctklmh1,KHOILOP_MONHOC klmh1 where ctklmh1.MaKLMH=klmh1.MaKLMH and klmh1.MaNam=@manam and klmh1.MaKhoiLop=@makl) and hoc.MaHS=@mahs";
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@mahs", mahs);
            sp[1] = new SqlParameter("@makl", makl);
            sp[2] = new SqlParameter("@tenhk", tenhk);
            sp[3] = new SqlParameter("@manam", manam);
            DataTable dt = conectData.LoadData(sql, sp);
            dt.TableName = "dt";
            return dt;
        }
        public DataTable List()//
        {
            string sql = "select * from BDM_HK";
            return conectData.LoadData(sql);
        }
        // cac ham select se duoc viet tiep o day.
    }
}
