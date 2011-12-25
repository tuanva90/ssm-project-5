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

public partial class Admin_QLHocSinh : System.Web.UI.Page
{
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    HocSinhBUS hsbus = new HocSinhBUS();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             txtmahs.Text = "08";
            lblmahs.Text = hsbus.getMaHS(txtmahs.Text.ToString()).ToString();
            }

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
  
    private void InitializeComponent()
    {
        this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();

    }
  
     
    protected void btnluuthongtin_Click(object sender, EventArgs e)
    {
        //HocSinhDAO.HocSinhDTO hsdto = new HocSinhDAO.HocSinhDTO();
        SSM_Service.HocSinhDTO hsdto = new SSM_Service.HocSinhDTO();
        hsdto.MaHS = txtmahs.Text.ToString() + lblmahs.Text.ToString();
        hsdto.HoTen = txthoten.Text.ToString();
        if (ckbgioitinh.Checked == true)
        {
            hsdto.GioiTinh = 1;
        }
        else
            hsdto.GioiTinh = 0;
        hsdto.SoDienThoai = txtsodienthoai.Text.ToString();
        hsdto.HoTenCha = txthotencha.Text.ToString();
        hsdto.NgheNghiepCha = txthotencha.Text.ToString();
        hsdto.HoTenMe = txthotenme.Text.ToString();
        hsdto.NgheNghiepMe = txtnghenghiepme.Text.ToString();
        hsdto.DiaChi = txtdiachi.Text.ToString();
        hsdto.NgaySinh = txtDate.Text;
        //HocSinhBUS hsbus = new HocSinhBUS();
        int result = hsbus.Insert(hsdto);
        if (result > 0)
        {
            Response.Write("<script>alert('Insert " + " successful !')</script>");
        }
        else
        {
            Response.Write("<script>alert('Insert " + "dfa !')</script>");
        }
        Response.Redirect("ThemHocSinh.aspx");
    }
    protected void btnhuy_Click(object sender, EventArgs e)
    {

    }

    protected void txtmahs_TextChanged1(object sender, EventArgs e)
    {
       
        lblmahs.Text = hsbus.getMaHS(txtmahs.Text.ToString()).ToString();
    }
}
