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
/// Summary description for CT_BDM_HKBUS
/// </summary>
public class CT_BDM_HKBUS
{
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
	public CT_BDM_HKBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Insert(SSM_Service.CT_BDM_HKDTO ct)
    {
        return sv.CT_BDM_HK_Insert(ct);
    }
    public int UpdateDiem(SSM_Service.CT_BDM_HKDTO ct)
    {
        return sv.CT_BDM_HK_Update(ct);
    }
     public DataTable List(string mahk, string malop, string mamon)
    {
        return sv.CT_BDM_HK_List(mahk, malop, mamon);
    }
     public int Delete(int mahoc, int ctklmh)
    {
        return sv.CT_BDM_HK_Delete(mahoc, ctklmh);
    }
     public int GetMaBDM(int mahoc, int ctklmh)
    {
        return sv.CT_BDM_HK_GetMaBDM(mahoc, ctklmh);
    }
     public bool Check(string manam, string makhoilop, string mamon)
     {
         return sv.CT_BDM_HK_Check(manam, makhoilop, mamon);
     }
}
