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
/// Summary description for GiaoVienBUS
/// </summary>
public class GiaoVienBUS
{
   
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
	public GiaoVienBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
  
    public DataTable ListGV()
    {
           
        return sv.GiaoVien_List();
        
    }
    public DataTable SearchbyMaGV(string magv)
    {
            
                return sv.GiaoVien_SearchbyMa(magv);
    }
    public DataTable SearchMaGV_Full(string magv)
    {
        
        return sv.GiaoVien_SearchbyMa_Full(magv);
    }
    public DataTable SearchbyTen(string ten)
    {
        
        return sv.GiaoVien_SearchbyName(ten);
    }
    public int Delete(string magv)
    {
        
        return sv.GiaoVien_Delete(magv);
    }
    public int Update(SSM_Service.GiaoVienDTO gvd) 
    {
        
        return sv.GiaoVien_Update(gvd);
    }
    public string GetMaGV()
    {
      
        return sv.GiaoVien_getMa();
    }
    public int Insert(SSM_Service.GiaoVienDTO gvd)
    {
        
        return sv.GiaoVien_Insert(gvd);
    }
  }
