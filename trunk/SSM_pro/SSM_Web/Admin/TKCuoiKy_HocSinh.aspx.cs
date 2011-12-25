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

public partial class Admin_TKCuoiKy_HocSinh : System.Web.UI.Page
{
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
    BDM_HKBUS bdmbus = new BDM_HKBUS();
    string mahs ;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mahs = Session["MaHS"].ToString();
            lblmahs.Text = mahs;
            lbltenhs.Text = sv.HocSinh_getHoTen(mahs);
            try
            {
                   ddnamhoc.DataSource = sv.NamHoc_List();
                    ddnamhoc.DataBind();           
                    Display();
            }
            catch
            {
                lblhanhkiem.Text = " Không tìm thấy kết quả nào!";
            }
        }

    }
    public void Display()
    {
        string mahk;
        string malop;
        string tenhk;
        if (ddlhk.SelectedValue.ToString() != "CN")
        {
            mahk = sv.HocKy_GetMaHK(ddnamhoc.SelectedValue.ToString(), ddlhk.SelectedValue.ToString());
            malop = sv.Hoc_getMaLop(mahs, mahk);
            if (sv.Hoc_GetMaHoc(mahs, malop, mahk).ToString() != "NULL")
            {
                lbllop.Text = "Lớp : " + sv.Lop_getTenLop(malop);
                lblhanhkiem.Text = "Hạnh kiểm :" + sv.Hoc_getHKCuoiKy(mahs, malop, ddnamhoc.SelectedValue.ToString(), ddlhk.SelectedValue.ToString());
                DataTable dt = bdmbus.HS_TKHocKy(mahs, ddnamhoc.SelectedValue.ToString(), mahk);
                gvtongket.DataSource = dt;
            }
            else
            {
                lbllop.Text = "";
                lblhanhkiem.Text = "";
                DataTable dt = new DataTable();
                gvtongket.DataSource = dt;
            }
        }
        else
        {
            mahk = sv.HocKy_GetMaHK(ddnamhoc.SelectedValue.ToString(), "I");
            malop = sv.Hoc_getMaLop(mahs, mahk);
            if (sv.Hoc_GetMaHoc(mahs, malop, mahk).ToString() != "NULL")
            {
                lbllop.Text = "Lớp : " + sv.Lop_getTenLop(malop);
                lblhanhkiem.Text = "Hạnh kiểm kì I : " + sv.Hoc_getHKCuoiKy(mahs, malop, ddnamhoc.SelectedValue.ToString(), "I");
                mahk = sv.HocKy_GetMaHK(ddnamhoc.SelectedValue.ToString(), "II");
                string malop1 = sv.Hoc_getMaLop(mahs, mahk);
                if (malop != malop1)
                {
                    lbllop.Text = "HK I lớp : " + sv.Lop_getTenLop(malop) + ", HK II lớp : " + sv.Lop_getTenLop(malop1);
                }
                lblhanhkiem.Text += "--------Hạnh kiểm kì II : " + sv.Hoc_getHKCuoiKy(mahs, malop, ddnamhoc.SelectedValue.ToString(), "II") + " -------- Hạnh kiểm cả năm : " + sv.TKN_get_HKCuoiNam(ddnamhoc.SelectedValue.ToString(), mahs).ToString();
                gvtongket.DataSource = bdmbus.HS_TKNam(mahs, ddnamhoc.SelectedValue.ToString());
            }
            else
            {
                lbllop.Text = "";
                lblhanhkiem.Text = "";
                DataTable dt = new DataTable();
                gvtongket.DataSource = dt;
            }
        }
        gvtongket.DataBind();
    }
    protected void ddnamhoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Display();
        }
        catch
        {
            lblhanhkiem.Text = " Không tìm thấy kết quả nào!";
        }
    }
    protected void ddlhk_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Display();
        }
        catch
        {
            lblhanhkiem.Text = " Không tìm thấy kết quả nào!";
        }
    }

protected void  gvtongket_PageIndexChanging(object sender, GridViewPageEventArgs e)
{

}
}
