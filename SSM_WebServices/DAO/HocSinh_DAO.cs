using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class HocSinh_DAO
    {
        ConectData conectData = new ConectData();
        
        public int Insert(HocSinhDTO Hs) /// them hoc sinh
        {
            string sql = "insert into HOCSINH values (@MaHS,@HoTen,@GioiTinh,@SoDienThoai,@HoTenCha,@NgheNghiepCha,@HoTenMe,@NgheNghiepMe,@NgaySinh,@DiaChi)";
            SqlParameter[] sp = new SqlParameter[10];
            sp[0] = new SqlParameter("@MaHS", Hs.MaHS);
            sp[1] = new SqlParameter("@HoTen", Hs.HoTen);
            sp[2] = new SqlParameter("@GioiTinh", Hs.GioiTinh);
            sp[3] = new SqlParameter("@SoDienThoai", Hs.SoDienThoai);
            sp[4] = new SqlParameter("@HoTenCha", Hs.HoTenCha);
            sp[5] = new SqlParameter("@NgheNghiepCha", Hs.NgheNghiepCha);
            sp[6] = new SqlParameter("@HoTenMe", Hs.HoTenMe);
            sp[7] = new SqlParameter("@NgheNghiepMe", Hs.NgheNghiepMe);
            sp[8] = new SqlParameter("@NgaySinh", Hs.NgaySinh);
            sp[9] = new SqlParameter("@DiaChi", Hs.DiaChi);
            return conectData.Insert_Update_Delete(sql, sp);
        }
            
        public int Update(HocSinhDTO Hs) // cap nhat thong tin hoc sinh
        {
            string sql = "update HOCSINH set HoTen=@hoten,GioiTinh=@gioitinh,SoDienThoai=@sodienthoai,HoTenCha=@hotencha,NgheNghiepCha=@nghenghiepcha,HoTenMe=@hotenme,NgheNghiepMe=@nghenghiepme,NgaySinh=@ngaysinh,DiaChi=@DiaChi where MaHS=@mahs";
            SqlParameter[] sp = new SqlParameter[10];
            sp[0] = new SqlParameter("@mahs", Hs.MaHS);
            sp[1] = new SqlParameter("@hoten", Hs.HoTen);
            sp[2] = new SqlParameter("@gioitinh", Hs.GioiTinh);
            sp[3] = new SqlParameter("@sodienthoai", Hs.SoDienThoai);
            sp[4] = new SqlParameter("@hotencha", Hs.HoTenCha);
            sp[5] = new SqlParameter("@nghenghiepcha", Hs.NgheNghiepCha);
            sp[6] = new SqlParameter("@hotenme", Hs.HoTenMe);
            sp[7] = new SqlParameter("@nghenghiepme", Hs.NgheNghiepMe);
            sp[8] = new SqlParameter("@ngaysinh", Hs.NgaySinh);
            sp[9] = new SqlParameter("@DiaChi", Hs.DiaChi);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int Delete(string MaHS) // xoa hoc sih
        {
            string sql = " delete from HOCSINH where MaHS=@mahs";
            SqlParameter sp = new SqlParameter("@mahs", MaHS);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public DataTable SearchByName(string hoten) // tìm hoc sinh theo ten
        {
            string sql = " select MaHS as 'Mã HS',HoTen as 'Họ tên',GioiTinh as 'Giới tính',NgaySinh as 'Ngày sinh',DiaChi as 'Địa chỉ' from HOCSINH where HoTen like @hoten";// where HoTen like @valude
            SqlParameter sp = new SqlParameter("@hoten", "%" + hoten + "%");
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql, sp);
            dt.TableName = "dts";
            return dt;
        }
        public string getHoTen(string mahs) // lay ten hoc sinh theo mahs
        {

            string sql = "select HoTen as 'Họ tên' from HOCSINH where MaHS=@mahs";
            SqlParameter sp = new SqlParameter("@mahs", mahs);
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql, sp);
            if (dt.Rows.Count == 0)
                return "";
            else
            {
                return dt.Rows[0][0].ToString();
            }
        }
            
        public DataTable SearchMaHS(string mahs) // tim hoc sinh theo ma hs
        {
            string sql = " select MaHS as 'Mã HS',HoTen as 'Họ tên',GioiTinh as 'Giới tính',NgaySinh as 'Ngày sinh',DiaChi as 'Địa chỉ' from HOCSINH where MaHS=@mahs";// where HoTen like @valude
            SqlParameter sp = new SqlParameter("@mahs", mahs);
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql, sp);
            dt.TableName = "dts";
            return dt;
        }
            
        public DataTable SearchMaHS_Full(string mahs) // lay day du thong tin hoc sinh theo ma hs
        {
            string sql = " select MaHS as 'Mã HS',HoTen as 'Họ tên',GioiTinh as 'Giới tính',SoDienThoai as 'Số điện thoại',HoTenCha as 'Họ tên cha',NgheNghiepCha as 'Nghề nghiệp cha',HoTenMe as 'Họ tên mẹ',NgheNghiepMe as 'Nghề nghiệp mẹ',NgaySinh as 'Ngày sinh',DiaChi as 'Địa chỉ' from HOCSINH  where MaHS=@mahs";// where HoTen like @valude
            SqlParameter sp = new SqlParameter("@mahs", mahs);
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql, sp);
            dt.TableName = "dts";
            return dt;
        }
        
        public DataTable List() // lay danh sach tat ca hoc sinh ( theo thong tin rut gon)
        {
            string sql = " select MaHS as 'Mã HS',HoTen as 'Họ tên',GioiTinh as 'Giới tính',NgaySinh as 'Ngày sinh',DiaChi as 'Địa chỉ' from HOCSINH ";// where HoTen like @valude       
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            dt.TableName = "dts";
            return dt;

        }
            
        public DataTable HSchuaphanlop(string manh) // lấy danh sách học sinh chưa được phân lớp theo năm học
        {
            string sql = " select hs.MaHS as 'Mã HS', hs.HoTen as 'Họ tên' from HOCSINH hs where hs.MaHS not in(select hoc.MaHS from HOC hoc, HOCKY hk,NAMHOC nh where hoc.MaHK = hk.MaHK and hk.MaNam = nh.MaNam and nh.MaNam =@manam) ";// where HoTen like @valude       
            SqlParameter sp = new SqlParameter("@manam", manh);
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql, sp);
            dt.TableName = "dts";
            return dt;

        }
        
        //-----------------------------Create TuanVA----------------------------------\\
        
        //Kiem tra xem hoc sinh co duoc len lop hay ko
        public bool KiemTraLenLop(string MaHS, string MaNam)
        {
            //Lay thong tin TKNAM 
            string strTKNAM = "select * from TKNAM where MaHS = @MaHS and MaNam = @MaNam";
            SqlParameter[] spTKNAM = new SqlParameter[2];
            spTKNAM[0] = new SqlParameter("@MaHS", MaHS);
            spTKNAM[1] = new SqlParameter("@MaNam", MaNam);
            DataTable dtTKNAM = conectData.LoadData(strTKNAM, spTKNAM);
            if (dtTKNAM.Rows.Count == 0) return true;
            return (float.Parse(dtTKNAM.Rows[0]["DiemCuoiNam"].ToString()) >= 5);
        }

        //Get list HS duoc len lop
        public DataTable listHSDuocLenLop(string MaKhoiLop_Cu)
        {
            //Lay thong tin KHOILOP 
            string strKLC = "select * from KHOILOP where MaKhoiLop = @MaKhoiLop";
            SqlParameter spKLC = new SqlParameter("@MaKhoiLop", MaKhoiLop_Cu);
            DataTable dtKLC = conectData.LoadData(strKLC, spKLC);

            string sql = " select distinct hs.MaHS , hs.HoTen  from HOCSINH hs, HOC h, LOP l, TKNAM tkn where l.MaKhoiLop = @MaKhoiLop and l.MaLop = h.MaLop and h.MaHS = hs.MaHS and h.MaHS = tkn.MaHS and tkn.MaNam = @MaNam and tkn.DiemCuoiNam >= 5"; // hs.MaHS not in(select hoc.MaHS from HOC hoc, HOCKY hk,NAMHOC nh where hoc.MaHK = hk.MaHK and hk.MaNam = nh.MaNam and nh.MaNam =@manam) ";// where HoTen like @valude       
            SqlParameter[] splistHS = new SqlParameter[2];
            splistHS[0] = new SqlParameter("@MaKhoiLop", MaKhoiLop_Cu);
            splistHS[1] = new SqlParameter("@MaNam", dtKLC.Rows[0]["MaNam"].ToString());
            DataTable dt  = conectData.LoadData(sql, splistHS);
            dt.TableName = "dtlisthslc";
            return dt;
        }

        //Get list HS luu ban
        public DataTable listHSLuuBan(string MaKhoiLop_Cu)
        {
            //Lay thong tin KHOILOP 
            string strKLC = "select * from KHOILOP where MaKhoiLop = @MaKhoiLop";
            SqlParameter spKLC = new SqlParameter("@MaKhoiLop", MaKhoiLop_Cu);
            DataTable dtKLC = conectData.LoadData(strKLC, spKLC);

            string sql = " select distinct hs.MaHS , hs.HoTen  from HOCSINH hs, HOC h, LOP l, TKNAM tkn where l.MaKhoiLop = @MaKhoiLop and l.MaLop = h.MaLop and h.MaHS = hs.MaHS and h.MaHS = tkn.MaHS and tkn.MaNam = @MaNam and tkn.DiemCuoiNam < 5"; // hs.MaHS not in(select hoc.MaHS from HOC hoc, HOCKY hk,NAMHOC nh where hoc.MaHK = hk.MaHK and hk.MaNam = nh.MaNam and nh.MaNam =@manam) ";// where HoTen like @valude       
            SqlParameter[] splistHS = new SqlParameter[2];
            splistHS[0] = new SqlParameter("@MaKhoiLop", MaKhoiLop_Cu);
            splistHS[1] = new SqlParameter("@MaNam", dtKLC.Rows[0]["MaNam"].ToString());
            DataTable dt = conectData.LoadData(sql, splistHS);
            dt.TableName = "dtlisthslb";
            return dt;
        }

        //Phan Lop Thu Cong cho tung HS
        public int PhanLopThuCong(string MaHS, string MaLop)
        {
            //Chọn HOCKY 
            string strHocKy = "select hk.* from HOCKY hk, KHOILOP kl, LOP l where l.MaKhoiLop = kl.MaKhoiLop and kl.MaNam = hk.MaNam and l.MaLop = @MaLop";
            SqlParameter sphk = new SqlParameter("@MaLop", MaLop);
            DataTable dtHK = conectData.LoadData(strHocKy, sphk);   

            //Lay thong tin Lop Hoc
            string strLopHoc = "select * from LOP where MaLop = @MaLop";
            SqlParameter spLopHoc = new SqlParameter("@MaLop", MaLop);
            DataTable dtLopHoc = conectData.LoadData(strLopHoc, spLopHoc);

            //Lay DS Mon Hoc
            string strkl_mh = "";
            strkl_mh = "select * from KHOILOP_MONHOC where MaKhoiLop = @makhoilop";
            SqlParameter spkl_mh = new SqlParameter("@makhoilop", dtLopHoc.Rows[0]["MaKhoiLop"].ToString());
            DataTable dtkl_mh = conectData.LoadData(strkl_mh, spkl_mh);

            strkl_mh = "select * from CT_KHOILOP_MONHOC where MaKLMH = @MaKLMH";
            spkl_mh = new SqlParameter("@MaKLMH", dtkl_mh.Rows[0]["MaKLMH"].ToString());
            DataTable dtDSMH = conectData.LoadData(strkl_mh, spkl_mh);
            int kq = 0;
            string strsql = "insert into HOC values (@MaHS, @MaLop, @MaHK, '', '', 'CV01')";
            
            for (int i = 0; i < dtHK.Rows.Count; i++)
            {
                //insert vao table HOC
                SqlParameter[] spHoc = new SqlParameter[3];
                spHoc[0] = new SqlParameter("@MaHS", MaHS);
                spHoc[1] = new SqlParameter("@MaLop", MaLop);
                spHoc[2] = new SqlParameter("@MaHK", dtHK.Rows[i]["MaHK"].ToString());
                kq = conectData.Insert_Update_Delete(strsql, spHoc);

                //Lay thong tin du lieu moi them vao table HOC
                string strHocNew = "select * from HOC where MaHS = @MaHS and MaLop = @MaLop and MaHK = @MaHK";
                SqlParameter[] spHocNew = new SqlParameter[3];
                spHocNew[0] = new SqlParameter("@MaHS", MaHS);
                spHocNew[1] = new SqlParameter("@MaLop", MaLop);
                spHocNew[2] = new SqlParameter("@MaHK", dtHK.Rows[i]["MaHK"].ToString());
                DataTable dtHocNew = conectData.LoadData(strHocNew, spHocNew);

                //insert vao table BDM_HK & CT_BDM_HK
                for (int j = 0; j < dtDSMH.Rows.Count; j++)
                {
                    //insert vao table BDM_HK
                    string strBDM_HK = "insert into BDM_HK values (@MaHoc, @CT_KLMH, '', '')";
                    SqlParameter[] spBDM_HK = new SqlParameter[2];
                    spBDM_HK[0] = new SqlParameter("@MaHoc", dtHocNew.Rows[0]["MaHoc"].ToString());
                    spBDM_HK[1] = new SqlParameter("@CT_KLMH", dtDSMH.Rows[j]["CT_KLMH"].ToString());
                    kq = conectData.Insert_Update_Delete(strBDM_HK, spBDM_HK);

                    //Lay thong du lieu moi them vao table BDM_HK
                    string strBDM_HKNew = "select * from BDM_HK where MaHoc = @MaHoc and CT_KLMH = @CT_KLMH";
                    SqlParameter[] spBDM_HKNew = new SqlParameter[2];
                    spBDM_HKNew[0] = new SqlParameter("@MaHoc", dtHocNew.Rows[0]["MaHoc"].ToString());
                    spBDM_HKNew[1] = new SqlParameter("@CT_KLMH", dtDSMH.Rows[j]["CT_KLMH"].ToString());
                    DataTable dtBDM_HKNew = conectData.LoadData(strBDM_HKNew, spBDM_HKNew);

                    //insert vao table CT_BDM_HK
                    strBDM_HK = "insert into CT_BDM_HK values (@MaBDM_HK, '', '', '', '')";
                    SqlParameter[] spCT_BDM_HK = new SqlParameter[1];
                    spCT_BDM_HK[0] = new SqlParameter("@MaBDM_HK", dtBDM_HKNew.Rows[0]["MaBDM_HK"].ToString());
                    kq = conectData.Insert_Update_Delete(strBDM_HK, spCT_BDM_HK);
                }
            }
            for (int i = 0; i < dtDSMH.Rows.Count; i++)
            {
                //insert vao table BDM_NAM
                string strBDM_NAM = "select MAX(MaBDM_NAM) from BDM_NAM";
                strBDM_NAM = "insert into BDM_NAM values (@MaHS, @CT_KLMH, '', @MaNam)";
                SqlParameter[] spBDM_NAM = new SqlParameter[3];
                spBDM_NAM[0] = new SqlParameter("@MaHS", MaHS);
                spBDM_NAM[1] = new SqlParameter("@CT_KLMH", dtDSMH.Rows[i]["CT_KLMH"].ToString());
                spBDM_NAM[2] = new SqlParameter("@MaNam", dtHK.Rows[0]["MaNam"].ToString());
                kq = conectData.Insert_Update_Delete(strBDM_NAM, spBDM_NAM);
            }

            //insert vao table TKNAM
            string strTKNAM = "insert into TKNAM values (@MaHS, '', '', @MaNam)";
            SqlParameter[] spTKNAM = new SqlParameter[2];
            spTKNAM[0] = new SqlParameter("@MaHS", MaHS);
            spTKNAM[1] = new SqlParameter("@MaNam", dtHK.Rows[0]["MaNam"].ToString());
            kq = conectData.Insert_Update_Delete(strTKNAM, spTKNAM);
            return 1;
        }

        //Phân lớp tự động theo từng lớp
        public int PhanLopTuDong(string MaLop_Cu, string MaLop_Moi)
        {
            //Kiem tra Lop Hoc Moi co trong hay ko
            string strLopHocMoi = "select * from HOC where MaLop = @MaLop";
            SqlParameter spLopHocMoi = new SqlParameter("@MaLop", MaLop_Moi);
            DataTable dtLopHocMoi = conectData.LoadData(strLopHocMoi, spLopHocMoi);
            if (dtLopHocMoi.Rows.Count > 0) return 0;

            ////Lay MaNam cua LopHoc_Cu
            //string strMaNamCu = "select kl.MaNam from LOP l, KHOILOP kl where l.MaKhoiLop = kl.MaKhoiLop and l.MaLop = @MaLop";
            //SqlParameter spMaNamCu = new SqlParameter("@MaLop", MaLop_Cu);
            //DataTable dtMaNamCu = conectData.LoadData(strMaNamCu, spMaNamCu);

            //Lay thong tin HOCKY cua nam cu
            string strHKCu = "select hk.* from HOCKY hk, KHOILOP kl, LOP l where l.MaKhoiLop = kl.MaKhoiLop and kl.MaNam = hk.MaNam and l.MaLop = @MaLop";
            SqlParameter spHKCu = new SqlParameter("@MaLop", MaLop_Cu);
            DataTable dtHKCu = conectData.LoadData(strHKCu, spHKCu);

            //Lay list HS trong Lop cu (HK2 cua lop cu)
            string strlistHSCu = "select * from HOC where MaLop = @MaLop and MaHK = @MaHK";
            SqlParameter[] splistHSCu = new SqlParameter[2];
            splistHSCu[0] = new SqlParameter("@MaLop", MaLop_Cu);
            splistHSCu[1] = new SqlParameter("@MaHK", dtHKCu.Rows[1]["MaHK"].ToString());
            DataTable dtlistHSCu = conectData.LoadData(strlistHSCu, splistHSCu);

            //Duyet tat ca cac hs trong lop cu 
            for (int ii = 0; ii < dtlistHSCu.Rows.Count; ii++)
            {

                //Chọn HOCKY trong nam hoc moi
                string strHocKy = "select hk.* from HOCKY hk, KHOILOP kl, LOP l where l.MaKhoiLop = kl.MaKhoiLop and kl.MaNam = hk.MaNam and l.MaLop = @MaLop";
                SqlParameter sphk = new SqlParameter("@MaLop", MaLop_Moi);
                DataTable dtHK = conectData.LoadData(strHocKy, sphk);

                //Lay thong tin Lop Hoc
                string strLopHoc = "select * from LOP where MaLop = @MaLop";
                SqlParameter spLopHoc = new SqlParameter("@MaLop", MaLop_Moi);
                DataTable dtLopHoc = conectData.LoadData(strLopHoc, spLopHoc);

                //Lay DS Mon Hoc
                string strkl_mh = "";
                strkl_mh = "select * from KHOILOP_MONHOC where MaKhoiLop = @makhoilop";
                SqlParameter spkl_mh = new SqlParameter("@makhoilop", dtLopHoc.Rows[0]["MaKhoiLop"].ToString());
                DataTable dtkl_mh = conectData.LoadData(strkl_mh, spkl_mh);

                strkl_mh = "select * from CT_KHOILOP_MONHOC where MaKLMH = @MaKLMH";
                spkl_mh = new SqlParameter("@MaKLMH", dtkl_mh.Rows[0]["MaKLMH"].ToString());
                DataTable dtDSMH = conectData.LoadData(strkl_mh, spkl_mh);
                int kq = 0;
                string strsql = "insert into HOC values (@MaHS, @MaLop, @MaHK, '', '', 'CV01')";

                for (int i = 0; i < dtHK.Rows.Count; i++)
                {
                    //insert vao table HOC
                    SqlParameter[] spHoc = new SqlParameter[3];
                    spHoc[0] = new SqlParameter("@MaHS", dtlistHSCu.Rows[ii]["MaHS"].ToString());
                    spHoc[1] = new SqlParameter("@MaLop", MaLop_Moi);
                    spHoc[2] = new SqlParameter("@MaHK", dtHK.Rows[i]["MaHK"].ToString());
                    kq = conectData.Insert_Update_Delete(strsql, spHoc);

                    //Lay thong tin du lieu moi them vao table HOC
                    string strHocNew = "select * from HOC where MaHS = @MaHS and MaLop = @MaLop and MaHK = @MaHK";
                    SqlParameter[] spHocNew = new SqlParameter[3];
                    spHocNew[0] = new SqlParameter("@MaHS", dtlistHSCu.Rows[ii]["MaHS"].ToString());
                    spHocNew[1] = new SqlParameter("@MaLop", MaLop_Moi);
                    spHocNew[2] = new SqlParameter("@MaHK", dtHK.Rows[i]["MaHK"].ToString());
                    DataTable dtHocNew = conectData.LoadData(strHocNew, spHocNew);

                    //insert vao table BDM_HK & CT_BDM_HK
                    for (int j = 0; j < dtDSMH.Rows.Count; j++)
                    {
                        //insert vao table BDM_HK
                        string strBDM_HK = "insert into BDM_HK values (@MaHoc, @CT_KLMH, '', '')";
                        SqlParameter[] spBDM_HK = new SqlParameter[2];
                        spBDM_HK[0] = new SqlParameter("@MaHoc", dtHocNew.Rows[0]["MaHoc"].ToString());
                        spBDM_HK[1] = new SqlParameter("@CT_KLMH", dtDSMH.Rows[j]["CT_KLMH"].ToString());
                        kq = conectData.Insert_Update_Delete(strBDM_HK, spBDM_HK);

                        //Lay thong du lieu moi them vao table BDM_HK
                        string strBDM_HKNew = "select * from BDM_HK where MaHoc = @MaHoc and CT_KLMH = @CT_KLMH";
                        SqlParameter[] spBDM_HKNew = new SqlParameter[2];
                        spBDM_HKNew[0] = new SqlParameter("@MaHoc", dtHocNew.Rows[0]["MaHoc"].ToString());
                        spBDM_HKNew[1] = new SqlParameter("@CT_KLMH", dtDSMH.Rows[j]["CT_KLMH"].ToString());
                        DataTable dtBDM_HKNew = conectData.LoadData(strBDM_HKNew, spBDM_HKNew);

                        //insert vao table CT_BDM_HK
                        strBDM_HK = "insert into CT_BDM_HK values (@MaBDM_HK, '', '', '', '')";
                        SqlParameter[] spCT_BDM_HK = new SqlParameter[1];
                        spCT_BDM_HK[0] = new SqlParameter("@MaBDM_HK", dtBDM_HKNew.Rows[0]["MaBDM_HK"].ToString());
                        kq = conectData.Insert_Update_Delete(strBDM_HK, spCT_BDM_HK);
                    }
                }
                for (int i = 0; i < dtDSMH.Rows.Count; i++)
                {
                    //insert vao table BDM_NAM
                    string strBDM_NAM = "select MAX(MaBDM_NAM) from BDM_NAM";
                    strBDM_NAM = "insert into BDM_NAM values (@MaHS, @CT_KLMH, '', @MaNam)";
                    SqlParameter[] spBDM_NAM = new SqlParameter[3];
                    spBDM_NAM[0] = new SqlParameter("@MaHS", dtlistHSCu.Rows[ii]["MaHS"].ToString());
                    spBDM_NAM[1] = new SqlParameter("@CT_KLMH", dtDSMH.Rows[i]["CT_KLMH"].ToString());
                    spBDM_NAM[2] = new SqlParameter("@MaNam", dtHK.Rows[0]["MaNam"].ToString());
                    kq = conectData.Insert_Update_Delete(strBDM_NAM, spBDM_NAM);
                }

                //insert vao table TKNAM
                string strTKNAM = "insert into TKNAM values (@MaHS, '', '', @MaNam)";
                SqlParameter[] spTKNAM = new SqlParameter[2];
                spTKNAM[0] = new SqlParameter("@MaHS", dtlistHSCu.Rows[ii]["MaHS"].ToString());
                spTKNAM[1] = new SqlParameter("@MaNam", dtHK.Rows[0]["MaNam"].ToString());
                kq = conectData.Insert_Update_Delete(strTKNAM, spTKNAM);
            }
            return 1;
        }

         //Chuyển lớp cho 1 HS
        public int ChuyenLop(string MaHS, string MaLop_cu, string MaLop_moi)
        {            
            //Lay tat ca HK trong nam
            string strlistHocKy = "select hk.* from HOCKY hk, KHOILOP kl, LOP l where l.MaKhoiLop = kl.MaKhoiLop and kl.MaNam = hk.MaNam and l.MaLop = @MaLop";
            SqlParameter splistHocKy = new SqlParameter("@MaLop", MaLop_cu);
            DataTable dtlistHocKy = conectData.LoadData(strlistHocKy, splistHocKy);

            int kq = 0;
            //Chuyen lop
            for (int i = 0; i < dtlistHocKy.Rows.Count; i++)
            {
                //Lay thong tin table HOC 
                string strHoc = "select * from HOC where MaHS = @MaHS and MaHK = @MaHK";
                SqlParameter[] sphoc = new SqlParameter[2];
                sphoc[0] = new SqlParameter("@MaHS", MaHS);
                sphoc[1] = new SqlParameter("@MaHK", dtlistHocKy.Rows[i]["MaHK"].ToString());
                DataTable dtHOC = conectData.LoadData(strHoc, sphoc);

                string sqlupdtaHoc = "update HOC set MaLop=@MaLop where MaHoc = @MaHoc";
                SqlParameter[] spupdtaHoc = new SqlParameter[2];
                spupdtaHoc[0] = new SqlParameter("@MaLop", MaLop_moi);
                spupdtaHoc[1] = new SqlParameter("@MaHoc", dtHOC.Rows[0]["MaHoc"].ToString());
                kq = conectData.Insert_Update_Delete(sqlupdtaHoc, spupdtaHoc);
            }
            return 1;
        }
        
        //----------------------End by TuanVA--------------------------\\

        public string getMahs(string ma) // lay ma hoc sinh
        {
            string kq;
            string sql = " SELECT MAX(cast(substring(MaHS,3,4) as int)) FROM HOCSINH where (substring(MaHS,1,2))= @ma ";
            SqlParameter sp = new SqlParameter("@ma", ma);
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql, sp);
            if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == "NULL")
            {
                kq = "0001";
            }
            else
            {
                int s = int.Parse(dt.Rows[0][0].ToString()) + 1;
                if (s < 10)
                    kq = "000" + s.ToString();
                else
                {
                    if (s < 100)
                        kq = "00" + s.ToString();
                    else
                    {
                        if (s < 1000)
                            kq = "0" + s.ToString();
                        else
                            kq = s.ToString();
                    }

                }
            }
            return kq;
        }
    }
}
