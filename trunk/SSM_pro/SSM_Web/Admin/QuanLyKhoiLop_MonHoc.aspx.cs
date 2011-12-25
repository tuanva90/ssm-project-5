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
public partial class Admin_QuanLyKhoiLop_MonHoc : System.Web.UI.Page
{
    MonHocBUS mhbus = new MonHocBUS();
    CT_KhoiLop_MonHocBUS ctklm = new CT_KhoiLop_MonHocBUS();
    KhoiLop_MonHocBUS klmh = new KhoiLop_MonHocBUS();
    NamHocBUS nhbus = new NamHocBUS();
    KhoiLopBUS klbus = new KhoiLopBUS();
    HocKyBUS hk = new HocKyBUS();
    BDM_HKBUS bd = new BDM_HKBUS();
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddnamhoc.DataSource = nhbus.List();
            ddnamhoc.DataBind();
            ddlkhoilop.DataSource = klbus.List();
          ddlkhoilop.DataBind();
            gvphanmon.DataSource = mhbus.List();
            gvphanmon.DataBind();
                  Display();
        }

    }
    public void Display() // dung de hien thi, chang han nhu khi thay doi ddl nam hoc or khoi lop, gridview se thay doi cac mon hoc da duoc chon tuong ung, ham nay se tra ve xem nhung dòng nào dấu check duoc chọn va dòng nào không
    {
        foreach(GridViewRow gvr in gvphanmon.Rows)
        {
            CheckBox cb = (CheckBox)gvr.FindControl("ckchon");
            Label mamon = (Label)gvr.FindControl("lblmamon");
            if(ctklm.Check(ddnamhoc.SelectedValue.ToString(),ddlkhoilop.SelectedValue.ToString(),mamon.Text.ToString())==true)
            {
                cb.Checked=true;
            }
            if (sv.CT_BDM_HK_Check(ddnamhoc.SelectedValue.ToString(), ddlkhoilop.SelectedValue.ToString(), mamon.Text.ToString()) == true)
            {
                cb.Enabled = false;
            }

        }
    }
    protected void ckbcheck_CheckedChanged(object sender, EventArgs e)
    {
        int sel = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
        CheckBox cb = (CheckBox)gvphanmon.Rows[sel].FindControl("ckchon");
        Label mamon = (Label)gvphanmon.Rows[sel].FindControl("lblmamon");
        int n=0;
       
        if (cb.Checked == true)
        {
            if (ctklm.Check(ddnamhoc.SelectedValue.ToString(), ddlkhoilop.SelectedValue.ToString(), mamon.Text.ToString()) == false)
            {
                n= ctklm.Insert(mamon.Text.ToString(),int.Parse(klmh.GetMa(ddnamhoc.SelectedValue.ToString(), ddlkhoilop.SelectedValue.ToString()).ToString()));
                if (sv.BDM_HK_Check_MaCTKLMH_BDMHK(sv.CT_KL_MH_GetMaCTKLMH(mamon.Text.ToString(), ddnamhoc.SelectedValue.ToString(), ddlkhoilop.SelectedValue.ToString())) == false)
                    n = bd.Insert1(ddnamhoc.SelectedValue.ToString(), mamon.Text.ToString(), ddlkhoilop.SelectedValue.ToString());
                    
            }
        }
        else
        {
            if (ctklm.Check(ddnamhoc.SelectedValue.ToString(), ddlkhoilop.SelectedValue.ToString(), mamon.Text.ToString()) == true)
            {
                n = ctklm.Delete(mamon.Text.ToString(), int.Parse(klmh.GetMa(ddnamhoc.SelectedValue.ToString(), ddlkhoilop.SelectedValue.ToString()).ToString()));
                if(n!=1)
                    Response.Write("<script>alert('Không thể xóa môn này vì có ràng buộc khóa ngoại!')</script>");

            }
        }

    }
    protected void ddnamhoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvphanmon.DataSource = mhbus.List();
        gvphanmon.DataBind();
          Display();
    }
    protected void ddlkhoilop_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvphanmon.DataSource = mhbus.List();
        gvphanmon.DataBind();
        Display();
    }

    protected void gvphanmon_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvphanmon_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvphanmon.PageIndex = e.NewPageIndex;
        gvphanmon.DataSource = mhbus.List();
        gvphanmon.DataBind();
        Display();

    }
}
