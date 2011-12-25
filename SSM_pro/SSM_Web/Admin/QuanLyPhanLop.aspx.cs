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

public partial class Admin_QuanLyPhanLop : System.Web.UI.Page
{
    HocSinhBUS hsbus = new HocSinhBUS();
    HocBUS hocbus = new HocBUS();
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
   SSM_Service.HocDTO hocdto = new SSM_Service.HocDTO();
    SSM_Service.CT_BDM_HKDTO ctbd=new SSM_Service.CT_BDM_HKDTO();
    SSM_Service.BDM_HKDTO bd=new SSM_Service.BDM_HKDTO();
    HocKyBUS hkbus = new HocKyBUS();
    NamHocBUS nhbus = new NamHocBUS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = nhbus.List();
            try
            {
                ddnamhoc.DataSource = sv.NamHoc_List();
                ddnamhoc.DataBind();
                gvhocsinh.DataSource = hsbus.HSchuaphanlop(dt.Rows[0][0].ToString());
                gvhocsinh.DataBind();
            }
            catch
            {
                lblinfor.Text = "Không có kết quả nào phù hợp!";
            }
          }
    }
    protected void ddnamhoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvhocsinh.DataSource = hsbus.HSchuaphanlop(ddnamhoc.SelectedItem.Value.ToString());
        gvhocsinh.DataBind(); 
    }
    protected void gvhocsinh_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lblthemvaolop_Click(object sender, EventArgs e)
    {
         int n = 0;
        DropDownList ddlmalop = (DropDownList)gvhocsinh.FooterRow.FindControl("ddllop");
        DataTable checkloptruong = hocbus.Checkloptruong(ddlmalop.SelectedItem.Value.ToString(), ddnamhoc.SelectedValue.ToString());

        DataTable dt = hkbus.Searchbymanam(ddnamhoc.SelectedValue.ToString());
        string mahk1 = dt.Rows[0][0].ToString();
        string mahk2 = dt.Rows[1][0].ToString();
        int check = 0;// kiem tra xem nguoi dung da chon bao nhieu nguoi lam lop truong
        foreach (GridViewRow row in gvhocsinh.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("ckchon");
            DropDownList ddlchucvu = (DropDownList)row.FindControl("ddlchucvu");
            string macv ="CV02      ";
            if (cb.Checked == true&&ddlchucvu.SelectedValue.ToString()==macv)
            {
                check++;
            }

        }
        if (check > 1)
        {
            Response.Write("<script>alert('Mỗi lớp chỉ có một lớp trưởng, chọn lại lớp trưởng!')</script>");
        }
        else
        {
            if (check == 1 && checkloptruong.Rows.Count == 1)
            {
                Response.Write("<script>alert('Lớp này đã có lớp trưởng chọn lại lớp trưởng!')</script>");
            }
            else
            {
                foreach (GridViewRow row in gvhocsinh.Rows)
                {
                    CheckBox cb = (CheckBox)row.FindControl("ckchon");
                    Label mahs = (Label)row.FindControl("lblmahs");
                    DropDownList ddlchucvu = (DropDownList)row.FindControl("ddlchucvu");
                    if (cb.Checked == true)
                    {
                        //hocdto.MaHoc = hocbus.getMa();
                        hocdto.MaHS = mahs.Text.ToString();
                        hocdto.MaLop = ddlmalop.SelectedItem.Value.ToString();
                        hocdto.MaCV = ddlchucvu.SelectedItem.Value.ToString();
                        hocdto.MaHK = mahk1;
                        hocdto.HKCuoiKy = "";

                        n = hocbus.Insert(hocdto,ctbd,bd,ddnamhoc.SelectedValue.ToString());
                       // hocdto.MaHoc = hocbus.getMa();
                        hocdto.MaHK = mahk2;
                        n = hocbus.Insert(hocdto, ctbd, bd, ddnamhoc.SelectedValue.ToString());
                    }

                }
                if (n == 1)
                {
                    Response.Write("<script>alert('Đã phân lớp cho các học sinh được chọn')</script>");
                    gvhocsinh.DataSource = hsbus.HSchuaphanlop(ddnamhoc.SelectedItem.Value.ToString());
                    gvhocsinh.DataBind();
                }
            }
        }
       
    }
    protected void gvhocsinh_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvhocsinh.PageIndex = e.NewPageIndex;
        gvhocsinh.DataSource = hsbus.HSchuaphanlop(ddnamhoc.SelectedItem.Value.ToString());
        gvhocsinh.DataBind();
    }
    protected void ckall_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox s = (CheckBox)sender;
        CheckBox ckall = (CheckBox)gvhocsinh.HeaderRow.FindControl("ckall");
        foreach (GridViewRow row in gvhocsinh.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("ckchon");

            if (ckall.Checked == true)
                cb.Checked = true;
            else
                cb.Checked = false;

        }

    }
}
