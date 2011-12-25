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
