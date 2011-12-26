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

public partial class Admin_QuanlyGV : System.Web.UI.Page
{
    GiaoVienBUS gvbus = new GiaoVienBUS();
    ToBUS tobus = new ToBUS();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;
        if (!IsPostBack)
        {
            gvdsgv.DataSource = gvbus.ListGV();
            gvdsgv.DataBind();           
            ddlmato.DataSource = tobus.List();
           ddlmato.DataBind();
        }
        //Thay doi title cua tung trang
        Label lb = (Label)Master.FindControl("page_title");
        lb.Text = "Quản Lý Giáo Viên";
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SSM_Service.GiaoVienDTO gvdto = new SSM_Service.GiaoVienDTO();
        gvdto.MaGV = lblmagv.Text.ToString();
        gvdto.HoTen = txthoten.Text.ToString();
        if (ckbgioitinh.Checked == true)
        {
            gvdto.GioiTinh = 1;
        }
        else
            gvdto.GioiTinh = 0;
        gvdto.SoDienThoai = txtsodienthoai.Text.ToString();
        gvdto.ChuyenNghanh = txtchuyennganh.Text.ToString();
        gvdto.TrinhDoChuyenMon = txttrinhdochuyenmon.Text.ToString();
        gvdto.SoTruong = txtsotruong.Text.ToString();
        gvdto.MaTo = ddlmato.SelectedValue.ToString();
        gvdto.NgaySinh = txtDate.Text.ToString();
        gvdto.DiaChi = txtdiachi.Text.ToString();
        if (gvbus.Update(gvdto) > 0)
        {
            Response.Write("<script>alert('Sửa thông tin " + lblmagv.Text.ToString() + " thành công !')</script>");
            //Response.Redirect("QuanlyGV.aspx");
            gvdsgv.DataSource = gvbus.ListGV();
            gvdsgv.DataBind();
            MultiView3.ActiveViewIndex = -1;
            MultiView2.ActiveViewIndex = -1;
        }
             }
    protected void gvdshs_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["index"] = gvdsgv.SelectedValue;
        dtgv.DataSource = gvbus.SearchMaGV_Full(Session["index"].ToString());
        dtgv.DataBind();
        MultiView2.ActiveViewIndex = 0;
        MultiView3.ActiveViewIndex = -1;
    }
    protected void btntim_Click(object sender, ImageClickEventArgs e)
    {
          MultiView2.ActiveViewIndex = -1;
          MultiView3.ActiveViewIndex = -1;
        if (ddltim.SelectedValue.ToString().Equals("HoTen"))
        {
            gvdsgv.DataSource = gvbus.SearchbyTen(txttim.Text.ToString());
        }
        else
        {
            gvdsgv.DataSource =gvbus.SearchbyMaGV(txttim.Text.ToString());
        }
        gvdsgv.DataBind();
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Reset();
        btnthem.Visible = true;
        btnhuy.Visible = true;
        btnUpdate.Visible = false;
        btnCancel.Visible = false;
        lblmagv.Text = "GV" + gvbus.GetMaGV();
        MultiView3.ActiveViewIndex = 0;
        MultiView2.ActiveViewIndex = -1;
        lblthongtinhocsinh.Text = "Thêm thông tin giáo viên";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        MultiView3.ActiveViewIndex = -1;
    }
    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        MultiView3.ActiveViewIndex = 0;
        lblthongtinhocsinh.Text = " Sửa thông tin giáo viên";
        btnhuy.Visible = false;
        btnthem.Visible = false;
        btnUpdate.Visible = true;
        btnCancel.Visible = true;
        DataTable dt = gvbus.SearchMaGV_Full(Session["index"].ToString());
        lblmagv.Text = dt.Rows[0][0].ToString();
        txthoten.Text = dt.Rows[0][1].ToString();
        if (dt.Rows[0][2].ToString() == "1")
            ckbgioitinh.Checked = true;
        else
            ckbgioitinh.Checked = false;
        txtsodienthoai.Text = dt.Rows[0][3].ToString();
        txtchuyennganh.Text = dt.Rows[0][4].ToString();
        txttrinhdochuyenmon.Text = dt.Rows[0][5].ToString();
        txtsotruong.Text = dt.Rows[0][6].ToString();
        ddlmato.DataTextField = dt.Rows[0][7].ToString();
        txtDate.Text = dt.Rows[0][8].ToString();
        txtdiachi.Text = dt.Rows[0][9].ToString();
        MultiView2.ActiveViewIndex = -1;
           }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (gvbus.Delete(Session["index"].ToString()) > 0)
        {
            Response.Write("<script>alert('Xóa " + Session["index"].ToString() + " thành công !')</script>");
            Server.Transfer("QuanlyGV.aspx", false);
        }
        else
            Response.Write("<script>alert('Xóa " + Session["index"].ToString() + " thất bại vì có một số ràng buộc khóa ngoại !')</script>");
    }
    protected void gvdshs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdsgv.PageIndex = e.NewPageIndex;
        gvdsgv.DataSource = gvbus.ListGV();
        gvdsgv.DataBind();
    }
    protected void btnthem_Click(object sender, EventArgs e)
    {
        SSM_Service.GiaoVienDTO gvdto = new SSM_Service.GiaoVienDTO();
        gvdto.MaGV = lblmagv.Text.ToString();
        gvdto.HoTen = txthoten.Text.ToString();
        if (ckbgioitinh.Checked == true)
        {
            gvdto.GioiTinh = 1;
        }
        else
            gvdto.GioiTinh = 0;
        gvdto.SoDienThoai = txtsodienthoai.Text.ToString();
        gvdto.ChuyenNghanh = txtchuyennganh.Text.ToString();
        gvdto.TrinhDoChuyenMon = txttrinhdochuyenmon.Text.ToString();
        gvdto.SoTruong = txtsotruong.Text.ToString();
        gvdto.MaTo = ddlmato.SelectedValue.ToString();
        gvdto.NgaySinh = txtDate.Text.ToString();
        gvdto.DiaChi = txtdiachi.Text.ToString();
        if (gvbus.Insert(gvdto) > 0)
        {
            Response.Write("<script>alert('Thêm giáo viên " + lblmagv.Text.ToString() + " thành công !')</script>");
            Response.Redirect("QuanlyGV.aspx");
            MultiView3.ActiveViewIndex = 0;
            lblmagv.Text = "GV"+gvbus.GetMaGV();
            Reset();
        }
    }
    public void Reset()
    {
        txthoten.Text = "";
        txtsodienthoai.Text = "";
        txtchuyennganh.Text = "";
        txtsotruong.Text = "";
        txttrinhdochuyenmon.Text = "";
        txtdiachi.Text = "";
    }
    protected void btnhuy_Click(object sender, EventArgs e)
    {
        MultiView3.ActiveViewIndex = -1;
        MultiView2.ActiveViewIndex = 0;
    }
    protected void lblcancel_Click(object sender, EventArgs e)
    {
        MultiView3.ActiveViewIndex = -1;
        MultiView2.ActiveViewIndex = -1;    
    }
    protected void dtgv_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {

    }
    protected void gvdsgv_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
   
    protected void dtgv_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {

    }
}
