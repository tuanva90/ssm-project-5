using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
   public class CT_BDM_HK_DAO
    {
        ConectData conectData = new ConectData();
       
        public int Insert(CT_BDM_HKDTO Ct_bdm_hk)
        {
            string sql = "insert into CT_BDM_HK values (@MaBDM_HK,@Diem15Phut,@DiemMieng,@Diem1Tiet,@DiemHK)";
            SqlParameter[] sp = new SqlParameter[5];
               sp[0] = new SqlParameter("@MaBDM_HK", Ct_bdm_hk.MaBD_HK);
               sp[1] = new SqlParameter("@Diem15Phut", Ct_bdm_hk.Diem15Phut);
               sp[2] = new SqlParameter("@DiemMieng", Ct_bdm_hk.DiemMieng);
               sp[3] = new SqlParameter("@Diem1Tiet", Ct_bdm_hk.Diem1Tiet);
               sp[4] = new SqlParameter("@DiemHK", Ct_bdm_hk.DiemHK);
            return conectData.Insert_Update_Delete(sql, sp);
        }

        public int Update(CT_BDM_HKDTO Ct_bdm_hk) // update diem 15phut, mieng, 1 tiet dua vao ma BDM_HK, co ham lay MaBDM_HK trong gile BDM_HKdao
        {
            string sql = "update CT_BDM_HK set Diem15Phut=@Diem15Phut,DiemMieng=@DiemMieng,Diem1Tiet=@Diem1Tiet, DiemHK=@DiemHK where  MaBDM_HK=@MaBDM_HK";
            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@MaBDM_HK", Ct_bdm_hk.MaBD_HK);
            sp[1] = new SqlParameter("@Diem15Phut", Ct_bdm_hk.Diem15Phut);
            sp[2] = new SqlParameter("@DiemMieng", Ct_bdm_hk.DiemMieng);
            sp[3] = new SqlParameter("@Diem1Tiet", Ct_bdm_hk.Diem1Tiet);
            sp[4] = new SqlParameter("@DiemHK", Ct_bdm_hk.DiemHK);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int UpdateDiemHK(int mahoc, int ctklmh,float diem)
        {
            string sql = "update CT_BDM_HK set DiemHK=@Diem where MaBDM_HK=@MaBDM_HK";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaBDM_HK", GetMaBDM_HK(mahoc, ctklmh));
            sp[1] = new SqlParameter("@Diem", diem);
            return conectData.Insert_Update_Delete(sql, sp);
        }
       /*
        public int Updateheso(int mahoc, string mamon, int heso)//bỏ.
        {
            string sql = "update CT_BDM_HK set Diem=@Diem,HeSo=@HeSo where MaBDM_HK=@MaBDM_HK";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaBDM_HK", GetMaBDM_HK(mahoc, mamon));
            sp[1] = new SqlParameter("@heso", heso);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        * */
            
        public int Delete(int mahoc,int ctklmh)
        {
            string sql = "delete from CT_BDM_HK where MaBDM_HK=@BDM_HK";
            SqlParameter sp = new SqlParameter("@MaBDM_HK", GetMaBDM_HK(mahoc, ctklmh));
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public bool Check(string manam, string makhoilop, string mamon)// kiem tra xem mot bang CT_Khoilop_MonHoc co duoc su dung chua, nghia la khóa chính của bảng này đã được sử dụng trong bảng BDM_Hk và bang BDM_HK da duoc luu con diem nao chua, neu chua thi tra ve true( co the xoa khi gia tri tra ve bang true) nguoc lai tra ve false
        {
            string sql = "select ctbdmhk.Diem15Phut,ctbdmhk.DiemMieng,ctbdmhk.Diem1Tiet from CT_BDM_HK ctbdmhk,BDM_HK bdmhk,CT_KHOILOP_MONHOC ctklmh , KHOILOP_MONHOC klmh where ctbdmhk.MaBDM_HK=bdmhk.MaBDM_HK and bdmhk.CT_KLMH=ctklmh.CT_KLMH and ctklmh.MaKLMH=klmh.MaKLMH and ctklmh.MaMon=@mamon and klmh.MaKhoiLop=@makhoilop and klmh.MaNam=@manam";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@mamon",mamon);
            sp[1] = new SqlParameter("@manam", manam);
            sp[2] = new SqlParameter("@makhoilop", makhoilop);
            DataTable dt = conectData.LoadData(sql, sp);
            int check = 0;
            if (dt.Rows.Count == 0)
                return false;
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() != "" || dt.Rows[i][1].ToString() != "" || dt.Rows[i][2].ToString() != "")
                    {
                        check++;
                    }
                }
                if (check != 0)
                    return true;
                else
                    return false;
            }
        }
        public int GetMaBDM_HK(int mahoc, int ctklmh)
        {
            string sql = "select MaBDM_HK from BDM_HK where CT_KLMH=@ctklmh and MaHoc=@mahoc";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@mahoc", mahoc);
            sp[1] = new SqlParameter("@ctklmh", ctklmh);
            DataTable st = conectData.LoadData(sql,sp);
            return int.Parse(st.Rows[0][0].ToString());
        }

        public DataTable List(string mahk, string malop, string mamon) // lay danh sach bang diem cua tung lop , tung hoc ki theo tung mon hoc!
        {
            string sql = "select hs.MaHS as 'Mã HS', hs.HoTen as 'Họ tên',ctbd.Diem15Phut as 'Điểm 15p', ctbd.DiemMieng as 'Điểm miệng', ctbd.Diem1Tiet as 'Điểm 1t', ctbd.DiemHK as 'Điểm HK', bd.DTBMon_HK as 'Điểm TB',bd.DTBMon_KT as 'Điểm TBMKT' from HOCSINH hs, CT_BDM_HK ctbd, BDM_HK bd, CT_KHOILOP_MONHOC ctklmh,HOC hoc where hs.MaHS=hoc.MaHS and ctbd.MaBDM_HK=bd.MaBDM_HK and bd.MaHoc=hoc.MaHoc and bd.CT_KLMH=ctklmh.CT_KLMH and ctklmh.MaMon=@mamon and hoc.MaLop=@malop and hoc.MaHK=@mahk";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@mahk", mahk);
            sp[1] = new SqlParameter("@malop", malop);
            sp[2] = new SqlParameter("@mamon", mamon);
            DataTable dt = conectData.LoadData(sql, sp);
            dt.TableName = "dt";
            return dt;
        }
        // cac ham select se duoc viet tiep o day.
    }
}
