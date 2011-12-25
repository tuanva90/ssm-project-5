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
/// Summary description for CT_KhoiLop_MonHoc
/// </summary>
public class CT_KhoiLop_MonHocBUS
{
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
	public CT_KhoiLop_MonHocBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Insert(string mamon, int maklmh)
    {
        return sv.CT_KL_Mon_Insert(mamon, maklmh);
    }
    public int Delete(string mamon, int maklmh)
    {
        return sv.CT_KL_Mon_Delete(mamon, maklmh);
    }
    public bool Check(string manam, string makhoi, string mamon)
    {
        return sv.CT_KL_MH_Check(manam, makhoi, mamon);
    }
    public DataTable List_MH_KL(string manam, string makhoi)
    {
        return sv.CT_KL_MH_List_MH_KL(manam, makhoi);
    }

}
