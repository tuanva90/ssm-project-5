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
public class KhoiLopDAO : System.Web.Services.WebService
    {
        ConectData conectData = new ConectData();
        private KhoiLopDTO _kl;
     
        public KhoiLopDTO Kl
        {
            get { return _kl; }
            set { _kl = value; }
        }
        [WebMethod]
        public int Insert()
        {
            string sql = "insert into KHOILOP values (@MaKhoiLop,@TenKhoiLop,@SoLop)";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@MaKhoiLop", Kl.MaKhoiLop);
            sp[1] = new SqlParameter("@TenKhoiLop",Kl.TenKhoiLop);
            sp[2] = new SqlParameter("@SoLop", Kl.SoLop);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public int Update()
        {
            string sql = "update KHOILOP set TenKhoiLop=@TenKhoiLop,SoLop=@SoLop where MaKhoiLop=@MaKhoiLop";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@MaKhoiLop", Kl.MaKhoiLop);
            sp[1] = new SqlParameter("@TenKhoiLop", Kl.TenKhoiLop);
            sp[2] = new SqlParameter("@SoLop", Kl.SoLop);
            return conectData.Insert_Update_Delete(sql, sp);
         }
        [WebMethod]
        public int Delete(string makhoilop)
        {
            string sql = "delete from KHOILOP where MaKhoiLop=@MaKhoiLop";
            SqlParameter sp = new SqlParameter("@MaKhoiLop", makhoilop);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public DataTable List()
        {
            string sql = "select * from KHOILOP";
            return conectData.LoadData(sql);
        }
        // cac ham select se duoc viet tiep o day.
    }

