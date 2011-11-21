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
public class NamHocDAO : System.Web.Services.WebService
	{
        ConectData conectData = new ConectData();
        private NamHocDTO _dt;
      
        public NamHocDTO Dt
        {
            get { return _dt; }
            set { _dt = value; }
        }
    [WebMethod]
        public int Insert()
        {
            string sql = "insert into NAMHOC values (@MaNam,@NamHoc)";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaNam", Dt.MaNam);
            sp[1] = new SqlParameter("@TenMon", Dt.Ten_NamHoc);
            return conectData.Insert_Update_Delete(sql, sp);
        }
    [WebMethod]
        public int Update()
        {
            string sql = "update NAMHOC set NamHoc=@NamHoc where MaNam=@MaNam";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaNam", Dt.MaNam);
            sp[1] = new SqlParameter("@NamHoc", Dt.Ten_NamHoc);
            return conectData.Insert_Update_Delete(sql, sp);
        }
    [WebMethod]
        public int Delete(string manam)
        {
            string sql = "delete from NAMHOC where MaNam=@MaNam";
            SqlParameter sp = new SqlParameter("@MaNam", manam);
            return conectData.Insert_Update_Delete(sql, sp);
        }
    [WebMethod]
        public DataTable List()
        {
            string sql = "select * from NAHMHOC";
            return conectData.LoadData(sql);
        }
        // cac ham select se duoc viet tiep o day.

	}

