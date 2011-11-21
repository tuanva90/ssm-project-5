using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using DTO;
using DAO;
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class HocSinhDAO : System.Web.Services.WebService
{
    ConectData conectData = new ConectData();
    private HocSinhDTO _hs;

    public HocSinhDTO Hs
    {
        get { return _hs; }
        set { _hs = value; }
    }
    [WebMethod]
    public int Insert()
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
    [WebMethod]
    public int Update()
    {
        string sql = "update HOCSINH set HoTen=@hoten,GioiTinh=@gioitinh,SoDienThoai=@sodienthoai,HoTenCha=@hotencha,NgheNghiepCha=@nghenghiepcha,HoTenMe=@hotenme,NgheNghiepMe=@nghenghiepme,NgaySinh=@ngaysinh,DiaChi=@DiaChi where MaHS=@mahs";
        SqlParameter[] sp = new SqlParameter[10];
        sp[0] = new SqlParameter("@mahs", Hs.MaHS);
        sp[1] = new SqlParameter("@hoten", Hs.HoTen);
        sp[2] = new SqlParameter("@gioitinh", Hs.GioiTinh);
        sp[3] = new SqlParameter("@SoDienThoai", Hs.SoDienThoai);
        sp[4] = new SqlParameter("@hotencha", Hs.HoTenCha);
        sp[5] = new SqlParameter("@nghenghiepcha", Hs.NgheNghiepCha);
        sp[6] = new SqlParameter("@hotenme", Hs.HoTenMe);
        sp[7] = new SqlParameter("@nghenghiepme", Hs.NgheNghiepMe);
        sp[8] = new SqlParameter("@ngaysinh", Hs.NgaySinh);
        sp[9] = new SqlParameter("@DiaChi", Hs.DiaChi);
        return conectData.Insert_Update_Delete(sql, sp);
    }
    [WebMethod]
    public int Delete()
    {
        string sql = " delete from HOCSINH where MaHS=@mahs";
        SqlParameter sp = new SqlParameter("@mahs", Hs.MaHS);
        return conectData.Insert_Update_Delete(sql, sp);
    }
    [WebMethod]
    public DataTable SearchByName(string hoten)
    {
        string sql = " select * from HOCSINH where HoTen=@hoten";// where HoTen like @valude
        SqlParameter sp = new SqlParameter("@hoten", hoten);
        return conectData.LoadData(sql, sp);
    }
 
    public HocSinhDAO(HocSinhDTO hs)
    {
        Hs = hs;
    }
}
