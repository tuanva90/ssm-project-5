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
/// Summary description for HocKyBUS
/// </summary>
public class HocKyBUS
{
   
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
	public HocKyBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Insert(SSM_Service.HocKyDTO hk) // HocKyDAO.HocKyDTO hkdto)
    {
         return sv.HocKy_Insert(hk);
    }
    public string getMa()
    {
        return sv.HocKy_getMa();
    }
    public int Delete(string manam)
    {
        return sv.HocKy_Delete(manam);
    }
    public DataTable Searchbymanam(string manam)
    {
         return sv.HocKy_searchbyMaNam(manam);
    }
}
