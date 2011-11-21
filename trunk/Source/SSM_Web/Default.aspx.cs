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
public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //SSM_Services.Service s = new SSM_Services.Service();
            //SSM_Services.HocSinhDAO a = new SSM_Services.HocSinhDAO();
            
            //GridView1.DataSource = s.DisplayHocSinh();
            //GridView1.DataBind();
      
           // HocSinhDAO.HocSinhDAO hs = new HocSinhDAO.HocSinhDAO();
            Services.HocSinhDTO s= new Services.HocSinhDTO();
            HocSinhDAO.HocSinhDAO hs = new HocSinhDAO.HocSinhDAO();
            
           
            
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
