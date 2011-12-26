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
using System.Windows;

public partial class Admin_Default2 : System.Web.UI.Page
{
    HocSinhBUS hsbus = new HocSinhBUS();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;
        if (!IsPostBack)
        {
            gvdshs.DataSource = hsbus.ListHS();
            gvdshs.DataBind();
        }
        Label lb = (Label)Master.FindControl("page_title");
        lb.Text = "Quản Lý Học Sinh";
    }
    
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("ThemHocSinh.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //HocSinhDAO.HocSinhDTO hsdto = new HocSinhDAO.HocSinhDTO();
        SSM_Service.HocSinhDTO hsdto = new SSM_Service.HocSinhDTO();
        hsdto.MaHS = lblmahs.Text.ToString();
        hsdto.HoTen = txthoten.Text.ToString();
        if (ckbgioitinh.Checked == true)
        {
            hsdto.GioiTinh = 1;
        }
        else
            hsdto.GioiTinh = 0;
        hsdto.SoDienThoai = txtsodienthoai.Text.ToString();
        hsdto.HoTenCha = txthotencha.Text.ToString();
        hsdto.NgheNghiepCha = txtnghenghiepcha.Text.ToString();
        hsdto.HoTenMe = txthotenme.Text.ToString();
        hsdto.NgheNghiepMe = txtnghenghiepme.Text.ToString();
        hsdto.DiaChi = txtdiachi.Text.ToString();
        hsdto.NgaySinh = txtDate.Text.ToString();
        if (hsbus.UpdateHS(hsdto) > 0)
        {
            Response.Write("<script>alert('Sửa  thành công !')</script>");
           // Response.Redirect("QuanlyHS.aspx");
        }

       
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        MultiView3.ActiveViewIndex = -1;
    }
    protected void gvdshs_SelectedIndexChanged(object sender, EventArgs e)
    {

        Session["index"] = gvdshs.SelectedValue;
        dths.DataSource = hsbus.HocSinhMaHS_Full(Session["index"].ToString());
        dths.DataBind();
        MultiView2.ActiveViewIndex = 0;
        MultiView3.ActiveViewIndex = -1;
    }


    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        MultiView3.ActiveViewIndex = 0;
        MultiView2.ActiveViewIndex = -1;
        DataTable dt = hsbus.HocSinhMaHS_Full(Session["index"].ToString());
        lblmahs.Text = dt.Rows[0][0].ToString();
        txthoten.Text = dt.Rows[0][1].ToString();
        if (dt.Rows[0][2].ToString() == "1")
            ckbgioitinh.Checked = true;
        else
            ckbgioitinh.Checked = false;
        txtsodienthoai.Text = dt.Rows[0][3].ToString();
        txthotencha.Text = dt.Rows[0][4].ToString();
        txtnghenghiepcha.Text = dt.Rows[0][5].ToString();
        txthotenme.Text = dt.Rows[0][6].ToString();
        txtnghenghiepme.Text = dt.Rows[0][7].ToString();
        txtDate.Text = dt.Rows[0][8].ToString();
        txtdiachi.Text = dt.Rows[0][9].ToString();

    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (hsbus.DeleteHS(Session["index"].ToString()) > 0)
        {
            Response.Write("<script>alert('Xóa " + Session["index"].ToString() + " thành công !')</script>");
            Server.Transfer("QuanlyHS.aspx", false);
        }
        else
            Response.Write("<script>alert('Xóa " + Session["index"].ToString() + " thất bại vì có một số ràng buộc khóa ngoại !')</script>");
    }
    protected void gvdshs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdshs.PageIndex = e.NewPageIndex;
        gvdshs.DataSource = hsbus.ListHS();
        gvdshs.DataBind();
    }
    protected void btntim_Click(object sender, ImageClickEventArgs e)
    {
        gvdshs.SelectedIndex = -1;
        MultiView2.ActiveViewIndex = -1;
        if (ddltim.SelectedValue.ToString().Equals("HoTen"))
        {
            gvdshs.DataSource = hsbus.HocSinhHoTen(txttim.Text.ToString());
        }
        else
        {
            gvdshs.DataSource = hsbus.HocSinhMaHS(txttim.Text.ToString());
        }
        gvdshs.DataBind();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["MaHS"] = lblmahs.Text.ToString();
        Response.Redirect("TKCuoiKy_HocSinh.aspx");

        
        //Findow.open("TKCuoiKy_HocSinh.aspx", "Window1", "menubar=no,width=430,height=360,toolbar=no"); 
      
    }
}
