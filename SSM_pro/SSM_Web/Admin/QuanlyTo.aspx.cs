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

public partial class Admin_QuanlyTo : System.Web.UI.Page
{
    ToBUS tobus = new ToBUS();
    MonHocBUS mhbus = new MonHocBUS();
    SSM_Service.CT_ToDTO cttodto = new SSM_Service.CT_ToDTO();
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
    SSM_Service.MonHocDTO mhdto = new SSM_Service.MonHocDTO();
    SSM_Service.ToDTO todto = new SSM_Service.ToDTO();
     protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvto.DataSource = tobus.List();
            gvto.DataBind();
            gvmon.DataSource = mhbus.List();
            gvmon.DataBind();
        }
    }

    protected void gvto_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvto.EditIndex = e.NewEditIndex;
        gvto.DataSource = tobus.List();
        gvto.DataBind();
    }
    protected void gvto_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
         todto.MaTo = gvto.DataKeys[e.RowIndex].Value.ToString();
         TextBox tx = (TextBox)gvto.Rows[e.RowIndex].FindControl("txttento");
         Label lb = (Label)gvto.Rows[e.RowIndex].FindControl("lblmato");
         DropDownList mon = (DropDownList)gvto.Rows[e.RowIndex].FindControl("ddlmonhoc");
         string tento = sv.To_searchbyMa(lb.Text.ToString()).Rows[0]["Tên tổ"].ToString();
         if (sv.To_checkTrungten(tx.Text.ToString()) == true && tx.Text.ToString()!=tento)
         {
             Response.Write("<script>alert('Tên tổ đã tồn tại !')</script>");
         }
         else
         {
             todto.TenTo = tx.Text.ToString();
             gvto.EditIndex = -1;
             int result = tobus.Update(todto);
             if (result > 0)
             {
                 Response.Write("<script>alert('Sửa thông tin thành công')</script>");
             }
             else
             {
                 Response.Write("<script>alert('Sửa thất bại')</script>");
             }
             gvto.DataSource = tobus.List();
             gvto.DataBind();
         }
    }
    protected void gvto_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvto.EditIndex = -1;        
        gvto.DataSource = tobus.List();
        gvto.DataBind();
    }
    protected void gvto_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (tobus.Delete(gvto.DataKeys[e.RowIndex].Value.ToString()) > 0)
        {
            Response.Write("<script>alert('Xóa " + gvto.DataKeys[e.RowIndex].Value.ToString() + " thành công !')</script>");
            gvto.DataSource = tobus.List();
            gvto.DataBind();
        }
        else
            Response.Write("<script>alert('Xóa " + gvto.DataKeys[e.RowIndex].Value.ToString() + " thất bại vì có một số ràng buộc khóa ngoại !')</script>");
    }
    protected void btntim_Click(object sender, ImageClickEventArgs e)
    {
        PopUp("Default.aspx");
    }
    public void PopUp(string url)
    {
        string popup = "<script language='javascript'>" +
                       "window.open('" + url + "', 'CustomPopUp', " +
                       "'width=200, height=200, resizable=no')" +
                       "</script>";

        Page.RegisterStartupScript("Popup", popup);
    }
    protected void gvto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvto.PageIndex = e.NewPageIndex;
        gvto.DataSource = tobus.List();
        gvto.DataBind();
    }
      protected void LinkButton2_Click(object sender, EventArgs e)
    {

    }
    protected void lbtnthem_Click(object sender, EventArgs e)
    {
        todto.MaTo = tobus.getMaTo();
        TextBox tx = (TextBox)gvto.FooterRow.FindControl("txttento_them");
        if (sv.To_checkTrungten(tx.Text.ToString()) == true)
        {
            Response.Write("<script>alert('Tên tổ đã tồn tại !')</script>");
        }
        else
        {
            todto.TenTo = tx.Text.ToString();
            if (tobus.Insert(todto) > 0)
            {
                Response.Write("<script>alert('Thêm thành công')</script>");
                gvto.DataSource = tobus.List();
                gvto.DataBind();
            }
        }
    }
    protected void gvmon_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvmon.EditIndex = e.NewEditIndex;       
        gvmon.DataSource = mhbus.List();
        gvmon.DataBind();
    }
    protected void gvmon_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvmon_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        mhdto.MaMon = gvmon.DataKeys[e.RowIndex].Value.ToString();
        TextBox tx = (TextBox)gvmon.Rows[e.RowIndex].FindControl("txttenmon");
        Label lb = (Label)gvto.Rows[e.RowIndex].FindControl("lblmamon");
        string tenmon = sv.To_searchbyMa(lb.Text.ToString()).Rows[0]["Tên môn"].ToString();
        if (sv.MonHoc_checkTrungtenmon(tx.Text.ToString()) == true && tx.Text.ToString() != tenmon)
        {
            Response.Write("<script>alert('Tên môn học này đã tồn tại !')</script>");
        }
        else
        {
            TextBox heso = (TextBox)gvmon.FooterRow.FindControl("txtheso");
            mhdto.TenMon = tx.Text.ToString();
            mhdto.HeSo = int.Parse(heso.Text.ToString());
            gvmon.EditIndex = -1;
            int result = mhbus.Update(mhdto);
            if (result > 0)
            {
                Response.Write("<script>alert('Sửa thông tin thành công')</script>");
            }
            else
            {
                Response.Write("<script>alert('Sửa thất bại')</script>");
            }
            //Response.Redirect("QuanlyTo.aspx");
            gvmon.DataSource = mhbus.List();
            gvmon.DataBind();
        }
    }
    protected void gvmon_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvmon.EditIndex = -1;
        gvmon.DataSource = mhbus.List();
        gvmon.DataBind();
    }
    protected void gvmon_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (mhbus.Delete(gvmon.DataKeys[e.RowIndex].Value.ToString()) > 0)
        {
            Response.Write("<script>alert('Xóa " + gvto.DataKeys[e.RowIndex].Value.ToString() + "thành công !')</script>");
            //Server.Transfer("QuanlyTo.aspx", false);
            gvmon.DataSource = mhbus.List();
            gvmon.DataBind();
        }
        else
            Response.Write("<script>alert('Xóa " + gvto.DataKeys[e.RowIndex].Value.ToString() + "thất bại vì có một số ràng buộc khóa ngoại !')</script>");
    }
    protected void gvmon_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvmon.PageIndex = e.NewPageIndex;
        gvmon.DataSource = mhbus.List();
        gvmon.DataBind();
    }
    protected void gvto_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        MultiView2.ActiveViewIndex = 0;
        MultiView3.ActiveViewIndex = -1;
    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        MultiView3.ActiveViewIndex = 0;
        MultiView2.ActiveViewIndex = -1;
    }
    protected void gvto_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void lbtnthemmon_Click(object sender, EventArgs e)
    {
        mhdto.MaMon = mhbus.getMa();
        TextBox tx = (TextBox)gvmon.FooterRow.FindControl("txttenmon_them");
        TextBox heso = (TextBox)gvmon.FooterRow.FindControl("txtheso_them");
        if (sv.MonHoc_checkTrungtenmon(tx.Text.ToString()) == true)
        {
            Response.Write("<script>alert('Tên môn học này đã tồn tại !')</script>");
        }
        else
        {
            mhdto.TenMon = tx.Text.ToString();
            mhdto.HeSo = int.Parse(heso.Text.ToString());
            if (mhbus.Insert(mhdto) > 0)
            {
                Response.Write("<script>alert('Thêm thành công')</script>");
                //Response.Redirect("QuanlyTo.aspx");
                gvmon.DataSource = mhbus.List();
                gvmon.DataBind();
            }
        }
    }
    protected void txttim_TextChanged(object sender, EventArgs e)
    {

    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {

    }
}
