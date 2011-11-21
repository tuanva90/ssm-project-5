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
public class GhiChuDAO : System.Web.Services.WebService
    {
        ConectData conectData = new ConectData();
        private GhiChuDTO _gc;

        public GhiChuDTO Gc
        {
            get { return _gc; }
            set { _gc = value; }
        }
        [WebMethod]
        public int Insert()
        {
            string sql = "insert into GHICHU values (@MaGC,@MaHoc,@LyDo,@ChiTiet)";
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@MaGC", Gc.MaGC);
            sp[1] = new SqlParameter("@MaHoc", Gc.MaHoc);
            sp[2] = new SqlParameter("@LyDo", Gc.LyDo);
            sp[3] = new SqlParameter("@ChiTiet", Gc.ChiTiet);
             return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public int Update()
        {
            string sql = "update GHICHU set MaHoc=@MaHoc,LyDo=@LyDo,ChiTiet=@ChiTiet where MaGC=@MaGC";
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@MaGC", Gc.MaGC);
            sp[1] = new SqlParameter("@MaHoc", Gc.MaHoc);
            sp[2] = new SqlParameter("@LyDo", Gc.LyDo);
            sp[3] = new SqlParameter("@ChiTiet", Gc.ChiTiet);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public int Delete(string magc)
        {
            string sql = "delete from GHICHU where MaGC=@MaGC";
            SqlParameter sp = new SqlParameter("@MaGC",magc);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public DataTable List()
        {
            string sql = "select * from GHICHU";
            return conectData.LoadData(sql);
        }
        // cac ham select se duoc viet tiep o day.
    }

