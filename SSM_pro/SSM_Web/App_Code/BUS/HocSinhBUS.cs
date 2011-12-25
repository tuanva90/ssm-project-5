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
/// Summary description for HocSinhBUS
/// </summary>
public class HocSinhBUS 
{
   
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
    public HocSinhBUS() 
	{
		//
		// TODO: Add constructor logic here
		//     
       
	}
    public int Insert(SSM_Service.HocSinhDTO hs) // HocSinhDAO.HocSinhDTO dto)
    {
        return sv.HocSinh_Insert(hs);
    }
    public DataTable ListHS()
    { return sv.HocSinh_List();
    }
    public DataTable HocSinhHoTen(string hoten)// tim hoc sinh theo ten(lay thong tin hoc sinh rut gon)
    {
         return sv.HocSinh_searchbyTen(hoten);
    }
    public DataTable HocSinhMaHS(string mahs)// tim hoc sinh theo ma hoc sinh(thong tin hoc sinh rut gon)
    {
       
        return sv.HocSinh_searchbyMa(mahs);
    }
    public DataTable HocSinhMaHS_Full(string mahs) // lay full thong tin hoc sinh
    {
        return sv.HocSinh_SearchbyMa_FULL(mahs);
    }
    public int UpdateHS(SSM_Service.HocSinhDTO hs)  // update thong tin hoc sinh
    {
        return sv.HocSinh_Update(hs);
    }
    public int DeleteHS(string mahs) // xoa hoc sinh theo ma hs
    {
         return sv.Hoc_Delete(mahs);
    }
    public string getMaHS(string ma) // lay ma hoc sinh
    {
        return sv.HocSinh_getMa(ma);
    }
    public DataTable HSchuaphanlop(string manam)
    {
        return sv.HocSinh_HSchuaphanlop(manam);
    }
    
   }
