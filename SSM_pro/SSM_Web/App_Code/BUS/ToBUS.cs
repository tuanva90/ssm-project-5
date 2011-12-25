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
/// Summary description for ToBUS
/// </summary>
public class ToBUS
{
   
    SSM_Service.SSM_Services sm = new SSM_Service.SSM_Services();
	public ToBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable List()
    {
        return sm.To_List();
    }
    public string getMaTo()
    {
        return sm.To_getMa();
    }
    public int Update(SSM_Service.ToDTO to) //ToDAO.ToDTO to)
    {
        return sm.To_Update(to);
    }
    public int Delete(string mato)
    {
        return sm.To_Delete(mato);
    }
    public int Insert(SSM_Service.ToDTO to)
    {
        return sm.To_Insert(to);
    }
}
