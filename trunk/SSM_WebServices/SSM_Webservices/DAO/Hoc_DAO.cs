using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
   public class Hoc_DAO
    {
        ConectData conectData = new ConectData();
        
        public int Insert(HocDTO Hoc)
        {
            string sql = "insert into HOC values (@MaHS,@MaLop,@MaHK,@DiemCuoiKy,@HKCuoiKy,@ChucVu)";
            SqlParameter[] sp = new SqlParameter[6];
             sp[0] = new SqlParameter("@MaHS", Hoc.MaHS);
            sp[1] = new SqlParameter("@MaLop", Hoc.MaLop);
            sp[2] = new SqlParameter("@MaHK", Hoc.MaHK);
            sp[3] = new SqlParameter("@DiemCuoiKy", Hoc.DiemCuoiKy);
            sp[4] = new SqlParameter("@HKCuoiKy", Hoc.HKCuoiKy);
            sp[5] = new SqlParameter("@ChucVu", Hoc.MaCV);
            return conectData.Insert_Update_Delete(sql, sp);
        }
            
        public DataTable CheckLopTruong(string malop, string manam) // kiem tra trong mot lop cua mot nam hoc co bao nhieu mã lớp trưởng, một lớp chỉ được có một lớp trưởng
        {
            string sql = " select hoc.MaCV from HOC hoc , HOCKY hk, NAMHOC nh, LOP l where hoc.MaLop = l.MaLop and hoc.MaHK = hk.MaHK and hk.MaNam=nh.MaNam and l.MaLop =@malop and  nh.MaNam=@manam and hoc.MaCV = 'CV02'";// CV02 la mã của lớp trưởng
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@malop", malop);
            sp[1] = new SqlParameter("@manam", manam);
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql, sp);
            dt.TableName = "dts";
            return dt;
        }
        
        public int Update(HocDTO Hoc)
        {
            string sql = "update HOC set MaHS=@MaHS,MaLop=@MaLop,MaHK=@MaHK,DiemCuoiKy=@DiemCuoiKy,HKCuoiKy=@HKCuoiKy,MaCV=@ChucVu where MaHoc=@MaHoc";
            SqlParameter[] sp = new SqlParameter[7];
            sp[0] = new SqlParameter("@MaHoc", Hoc.MaHoc);
            sp[1] = new SqlParameter("@MaHS", Hoc.MaHS);
            sp[2] = new SqlParameter("@MaLop", Hoc.MaLop);
            sp[3] = new SqlParameter("@MaHK", Hoc.MaHK);
            sp[4] = new SqlParameter("@DiemCuoiKy", Hoc.DiemCuoiKy);
            sp[5] = new SqlParameter("@HKCuoiKy", Hoc.HKCuoiKy);
            sp[6] = new SqlParameter("@ChucVu", Hoc.MaCV);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int UpdateMalop(string malop, string mahoc)
        {
            string sql = "update HOC set MaLop=@malop where MaHoc=@mahoc";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@mahoc", mahoc);
            sp[1] = new SqlParameter("@malop", malop);
            return conectData.Insert_Update_Delete(sql, sp);
        }
    
        public int UpdateChucVu(string cv, string mahoc)
        {
            string sql = "update HOC set MaCV=@cv where MaHoc=@mahoc";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@mahoc", mahoc);
            sp[1] = new SqlParameter("@cv", cv);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int UpdateDiemCuoiKy(float diemck, string mahoc)
        {
            string sql = "update HOC set DiemCuoiKy=@diemck where MaHoc=@mahoc";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@mahoc", mahoc);
            sp[1] = new SqlParameter("@diemck", diemck);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int UpdateHKCuoiKy(string hk, string mahoc)
        {
            string sql = "update HOC set HKCuoiKy=@hk where MaHoc=@mahoc";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@mahoc", mahoc);
            sp[1] = new SqlParameter("@hk", hk);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public string getMaHoc(string mahs, string malop, string mahk) // lay ma hoc theo mahs,malop,mahk
        {
            string sql = "select MaHoc from HOC where MaHS=@mahs and MaLop=@malop and  MaHK=@mahk";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@mahk", mahk);
            sp[1] = new SqlParameter("@malop", malop);
            sp[2] = new SqlParameter("@mahs", mahs);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt.Rows.Count == 0)
            {
                return "NULL";
            }
            else
            {
                return dt.Rows[0][0].ToString();
            }
        }
        public string getMaLop(string mahs, string mahk)
        {
            string sql = "select MaLop from HOC where MaHS=@mahs and MaHK=@mahk";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@mahs", mahs);
            sp[1] = new SqlParameter("@mahk", mahk);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt.Rows.Count == 0)
            {
                return "NULL";
            }
            else
            {
                return dt.Rows[0][0].ToString();
            }
        }
        public float getDiemCuoiKy(string mahs, string malop, string manam, string tenhk)
        {
            string sql = "select hoc.DiemCuoiKy from HOC hoc,HOCKY hk where hoc.MaHK=hk.MaHK and hk.MaNam=@manam and hk.HocKy=@tenhk and hoc.MaHS=@mahs and hoc.MaLop=@malop";
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@tenhk", tenhk);
            sp[1] = new SqlParameter("@malop", malop);
            sp[2] = new SqlParameter("@mahs", mahs);
            sp[3] = new SqlParameter("@manam", manam);
            DataTable dt = conectData.LoadData(sql, sp);
            return float.Parse(dt.Rows[0][0].ToString());
        }
        public string getHKCuoiKy(string mahs, string malop, string manam,string tenhk)
        {
            string sql = "select hoc.HKCuoiKy from HOC hoc,HOCKY hk where hoc.MaHK=hk.MaHK and hk.MaNam=@manam and hk.HocKy=@tenhk and hoc.MaHS=@mahs and hoc.MaLop=@malop";
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@tenhk", tenhk);
            sp[1] = new SqlParameter("@malop", malop);
            sp[2] = new SqlParameter("@mahs", mahs);
            sp[3] = new SqlParameter("@manam", manam);
            DataTable dt = conectData.LoadData(sql, sp);
            return dt.Rows[0][0].ToString();
        }

        public DataTable getBangDiem(int mahoc, string mamon)
        {
            string sql = "select hoc.MaHS as 'Mã HS', hs.HoTen as 'Họ tên', bd.DTBMon_HK as 'Điểm TB', (select ct.Diem from CT_BDM_HK ct where ct.HeSo=1) as 'Điểm 15p',(select ct1.Diem from CT_BDM_HK ct1 where ct1.HeSo=2) as 'Điểm 1 tiết' from HOCSINH hs,HOC hoc,BDM_HK bd, CT_BDM_HK ctbd where hoc.MaHS=hs.MaHS and hoc.MaHoc=bd.MaHoc and ctbd.MaBDM_Hk=bd.MaBDM_HK and hoc.MaHoc=@mahoc and bd.MaMon=@mamon";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@mahoc", mahoc);
            sp[1] = new SqlParameter("@mamon", mamon);
            DataTable dt = conectData.LoadData(sql, sp);
            dt.TableName = "dt";
            return dt;
        }

        public DataTable GetMaHoc(string manam, string makhoi) // lay tat ca cac ma hoc co MaNam=manam,MaKhoi=makhoi, khi them mot bang CT_KL_MH thi pai them vao tat ca cac ma hoc nay bang BDM_HK
        {
            string sql = "select hoc.MaHoc from HOC hoc, LOP lop, HOCKY hk where hoc.MaHK=hk.MaHK and hk.MaNam=@manam and hoc.MaLop=lop.MaLop and lop.MaKhoiLop=@makl ";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@manam", manam);
            sp[1] = new SqlParameter("@makl",makhoi);
            DataTable dt = conectData.LoadData(sql, sp);
            dt.TableName = "dt";
            return dt;

        }
                   
        public int Delete(string mahoc)
        {
            string sql = "delete from HOC where MaHoc=@MaHoc";
            SqlParameter sp = new SqlParameter("@MaHoc", mahoc);
            return conectData.Insert_Update_Delete(sql, sp);
        }

        public DataTable getDCK_HKCK(string manam, string tenhk, string malop) // lấy DiemCK,HKCK cua theo hoc sinh cua tung lop theo ten tung hk (I or II)
        {
            string sql = "select hoc.MaHS as 'Mã HS',hs.HoTen as 'Họ tên',hoc.DiemCuoiKy as 'Điểm CK', hoc.HKCuoiKy as 'HK CK'  from HOC hoc,HOCKY nh,HOCSINH hs  where hs.MaHS=hoc.MaHS and nh.MaHK=hoc.MaHK and hoc.MaLop=@malop and nh.MaNam=@manam and nh.HocKy =@tenhk ";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@tenhk", tenhk);
            sp[1] = new SqlParameter("@malop", malop);
            sp[2] = new SqlParameter("@manam", manam);
            DataTable dt = conectData.LoadData(sql, sp);
            dt.TableName = "dt";
            return dt;
         }
        public DataTable getLisHS_Lop(string mahk, string malop) // lay danh sach hco sinh cua mot lop theo tung hoc ki
        {
            string sql = "select h.MaHS as 'Mã HS', hs.HoTen as 'Họ tên' from HOC h , HOCSINH hs where hs.MaHS=h.MaHS and  h.MaHK=@mahk and h.MaLop=@malop";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@mahk", mahk);
            sp[1] = new SqlParameter("@malop", malop);
            DataTable dt = conectData.LoadData(sql, sp);
            dt.TableName = "dt";
            return dt;
        }
        // cac ham select se duoc viet tiep o day.
    }
}
