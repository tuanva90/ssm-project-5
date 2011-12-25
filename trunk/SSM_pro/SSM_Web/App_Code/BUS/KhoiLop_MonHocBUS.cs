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
/// Summary description for KhoiLop_MonHocBUS
/// </summary>
public class KhoiLop_MonHocBUS
{
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
	public KhoiLop_MonHocBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Insert(string manam, string makhoi)//
    {
        return sv.KhoiLop_Mon_Insert(manam, makhoi);
    }
    public int Delete(string manam, string makhoi)
    {
        return sv.KhoiLop_Mon_Delete(manam, makhoi);
    }
    public int GetMa(string manam, string makhoi)
    {
        return sv.KhoiLop_Mon_GetMa( manam, makhoi);
    }
}
