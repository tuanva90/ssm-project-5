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
public class HocKyDAO : System.Web.Services.WebService
{
    ConectData conectData = new ConectData();
    private HocKyDTO _hk;

    public HocKyDTO Hk
    {
        get { return _hk; }
        set { _hk = value; }
    }

    [WebMethod]
    public int Insert()
    {
        string sql = "insert into HOCKY values (@MaHK,@HocKy,@MaNam)";
        SqlParameter[] sp = new SqlParameter[3];
        sp[0] = new SqlParameter("@MaHK",Hk.MaHK);
        sp[1] = new SqlParameter("@HocKy", Hk.Ten_HocKy);
        sp[2] = new SqlParameter("@MaNam", Hk.MaNam);
        return conectData.Insert_Update_Delete(sql, sp);
    }
    [WebMethod]
    public int Update()
    {
        string sql = "update HOCKY set HocKy=@HocKy,MaNam=@MaNam where MaHK=@MaHK";
        SqlParameter[] sp = new SqlParameter[3];
        sp[0] = new SqlParameter("@MaHK", Hk.MaHK);
        sp[1] = new SqlParameter("@HocKy", Hk.Ten_HocKy);
        sp[2] = new SqlParameter("@MaNam", Hk.MaNam);
        return conectData.Insert_Update_Delete(sql, sp);
    }
    [WebMethod]
    public int Delete(string MaHK)
    {
        string sql = "delete from HOCKY where MaHK=@MaHK";
        SqlParameter sp = new SqlParameter("@MaHK", MaHK);
        return conectData.Insert_Update_Delete(sql, sp);
    }
    [WebMethod]
    public DataTable List()
    {
        string sql = "select * from HOCKY";
        return conectData.LoadData(sql);
    }
    // cac ham select se duoc viet tiep o day.
}

