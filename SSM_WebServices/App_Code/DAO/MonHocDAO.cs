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
public class MonHocDAO : System.Web.Services.WebService
    {
        ConectData conectData = new ConectData();
        private MonHocDTO _mh;
    
        public MonHocDTO Mh
        {
            get { return _mh; }
            set { _mh = value; }
        }
        [WebMethod]
        public int Insert()
        {
            string sql = "insert into MONHOC values (@MaMon,@TenMon)";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaMon", Mh.MaMon);
            sp[1] = new SqlParameter("@TenMon", Mh.TenMon);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public int Update()
        {
            string sql = "update MONHOC set TenMon=@TenMon where MaMon=@MaMon";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaMon",Mh.MaMon);
            sp[1] = new SqlParameter("@TenMon", Mh.TenMon);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public int Delete(string mamon)
        {
            string sql = "delete from MONHOC where MaMon=@MaMon";
            SqlParameter sp = new SqlParameter("@MaMon", mamon);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public DataTable List()
        {
            string sql = "select * from MonHoc";
            return conectData.LoadData(sql);
        }
        // cac ham select se duoc viet tiep o day.

    }

