using System;
using System.Collections;
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
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
                   SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
                   gvtest.DataSource = sv.GiaoVien_List();
                   gvtest.DataBind();
            
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
    protected void gvtest_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvtest_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvtest.EditIndex = e.NewEditIndex;
        gvtest.DataSource = sv.GiaoVien_List();
        gvtest.DataBind();
    }
    protected void gvtest_RowEditing1(object sender, GridViewEditEventArgs e)
    {
        gvtest.EditIndex = e.NewEditIndex;
        gvtest.DataSource = sv.GiaoVien_List();
        gvtest.DataBind();
    }
    protected void gvtest_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}
