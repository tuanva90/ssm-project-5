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

public partial class Admin_DiemTBMon_TK : System.Web.UI.Page
{
    BDM_HKBUS bdmbus = new BDM_HKBUS();
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ddnamhoc.DataSource = sv.NamHoc_List();
                ddnamhoc.DataBind();
                ddlhk.DataSource = sv.HocKy_searchbyMaNam(ddnamhoc.SelectedValue.ToString());
                ddlhk.DataBind();
                ddllop.DataSource = sv.Lop_ListbyNamHoc(ddnamhoc.SelectedValue.ToString());
                ddllop.DataBind();
                gvdiemtbmon.DataSource = bdmbus.List_DiemCacMon(ddllop.SelectedValue.ToString(), ddnamhoc.SelectedValue.ToString(), ddlhk.SelectedValue.ToString());
                gvdiemtbmon.DataBind();
            }
            catch
            {
                lblinfor.Text = " Không tìm thấy kết quả nào !";
            }
        }
    }
    protected void gvdiemtbmon_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlhk_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvdiemtbmon.DataSource = bdmbus.List_DiemCacMon(ddllop.SelectedValue.ToString(), ddnamhoc.SelectedValue.ToString(), ddlhk.SelectedValue.ToString());
        gvdiemtbmon.DataBind();
    }
    protected void ddllop_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvdiemtbmon.DataSource = bdmbus.List_DiemCacMon(ddllop.SelectedValue.ToString(), ddnamhoc.SelectedValue.ToString(), ddlhk.SelectedValue.ToString());
        gvdiemtbmon.DataBind();
    }
    protected void ddnamhoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlhk.DataSource = sv.HocKy_searchbyMaNam(ddnamhoc.SelectedValue.ToString());
            ddlhk.DataBind();
            ddllop.DataSource = sv.Lop_ListbyNamHoc(ddnamhoc.SelectedValue.ToString());
            ddllop.DataBind();
            gvdiemtbmon.DataSource = bdmbus.List_DiemCacMon(ddllop.SelectedValue.ToString(), ddnamhoc.SelectedValue.ToString(), ddlhk.SelectedValue.ToString());
            gvdiemtbmon.DataBind();
        }
        catch
        {
            DataTable dt = new DataTable();
            gvdiemtbmon.DataSource = dt;
            gvdiemtbmon.DataBind();
            lblinfor.Text = " Không tìm thấy kết quả nào !";
        }
    }
    protected void gvdiemtbmon_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdiemtbmon.PageIndex = e.NewPageIndex;
        gvdiemtbmon.DataSource = bdmbus.List_DiemCacMon(ddllop.SelectedValue.ToString(), ddnamhoc.SelectedValue.ToString(), ddlhk.SelectedValue.ToString());
        gvdiemtbmon.DataBind();
    }
}
