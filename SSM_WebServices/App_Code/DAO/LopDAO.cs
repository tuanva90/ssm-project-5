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
public class LopDAO : System.Web.Services.WebService
    {
        ConectData conectData = new ConectData();
        private LopDTO _lop ;
     
        public LopDTO Lop1
        {
            get { return _lop; }
            set { _lop = value; }
        }
        [WebMethod]
        public int Insert()
        {
            string sql = "insert into LOP values (@MaLop,@TenLop,@MaKhoiLop,@SiSo,@MaGVCN)";
            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@MaLop", Lop1.MaLop);
            sp[1] = new SqlParameter("@TenLop", Lop1.TenLop);
            sp[2] = new SqlParameter("@MaKhoiLop", Lop1.MaKhoiLop);
            sp[3] = new SqlParameter("@SiSo", Lop1.SiSo);
            sp[4] = new SqlParameter("@MaGVCN", Lop1.MaGVCN);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public int Update()
        {
             string sql = "update LOP set TenLop=@TenLop,MaKhoiLop=@MaKhoiLop,SiSo=@SiSo,MaGVCN=@MaGVCN where MaLop=@MaLop)";
            SqlParameter[] sp = new SqlParameter[5];
             sp[0] = new SqlParameter("@MaLop", Lop1.MaLop);
            sp[1] = new SqlParameter("@TenLop", Lop1.TenLop);
            sp[2] = new SqlParameter("@MaKhoiLop", Lop1.MaKhoiLop);
            sp[3] = new SqlParameter("@SiSo", Lop1.SiSo);
              sp[4] = new SqlParameter("@MaGVCN", Lop1.MaGVCN);
             return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public int Delete(string malop)
        {
            string sql = "delete from LOP where MaLop=@malop";
            SqlParameter sp = new SqlParameter("@malop", malop);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        [WebMethod]
        public DataTable List()
        {
            string sql = "selectt * from LOP";
            return conectData.LoadData(sql);
        }
        //các hàm searchbyname, bymagvcn, by malop wll be written here!


    }

