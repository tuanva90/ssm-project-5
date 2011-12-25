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

public partial class Admin_QuanlyLop : System.Web.UI.Page
{
    KhoiLopBUS klbus = new KhoiLopBUS();
    LopBUS lopbus = new LopBUS();
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
    SSM_Service.LopDTO ldto = new SSM_Service.LopDTO();
    GiaoVienBUS gvbus = new GiaoVienBUS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList dllgvcn = (DropDownList)gvlop.FooterRow.FindControl("ddlgvcn_them");
            dllgvcn.DataSource = GetGV();
            dllgvcn.DataBind();
            gvkhoilop.DataSource = klbus.List();
            gvkhoilop.DataBind();
            MultiView2.ActiveViewIndex = 0;
        }

    }
    protected void btntim_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void gvlop_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gvlop_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvlop.EditIndex = -1;
        gvlop.DataSource = lopbus.SearchbyMakl(Session["index"].ToString());
        gvlop.DataBind();
    }
    protected void gvlop_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (lopbus.Delete(gvlop.DataKeys[e.RowIndex].Value.ToString()) > 0)
        {
            Response.Write("<script>alert('Xóa " + gvlop.DataKeys[e.RowIndex].Value.ToString() + "thành công !')</script>");
            gvlop.DataSource = lopbus.SearchbyMakl(Session["index"].ToString());
              gvlop.DataBind();
        }
        else
            Response.Write("<script>alert('Xóa " + gvlop.DataKeys[e.RowIndex].Value.ToString() + "thất bại vì có một số ràng buộc khóa ngoại !')</script>");
    
    }
    protected void gvlop_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox tenlop = (TextBox)gvlop.Rows[e.RowIndex].FindControl("txttenlop");
        Label lbmalop = (Label)gvlop.Rows[e.RowIndex].FindControl("lblmalop");
         DropDownList dllgvcn = (DropDownList)gvlop.Rows[e.RowIndex].FindControl("ddlgvcn");
         if (sv.Lop_checkTrungtenlop(tenlop.Text.ToString()) == true )
         {
             Response.Write("<script>alert('Tên lớp đã tồn tại !')</script>");
         }
         else
         {
             ldto.MaLop = gvlop.DataKeys[e.RowIndex].Value.ToString();
             ldto.TenLop = tenlop.Text.ToString();
             ldto.MaGVCN = dllgvcn.SelectedItem.Value.ToString();
             gvlop.EditIndex = -1;
             int result = lopbus.Update(ldto.MaLop, ldto.TenLop, ldto.MaGVCN);
             if (result > 0)
             {
                 Response.Write("<script>alert('Sửa thông tin thành công')</script>");
             }
             else
             {
                 Response.Write("<script>alert('Sửa thất bại')</script>");
             }
             //Response.Redirect("QuanlyTo.aspx");
             gvlop.DataSource = lopbus.SearchbyMakl(Session["index"].ToString());
             gvlop.DataBind();
         }
    }
    protected void gvlop_RowEditing(object sender, GridViewEditEventArgs e)
    {
       gvlop.EditIndex = e.NewEditIndex;
       gvlop.DataSource = lopbus.SearchbyMakl(Session["index"].ToString());
       gvlop.DataBind();
    }
    protected void gvkhoilop_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["index"] = gvkhoilop.SelectedValue;
        gvlop.DataSource = lopbus.SearchbyMakl(Session["index"].ToString());
        gvlop.DataBind();
        DropDownList dllgvcn = (DropDownList)gvlop.FooterRow.FindControl("ddlgvcn_them");
        dllgvcn.DataSource = GetGV();
        dllgvcn.DataBind();
        MultiView3.ActiveViewIndex = 0;
    }
    protected void gvlop_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void MultiView3_ActiveViewChanged(object sender, EventArgs e)
    {

    }
    protected DataTable GetGV()
    {
        return gvbus.ListGV();
    }
    protected DataTable GetGV()
    {
        return sv.GiaoVien_List();
    }
    protected int GetMaGV_index(string name)
    {
        DataTable dt = gvbus.ListGV();
        for (int i = 0; i < dt.DefaultView.Count; i++)
        {
            if (dt.DefaultView[i]["Họ tên"].ToString() == name)
                return i;
        }
        return 0;


    }
    protected void lbtnthemmon_Click(object sender, EventArgs e)
    {
        TextBox tenlop = (TextBox)gvlop.FooterRow.FindControl("txttenlop_them");
        DropDownList dllgvcn = (DropDownList)gvlop.FooterRow.FindControl("ddlgvcn_them");
        if (sv.Lop_checkTrungtenlop(tenlop.Text.ToString()) == true)
        {
            Response.Write("<script>alert('Tên lớp đã tồn tại !')</script>");
        }
        else
        {
            ldto.MaLop = lopbus.getMa();
            ldto.TenLop = tenlop.Text.ToString();
            ldto.MaGVCN = dllgvcn.SelectedItem.Value.ToString();
            ldto.MaKhoiLop = Session["index"].ToString();
            ldto.SiSo = 0;
            if (lopbus.Insert(ldto) > 0)
            {
                Response.Write("<script>alert('Thêm thành công')</script>");
                //Response.Redirect("QuanlyTo.aspx");
                gvlop.DataSource = lopbus.SearchbyMakl(Session["index"].ToString());
                gvlop.DataBind();
                DropDownList dllgvcn = (DropDownList)gvlop.FooterRow.FindControl("ddlgvcn_them");
                dllgvcn.DataSource = GetGV();
                dllgvcn.DataBind();
            }
        }
    }

   
}
