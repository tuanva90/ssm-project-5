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
public class ToDAO : System.Web.Services.WebService
    {
        ConectData conectData = new ConectData();
        private ToDTO _to;
       
        public ToDTO To
        {
            get { return _to; }
            set { _to = value; }
        }
        [WebMethod]
        public int Insert()
        {
            string sql = "insert into TO values (@MaTo,@TenTo)";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaTo", To.MaTo);
            sp[1] = new SqlParameter("@TenTo", To.TenTo);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public int Update()
        {
            string sql = "update TO set TenTo=@TenTo where MaTo=@MaTo";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaTo", To.MaTo);
            sp[1] = new SqlParameter("@TenTo", To.TenTo);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public int Delete(string mato)
        {
            string sql = "delete from TO where MaTo=@MaTo";
            SqlParameter sp = new SqlParameter("@MaTo", To.MaTo);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public DataTable List()
        {
            string sql = "select * from TO";
            return conectData.LoadData(sql);
        }
        // cac ham select se duoc viet tiep o day.
    }

