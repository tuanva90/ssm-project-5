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

public partial class Admin_QuanlyNamHoc : System.Web.UI.Page
{
    NamHocBUS nhbus = new NamHocBUS();
    HocKyBUS hkbus = new HocKyBUS();
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
    SSM_Service.NamHocDTO nhdto = new SSM_Service.NamHocDTO();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            gvnamhoc.DataSource = nhbus.List();
            gvnamhoc.DataBind();
        }
        Label lb = (Label)Master.FindControl("page_title");
        lb.Text = "Quản Lý Năm Học";
    }

      protected void gvnamhoc_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvnamhoc.EditIndex = e.NewEditIndex;
        gvnamhoc.DataSource = nhbus.List();
        gvnamhoc.DataBind();
    }
    protected void gvnamhoc_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      nhdto.MaNam = gvnamhoc.DataKeys[e.RowIndex].Value.ToString();
      TextBox tx = (TextBox)gvnamhoc.Rows[e.RowIndex].FindControl("txttennam");
      if (sv.NamHoc_checkTrungtennam(tx.Text.ToString()) == true )
      {
          Response.Write("<script>alert('Tên năm học này đã tồn tại')</script>");
      }
      else
      {
          nhdto.Ten_NamHoc = tx.Text.ToString();
          gvnamhoc.EditIndex = -1;
          int result = nhbus.Update(nhdto);
          if (result > 0)
          {
              Response.Write("<script>alert('Sửa thông tin thành công')</script>");
          }
          else
          {
              Response.Write("<script>alert('Sửa thất bại')</script>");
          }
          gvnamhoc.DataSource = nhbus.List();
          gvnamhoc.DataBind();
          MultiView2.ActiveViewIndex = -1;
      }
    }
    protected void gvnamhoc_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
         gvnamhoc.EditIndex = -1;
        gvnamhoc.DataSource = nhbus.List();
        gvnamhoc.DataBind();

    }
    protected void gvnamhoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvnamhoc.PageIndex = e.NewPageIndex;
        gvnamhoc.DataSource = nhbus.List();
        gvnamhoc.DataBind();
        MultiView2.ActiveViewIndex = -1;
    }
    protected void gvnamhoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (nhbus.Delete(gvnamhoc.DataKeys[e.RowIndex].Value.ToString()) > 0)
        {
            Response.Write("<script>alert('Xóa " + gvnamhoc.DataKeys[e.RowIndex].Value.ToString() + " thành công !')</script>");
            gvnamhoc.DataSource = nhbus.List();
            gvnamhoc.DataBind();
        }
        else
            Response.Write("<script>alert('Xóa " + gvnamhoc.DataKeys[e.RowIndex].Value.ToString() + " thất bại vì có một số ràng buộc khóa ngoại !')</script>");
        MultiView2.ActiveViewIndex = -1;
    }
    protected void gvnamhoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["index"] = gvnamhoc.SelectedValue;
       dthk.DataSource = hkbus.Searchbymanam(Session["index"].ToString());
       dthk.DataBind();
        MultiView2.ActiveViewIndex = 0;
      }
    protected void lbtnthem_Click(object sender, EventArgs e)
    {
        nhdto.MaNam = nhbus.getMa();
        TextBox tx = (TextBox)gvnamhoc.FooterRow.FindControl("txttennam_them");
       nhdto.Ten_NamHoc = tx.Text.ToString();
       if (sv.NamHoc_checkTrungtennam(tx.Text.ToString()) == true)
       {
           Response.Write("<script>alert('Tên năm học này đã tồn tại')</script>");
       }
       else
       {
           if (nhbus.Insert(nhdto) > 0)
           {
               Response.Write("<script>alert('Thêm thành công')</script>");
               gvnamhoc.DataSource = nhbus.List();
               gvnamhoc.DataBind();
           }
           MultiView2.ActiveViewIndex = -1;
       }
    }
}
