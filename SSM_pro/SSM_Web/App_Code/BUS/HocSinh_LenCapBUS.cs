using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for HocSinh_LenCapBUS
/// </summary>
public class HocSinh_LenCapBUS
{
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
	public HocSinh_LenCapBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Insert(SSM_Service.HocSinh_LenCapDTO  hs) 
    {
        return sv.HocSinh_LenCap_Insert(hs);
    }
    public DataTable ListHocSinh_LenCap()
    {
        return sv.HocSinh_LenCap_List();
    }
    public int UpdateHS(SSM_Service.HocSinh_LenCapDTO hs)  // update thong tin hoc sinh
    {
        return sv.HocSinh_LenCap_Update(hs);
    }
}
