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
/// Summary description for KhoiLopBUS
/// </summary>
public class KhoiLopBUS
{
  
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
	public KhoiLopBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable List()
    {
        return sv.KLop_List();
    }
    public int Updatesolop(int solop,string makl)
    {
        return sv.KLop_UpdateSoLop(solop, makl);
    }
}
