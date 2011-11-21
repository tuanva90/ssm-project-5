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
public class BDM_NamDAO : System.Web.Services.WebService
    {
        ConectData conectData = new ConectData();

        private BDM_NamDTO _bdm_nam;
                public BDM_NamDTO Bdm_nam
        {
            get { return _bdm_nam; }
            set { _bdm_nam = value; }
        }
        [WebMethod]
        public int Insert()
        {
            string sql = "insert into BDM_NAM values (@MaBDM_Nam,@MaHS,@MaLop,@MaMon,@DTBMon_Nam)";
            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@MaBDM_Nam", Bdm_nam.MaBDM_Nam);
            sp[1] = new SqlParameter("@MaHS",Bdm_nam.MaHS);
            sp[2] = new SqlParameter("@MaLop", Bdm_nam.MaLop);
            sp[3] = new SqlParameter("@MaMon", Bdm_nam.MaMon);
            sp[4] = new SqlParameter("@DTBMon_Nam",Bdm_nam.DTBMon_Nam);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public int Update()
        {
            string sql = "update BDM_NAM set MaHS=@MaHS,MaLop=@MaLop,MaMon=@MaMon,DTBMon_Nam=@DTBMon_Nam where MaBDM_Nam=@MaBDM_Nam";
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@MaBDM_Nam", Bdm_nam.MaBDM_Nam);
            sp[1] = new SqlParameter("@MaHS", Bdm_nam.MaHS);
            sp[2] = new SqlParameter("@MaLop", Bdm_nam.MaLop);
            sp[3] = new SqlParameter("@MaMon", Bdm_nam.MaMon);
            sp[4] = new SqlParameter("@DTBMon_Nam", Bdm_nam.DTBMon_Nam);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public int Delete(string mabdm_nam)
        {
            string sql = "delete from BDM_NAM where MaBDM_Nam=@MaBDM_Nam";
            SqlParameter sp = new SqlParameter("@MaBDM_Nam", mabdm_nam);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public DataTable List()
        {
            string sql = "select * from BDM_NAM";
            return conectData.LoadData(sql);
        }
        // cac ham select se duoc viet tiep o day.
    }
