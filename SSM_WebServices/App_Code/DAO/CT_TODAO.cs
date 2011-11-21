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
public class CT_TODAO : System.Web.Services.WebService
    {
        ConectData conectData = new ConectData();
        private CT_ToDTO _ct_to;
      
        public CT_ToDTO Ct_to
        {
            get { return _ct_to; }
            set { _ct_to = value; }
        }
        [WebMethod]
        public int Insert()
        {
            string sql = "insert into CT_TO values (@MaTo,@MaMon)";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaTo", Ct_to.MaTo);
            sp[1] = new SqlParameter("@MaMon", Ct_to.MaMon);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public int Delete()
        {
            string sql = "delete from CT_TO where MaTo=@MaTo and MaMon=@MaMon)";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaTo", Ct_to.MaTo);
            sp[1] = new SqlParameter("@MaMon", Ct_to.MaMon);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        // cac ham select se duoc viet tiep o day.
    }

