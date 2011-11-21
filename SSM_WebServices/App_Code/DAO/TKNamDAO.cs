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
public class TKNamDAO : System.Web.Services.WebService
    {
        ConectData conectData = new ConectData();
        private TKNAMDTO _tkn;
   
        public TKNAMDTO Tkn
        {
            get { return _tkn; }
            set { _tkn = value; }
        }

        public int Insert()
        {
            string sql = "insert into TKNAM values (@MaBTKN,@MaHS,@DiemCuoiNam,@HKCuoiNam,@MaNam)";
            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@MaBTKN", Tkn.MaTKN);
            sp[1] = new SqlParameter("@MaHS",Tkn.MaHS);
            sp[2] = new SqlParameter("@DiemCuoiNam",Tkn.DiemCuoiNam);
            sp[3] = new SqlParameter("@HKCuoiNam",Tkn.HKCuoiNam);
            sp[4] = new SqlParameter("@MaNam", Tkn.MaNam);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int Update()
        {
            string sql = "update TKNAM set MaHS=@MaHS,DiemCuoiNam=@DiemCuoiNam,HKCuoiNam=@HKCuoiNam,MaNam=@MaNam where MaBTKN=@MaBTKN";
            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@MaBTKN", Tkn.MaTKN);
            sp[1] = new SqlParameter("@MaHS", Tkn.MaHS);
            sp[2] = new SqlParameter("@DiemCuoiNam", Tkn.DiemCuoiNam);
            sp[3] = new SqlParameter("@HKCuoiNam", Tkn.HKCuoiNam);
            sp[4] = new SqlParameter("@MaNam", Tkn.MaNam);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int Delete(string matkn)
        {
            string sql = "delete from TKNAM where MaBTKN=@MaBTKN";
            SqlParameter sp = new SqlParameter("@MaBTKN", Tkn.MaTKN);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public DataTable List()
        {
            string sql = "select * from TKNAM";
            return conectData.LoadData(sql);
        }
        // cac ham select se duoc viet tiep o day.
    }

