using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class GiaoVien_DAO
    {
        ConectData conectData = new ConectData();
        
        public int InsertGiaoVien(GiaoVienDTO Gv)
        {
            string sql = "insert into GIAOVIEN values (@MaGV,@HoTen,@GioiTinh,@SoDienThoai,@ChuyenNganh,@TrinhDoChuyenMon,@SoTruong,@MaTo,@NgaySinh,@DiaChi)";
            SqlParameter[] sp = new SqlParameter[10];
            sp[0] = new SqlParameter("@MaGV", Gv.MaGV);
            sp[1] = new SqlParameter("@HoTen", Gv.HoTen);
            sp[2] = new SqlParameter("@GioiTinh", Gv.GioiTinh);
            sp[3] = new SqlParameter("@SoDienThoai", Gv.SoDienThoai);
            sp[4] = new SqlParameter("@ChuyenNganh", Gv.ChuyenNghanh);
            sp[5] = new SqlParameter("@TrinhDoChuyenMon", Gv.TrinhDoChuyenMon);
            sp[6] = new SqlParameter("@SoTruong", Gv.SoTruong);
            sp[7] = new SqlParameter("@MaTo", Gv.MaTo);
            sp[8] = new SqlParameter("@NgaySinh", Gv.NgaySinh);
            sp[9] = new SqlParameter("@DiaChi", Gv.DiaChi);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int UpdateGiaoVien(GiaoVienDTO Gv)
        {
            string sql = "update GIAOVIEN set HoTen=@hoten,GioiTinh=@gioitinh,SoDienThoai=@sodienthoai,ChuyenNganh=@chuyennganh,TrinhDoChuyenMon=@trinhdochuyenmon,SoTruong=@sotruong,MaTo=@mato,NgaySinh=@ngaysinh,DiaChi=@diachi where MaGV=@magv";
            SqlParameter[] sp = new SqlParameter[10];
            sp[0] = new SqlParameter("@magv", Gv.MaGV);
            sp[1] = new SqlParameter("@hoten", Gv.HoTen);
            sp[2] = new SqlParameter("@gioitinh", Gv.GioiTinh);
            sp[3] = new SqlParameter("@sodienthoai", Gv.SoDienThoai);
            sp[4] = new SqlParameter("@chuyennganh", Gv.ChuyenNghanh);
            sp[5] = new SqlParameter("@trinhdochuyenmon", Gv.TrinhDoChuyenMon);
            sp[6] = new SqlParameter("@sotruong", Gv.SoTruong);
            sp[7] = new SqlParameter("@mato", Gv.MaTo);
            sp[8] = new SqlParameter("@ngaysinh", Gv.NgaySinh);
            sp[9] = new SqlParameter("@diachi", Gv.DiaChi);
            return conectData.Insert_Update_Delete(sql, sp);
        }
    
        public int DeleteGiaoVien(string magv)
        {
            string sql = "delete from GIAOVIEN where MaGV=@magv";
            SqlParameter sp = new SqlParameter("@magv", magv);
            return conectData.Insert_Update_Delete(sql, sp);

        }
        
        public DataTable ListGV()
        {
            string sql = " select gv.MaGV as 'Mã GV', gv.HoTen as 'Họ tên',gv.GioiTinh as 'Giới tính',gv.SoDienThoai as 'Số điện thoại',gv.ChuyenNganh as 'Chuyên ngành',gv.SoTruong as 'Sở trường',(select t.TenTo from TOCM t where t.MaTo=GV.MaTo) as 'Tổ' from GIAOVIEN gv";
            DataTable dt = conectData.LoadData(sql);
            dt.TableName = "dt";
            return dt;
        }
        
        public DataTable SearchbyName(string hoten)
        {
            string sql = " select gv.MaGV as 'Mã GV', gv.HoTen as 'Họ tên',gv.GioiTinh as 'Giới tính',gv.SoDienThoai as 'Số điện thoại',gv.ChuyenNganh as 'Chuyên ngành',gv.SoTruong as 'Sở trường',(select t.TenTo from TOCM t where t.MaTo=GV.MaTo) as 'Tổ' from GIAOVIEN gv where gv.HoTen like @value";
            SqlParameter sp = new SqlParameter("@value", "%" + hoten + "%");
            DataTable dt = conectData.LoadData(sql, sp);
            dt.TableName = "dt";
            return dt;
        }
        
        public DataTable SearchbyMaGV(string magv)
        {
            string sql = " select gv.MaGV as 'Mã GV', gv.HoTen as 'Họ tên',gv.GioiTinh as 'Giới tính',gv.SoDienThoai as 'Số điện thoại',gv.ChuyenNganh as 'Chuyên ngành',gv.SoTruong as 'Sở trường',(select t.TenTo from TOCM t where t.MaTo=gv.MaTo) as 'Tổ' from GIAOVIEN gv where gv.MaGV =@magv";
            SqlParameter sp = new SqlParameter("@magv", magv);
            DataTable dt = conectData.LoadData(sql, sp);
            dt.TableName = "dt";
            return dt;
        }
        
        public DataTable SearchbyMaGV_Full(string magv) // lay day du thong tin cua mot giao vien theo ma gv
        {
            string sql = " select gv.MaGV as 'Mã GV', gv.HoTen as 'Họ tên',gv.GioiTinh as 'Giới tính',gv.SoDienThoai as 'Số điện thoại',gv.ChuyenNganh as 'Chuyên ngành',gv.TrinhDoChuyenMon as 'Trình độ chuyên môn',gv.SoTruong as 'Sở trường',(select t.TenTo from TOCM t where t.MaTo=gv.MaTo) as 'Tổ',NgaySinh as 'Ngày sinh',DiaChi as 'Địa chỉ' from GIAOVIEN gv where gv.MaGV =@magv";
            SqlParameter sp = new SqlParameter("magv", magv);
            DataTable dt = conectData.LoadData(sql, sp);
            dt.TableName = "dt";
            return dt;
        }
        string magv;
            
        public string getMaGV() // lay ma giao vien
        {
            string sql = " SELECT MAX(cast(substring(MaGV,3,3) as int)) FROM GIAOVIEN";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == "NULL")
            {
                magv = "001";
            }
            else
            {
                int s = int.Parse(dt.Rows[0][0].ToString()) + 1;
                if (s < 10)
                    magv = "00" + s.ToString();
                else
                {
                    if (s < 100)
                        magv = "0" + s.ToString();
                    else
                    {
                        if (s < 1000)
                            magv = s.ToString();

                    }

                }
            }
            return magv;
        }
    }
}
