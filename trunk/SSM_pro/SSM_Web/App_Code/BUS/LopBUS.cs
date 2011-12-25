using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for LopBUSS
/// </summary>
public class LopBUS
{
    
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
	public LopBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string getMa()
    {
        return sv.Lop_getMa();
    }
    public DataTable List()
    {
         return sv.Lop_List();
    }
    public int Update(string malop, string tenlop,string  magv)
    {  return sv.Lop_Update(malop, tenlop, magv);
    }
    public int Updatesiso(int siso, string malop)
    {
        return sv.Lop_Updatesiso(siso, malop);
    }
    public int Insert(SSM_Service.LopDTO lop)
    {
          return sv.Lop_Insert(lop);
    }
    public DataTable SearchbyMakl(string makl)
    {
        return sv.Lop_searchbyMakl(makl);
    }
    public int Delete(string malop)
    { return sv.Lop_Delete(malop);
    }
    public string SearMaKL(string malop)
    {
        return sv.Lop_SearchMakl(malop);
    }
}
