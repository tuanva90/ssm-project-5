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
public class HocDAO : System.Web.Services.WebService
    {
        ConectData conectData = new ConectData();
        private HocDTO _hoc;
  
        public HocDTO Hoc
        {
            get { return _hoc; }
            set { _hoc = value; }
        }
        [WebMethod]
        public int Insert()
        {
            string sql = "insert into HOC values (@MaHoc,@MaHS,@MaLop,@MaHK,@DiemCuoiKy,@HKCuoiKy,@ChucVu)";
            SqlParameter[] sp = new SqlParameter[7];
            sp[0] = new SqlParameter("@MaHoc", Hoc.MaHoc);
            sp[1] = new SqlParameter("@MaHS", Hoc.MaHS);
            sp[2] = new SqlParameter("@MaLop",Hoc.MaLop);
            sp[3] = new SqlParameter("@MaHK",Hoc.MaHK);
            sp[4] = new SqlParameter("@DiemCuoiKy",Hoc.DiemCuoiKy);
            sp[5] = new SqlParameter("@HKCuoiKy", Hoc.HKCuoiKy);
            sp[6] = new SqlParameter("@ChucVu",Hoc.ChucVu);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public int Update()
        {
            string sql = "update HOC set MaHS=@MaHS,MaLop=@MaLop,MaHK=@MaHK,DiemCuoiKy=@DiemCuoiKy,HKCuoiKy=@HKCuoiKy where MaHoc=@MaHoc";
            SqlParameter[] sp = new SqlParameter[7];
            sp[0] = new SqlParameter("@MaHoc", Hoc.MaHoc);
            sp[1] = new SqlParameter("@MaHS", Hoc.MaHS);
            sp[2] = new SqlParameter("@MaLop", Hoc.MaLop);
            sp[3] = new SqlParameter("@MaHK", Hoc.MaHK);
            sp[4] = new SqlParameter("@DiemCuoiKy", Hoc.DiemCuoiKy);
            sp[5] = new SqlParameter("@HKCuoiKy", Hoc.HKCuoiKy);
            sp[6] = new SqlParameter("@ChucVu", Hoc.ChucVu);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public int Delete(string mahoc)
        {
            string sql = "delete from HOC where MaHoc=@MaHoc";
            SqlParameter sp = new SqlParameter("@MaHoc", mahoc);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        // cac ham select se duoc viet tiep o day.
    }

