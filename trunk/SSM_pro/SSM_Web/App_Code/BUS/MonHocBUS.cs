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
/// Summary description for MonHocBUS
/// </summary>
public class MonHocBUS
{
    //MonHocDAO.MonHocDAO mhdao = new MonHocDAO.MonHocDAO();
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
	public MonHocBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string getMa()
    {
        return sv.MonHoc_getMa();
    }
    public DataTable List()
    {
        return sv.MonHoc_List();
    }
    public DataTable searchbyMa(string ma)
    {
         return sv.MonHoc_SearchbyMa(ma);
    }
    public DataTable searchbyTen(string ten)
    {
         return sv.MonHoc_SeaerchbyTen(ten);
    }
    public int Insert(SSM_Service.MonHocDTO mh)// MonHocDAO.MonHocDTO mh)
    {
         return sv.MonHoc_Insert(mh);
    }
    public int Update( SSM_Service.MonHocDTO mh)//MonHocDAO.MonHocDTO mh)
    {
         return sv.MonHoc_Update(mh);
    }
    public int Delete(string ma)
    {return sv.MonHoc_Delete(ma);
    }
}
