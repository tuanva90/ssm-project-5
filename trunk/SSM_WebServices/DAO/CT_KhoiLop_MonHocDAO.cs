using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
   public class CT_KhoiLop_MonHocDAO
    {
        ConectData conectData = new ConectData();

        public int Insert(string mamon, int makl_mon)//insert bang CT_KL_Mon 
        {
            string sql = "insert into CT_KHOILOP_MONHOC values (@mamon,@makl_mon)";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@mamon", mamon);
            sp[1] = new SqlParameter("@makl_mon", makl_mon);
            return conectData.Insert_Update_Delete(sql, sp);
        }

        public int Delete(string mamon, int makl_mon)// xoa dua vao mamon, maklmon
        {
            string sql = "delete from CT_KHOILOP_MONHOC where MaMon=@mamon and MaKLMH=@makl_mon";// xoa bang KHOILOP_MON theo ma nam va ma kl
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@mamon", mamon);
            sp[1] = new SqlParameter("@makl_mon", makl_mon);
            return conectData.Insert_Update_Delete(sql, sp); 
        }
        public bool Check(string manam, string mamon, string makhoi) // kiem tra xem mot khoi hoc da chon môn hoc này hay chưa
        {
            string sql = "select ct.CT_KLMH from CT_KHOILOP_MONHOC ct,KHOILOP_MONHOC kl, KHOILOP k where k.MaKhoiLop=kl.MaKhoiLop and k.MaNam=@manam and kl.MaKhoiLop=@makhoi and ct.MaMon=@mamon and ct.MaKLMH=kl.MaKLMH";
           // string sql = "select ct.CT_KLMH from CT_KHOILOP_MONHOC ct,KHOILOP_MONHOC kl,HOCKY hk where kl.MaNam=hk.MaNam and hk.MaHK=@mahk and kl.MaKhoiLop=@makhoi and ct.MaMon=@mamon and ct.MaKLMH=kl.MaKLMH";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@mamon", mamon);
            sp[1] = new SqlParameter("@manam", manam);
            sp[2] = new SqlParameter("@makhoi", makhoi);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt.Rows.Count==0)
                return false;
            else
                return true;
        }
        public int Get_MaCTKLMH(string manam, string mamon, string makhoi)
        {
            string sql = "select ct.CT_KLMH from CT_KHOILOP_MONHOC ct,KHOILOP_MONHOC kl, KHOILOP  where k.MaKhoiLop=kl.MaKhoiLop and k.MaNam=@manam and kl.MaKhoiLop=@makhoi and ct.MaMon=@mamon and ct.MaKLMH=kl.MaKLMH";
            // string sql = "select ct.CT_KLMH from CT_KHOILOP_MONHOC ct,KHOILOP_MONHOC kl,HOCKY hk where kl.MaNam=hk.MaNam and hk.MaHK=@mahk and kl.MaKhoiLop=@makhoi and ct.MaMon=@mamon and ct.MaKLMH=kl.MaKLMH";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@mamon", mamon);
            sp[1] = new SqlParameter("@manam", manam);
            sp[2] = new SqlParameter("@makhoi", makhoi);
            DataTable dt = conectData.LoadData(sql, sp);
            return int.Parse(dt.Rows[0][0].ToString());
        }
        public DataTable List_MH_KL(string manam, string makhoi) // lay danh sach mon hoc cua tung khoi lop
        {
            string sql = "select ctklmh.CT_KLMH,mh.TenMon as 'Tên môn',mh.MaMon as 'Mã môn' from CT_KHOILOP_MONHOC ctklmh, KHOILOP_MONHOC klmh, MONHOC mh, KHOILOP kl where kl.MaKhoiLop = klmh.MaKhoiLop and mh.MaMon=ctklmh.MaMon and ctklmh.MaKLMH = klmh.MaKLMH and kl.MaNam=@manam and klmh.MaKhoiLop=@makhoi";
            //string sql = "select ctklmh.CT_KLMH from CT_KHOILOP_MONHOC ctklmh, KHOILOP_MONHOC klmh, HOCKY hk where ctklmh.MaKLMH=klmh.MaKLMH and klmh.MaNam=hk.MaNam and hk.MaHK=@mahk and klmh.MaKHOILOP=@MaKhoi";
            SqlParameter[] sp = new SqlParameter[2];
             sp[0] = new SqlParameter("@manam", manam);
            sp[1] = new SqlParameter("@makhoi", makhoi);
            DataTable dt = conectData.LoadData(sql, sp);
            dt.TableName = "DT";
            return dt;
        }
        public DataTable Get_MaNam_MaKhoi(string mamon) // lay ma nam, ma khoi tu bang KL_MH khi biet mamon o bang CT_KL_/mh, khi them mot bang ct_kl_mh (tuc them mot mon hoc moi cho mot khoi lop thi pai them bdm_hk vao tat cac cac bang  hoc co manam la manam, makhoi la makhoi)
        {
            string sql = "select klmh.MaNam,klmh.MaKhoiLop from KHOILOP_MONHOC klmh, CT_KHOILOP_MONHOC ctklmh where ctklmh.MaKLMH=klmh.MaKLMH and ctklmh.MaMon=@mamon";
            SqlParameter sp = new SqlParameter("@mamon",mamon);
            DataTable dt = conectData.LoadData(sql, sp);
            dt.TableName = "dt";
            return dt;
        }
     }
}
