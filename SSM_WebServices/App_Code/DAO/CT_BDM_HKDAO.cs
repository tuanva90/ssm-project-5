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
public class CT_BDM_HKDAO : System.Web.Services.WebService
    {
        ConectData conectData = new ConectData();
        private CT_BDM_HKDTO _ct_bdm_hk;
      
        public CT_BDM_HKDTO Ct_bdm_hk
        {
            get { return _ct_bdm_hk; }
            set { _ct_bdm_hk = value; }
        }
        [WebMethod]
        public int Insert()
        {
            string sql = "insert into CT_BDM_HK values (@MaCT_BDM_HK,@MaBDM_HK,@Diem,@HeSo)";
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@MaCT_BDM_HK", Ct_bdm_hk.MaCT_BDM_HK);
            sp[1] = new SqlParameter("@MaBDM_HK", Ct_bdm_hk.MaBD_HK);
            sp[2] = new SqlParameter("@Diem", Ct_bdm_hk.Diem);
            sp[3] = new SqlParameter("@HeSo",Ct_bdm_hk.HeSo);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public int Update()
        {
            string sql = "update CT_BDM_HK set MaBDM_HK=@MaBDM_HK,Diem=@Diem,HeSo=@HeSo where MaCT_BDM_HK=@MaCT_BDM_HK";
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@MaCT_BDM_HK", Ct_bdm_hk.MaCT_BDM_HK);
            sp[1] = new SqlParameter("@MaBDM_HK", Ct_bdm_hk.MaBD_HK);
            sp[2] = new SqlParameter("@Diem", Ct_bdm_hk.Diem);
            sp[3] = new SqlParameter("@HeSo", Ct_bdm_hk.HeSo);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public int Delete(string mact_bdm_hk)
        {
            string sql = "delete from CT_BDM_HK where MaCT_BDM_HK=@MaCT_BDM_HK";
            SqlParameter sp = new SqlParameter("@MaCT_BDM_HK", mact_bdm_hk);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public DataTable List()
        {
            string sql = "select * from CT_BDM_HK";
            return conectData.LoadData(sql);
        }
        // cac ham select se duoc viet tiep o day.
    }

