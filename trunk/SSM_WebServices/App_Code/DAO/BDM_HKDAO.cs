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

public class BDM_HKDAO : System.Web.Services.WebService
 {

        ConectData conectData = new ConectData();
        private BDM_HKDTO _bdm_hk;
     
        public BDM_HKDTO Bdm_hk
        {
            get { return _bdm_hk; }
            set { _bdm_hk = value; }
        }
        [WebMethod]
        public int Insert()
        {
            string sql = "insert into BDM_HK values (@MaBDM_HK,@MaHoc,@MaMonHoc,@DTBMon_HK)";
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@MaBDM_HK", Bdm_hk.MaBDM_HK);
            sp[1] = new SqlParameter("@MaHoc", Bdm_hk.MaHoc);
            sp[2] = new SqlParameter("@MaMonHoc", Bdm_hk.MaMonHoc);
            sp[3] = new SqlParameter("@DTBMon_HK",Bdm_hk.DTBMon_HK);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public int Update()
        {
            string sql = "update BDM_HK set MaHoc=@MaHoc,MaMonHoc=@MaMonHoc,DTBMon_HK=@DTBMon_HK where MaBDM_HK=@MaBDM_HK";
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@MaBDM_HK", Bdm_hk.MaBDM_HK);
            sp[1] = new SqlParameter("@MaHoc", Bdm_hk.MaHoc);
            sp[2] = new SqlParameter("@MaMonHoc", Bdm_hk.MaMonHoc);
            sp[3] = new SqlParameter("@DTBMon_HK", Bdm_hk.DTBMon_HK);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public int Delete(string mabdm_hk)
        {
            string sql = "delete from BDM_HK where MaBDM_HK=@MaBDM_HK";
            SqlParameter sp = new SqlParameter("@MaBDM_HK", mabdm_hk);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public DataTable List()
        {
            string sql = "select * from BDM_HK";
            return conectData.LoadData(sql);
        }
        // cac ham select se duoc viet tiep o day.
    }

