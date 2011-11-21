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
public class GiaoVienDAO : System.Web.Services.WebService
    {
         ConectData conectData = new ConectData();
        private GiaoVienDTO _gv ;
    
        public GiaoVienDTO Gv
            {
                 get { return _gv; }
                 set { _gv = value; }
            }
       [WebMethod]
        public int InsertGiaoVien()
        {
            string sql = "insert into GIAOVIEN values (@MaGV,@HoTen,@GioiTinh,@SoDienThoai,@ChuyenNganh,@TrinhDoChuyenMon,@SoTruong,@MaTo)";
            SqlParameter[] sp = new SqlParameter[8];
            sp[0] = new SqlParameter("@MaGV", Gv.MaGV);
            sp[1] = new SqlParameter("@HoTen", Gv.HoTen);
            sp[2] = new SqlParameter("@GioiTinh", Gv.GioiTinh);
            sp[3] = new SqlParameter("@SoDienThoai", Gv.SoDienThoai);
            sp[4] = new SqlParameter("@ChuyenNganh",Gv.ChuyenNghanh);
            sp[5] = new SqlParameter("@TrinhDoChuyenMon",Gv.TrinhDoChuyenMon);
            sp[6] = new SqlParameter("@SoTruong",Gv.SoTruong);
            sp[7] = new SqlParameter("@MaTo",Gv.MaTo);
            return conectData.Insert_Update_Delete(sql, sp);
        }
       [WebMethod]
        public int UpdateGiaoVien()
        {
            string sql = "update GIAOVIEN set HoTen=@hoten,GioiTinh=@gioitinh,SoDienThoai=@sodienthoai,ChuyenNganh=@chuyennganh,TrinhDoChuyenMon=@trinhdochuyenmon,SoTruong=@sotruong,MaTo=@mato where MaGV=@magv)";
            SqlParameter[] sp = new SqlParameter[8];
            sp[0] = new SqlParameter("@magv", Gv.MaGV);
            sp[1] = new SqlParameter("@hoten", Gv.HoTen);
            sp[2] = new SqlParameter("@gioitinh", Gv.GioiTinh);
            sp[3] = new SqlParameter("@sodienthoai", Gv.SoDienThoai);
            sp[4] = new SqlParameter("@chuyennganh",Gv.ChuyenNghanh);
            sp[5] = new SqlParameter("@trinhdochuyenmon",Gv.TrinhDoChuyenMon);
            sp[6] = new SqlParameter("@sotruong",Gv.SoTruong);
            sp[7] = new SqlParameter("@mato",Gv.MaTo);
            return conectData.Insert_Update_Delete(sql, sp);
        }
       [WebMethod]
        public int DeleteGiaoVien(string magv)
        {
            string sql = "delete from GIAOVIEN where MaGV=@magv";
            SqlParameter sp = new SqlParameter("@magv",magv);
            return conectData.Insert_Update_Delete(sql, sp);

        }
       [WebMethod]
        public DataTable ListGV()
        {
            string sql = " select * from GIAOVIEN";
            return conectData.LoadData(sql);
        }
       [WebMethod]
        public DataTable SearchbyName(string hoten)
        {
            string sql = " select * from GIAOVIEN where HoTen like @value";
            SqlParameter sp = new SqlParameter("@value", "%" + hoten + "%");
            return conectData.LoadData(sql, sp);
        }
        
    }

