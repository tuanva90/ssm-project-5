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
    //GiaoVienBUS gv = new GiaoVienBUS();
    //ToBUS tobus = new ToBUS();
    //ToDAO.ToDTO todto = new ToDAO.ToDTO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //SSM_Services.Service s = new SSM_Services.Service();
            //SSM_Services.HocSinhDAO a = new SSM_Services.HocSinhDAO();
          // HocSinhDAO.HocSinhDAO hs = new HocSinhDAO.HocSinhDAO();
            //Services.HocSinhDTO s= new Services.HocSinhDTO();
            //HocSinhDAO.HocSinhDAO hs = new HocSinhDAO.HocSinhDAO();
            //Services.Service ss = new Services.Service();

            //GridView1.DataSource = tobus.List();
            //GridView1.DataBind();
           
            //GridView1.DataSource = ss.lihs();
            //GridView1.DataBind();
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
            }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //GridView1.EditIndex = e.NewEditIndex;
        //GridView1.DataSource = tobus.List();
        //GridView1.DataBind();
           
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //todto.MaTo = GridView1.DataKeys[e.RowIndex].Value.ToString();
        ////todto.TenTo=
        //GridViewRow row = GridView1.SelectedRow;
        //TextBox tx = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txttento");

        //Label1.Text = tx.Text.ToString();
    }
}
