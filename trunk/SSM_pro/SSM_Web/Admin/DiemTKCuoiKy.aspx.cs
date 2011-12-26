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

public partial class Admin_DiemTKCuoiKy : System.Web.UI.Page
{
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string tenhk = "I";
            try
            {
                ddnamhoc.DataSource = sv.NamHoc_List();
                ddnamhoc.DataBind();
                ddllop.DataSource = sv.Lop_ListbyNamHoc(ddnamhoc.SelectedValue.ToString());
                ddllop.DataBind();
                gvtkdiem.DataSource = sv.Hoc_getDCK_HKCK(ddnamhoc.SelectedValue.ToString(), tenhk, ddllop.SelectedValue.ToString());
                gvtkdiem.DataBind();
                Display();
            }
            catch
            {
                      lblinfor.Text = " Không tìm thấy kết quả nào !";
               }
        } 
    }
    public void Display()
    {
        string tenhk = "I";
        string tenhk2 = "II";
       foreach (GridViewRow grv in gvtkdiem.Rows)
        {
            Label mahs = (Label)grv.FindControl("lblmahs");
            Label diemck1 = (Label)grv.FindControl("lbldiemck1");
            Label diemck2 = (Label)grv.FindControl("lbldiemck2");
            TextBox hkck2 = (TextBox)grv.FindControl("txthkck2");
            Label diemcuoinam = (Label)grv.FindControl("lbldiemcuoinam");
            TextBox hkcuoinam = (TextBox)grv.FindControl("txthkcuoinam");
            if (sv.Hoc_GetMaHoc(mahs.Text.ToString(), ddllop.SelectedValue.ToString(), sv.HocKy_GetMaHK(ddnamhoc.SelectedValue.ToString(), tenhk2)) != "NULL")
            {
                diemck1.Text = sv.Hoc_getDiemCK(mahs.Text.ToString(), ddllop.SelectedValue.ToString(), ddnamhoc.SelectedValue.ToString(), tenhk).ToString();
                diemck2.Text = sv.Hoc_getDiemCK(mahs.Text.ToString(), ddllop.SelectedValue.ToString(), ddnamhoc.SelectedValue.ToString(), tenhk2).ToString();
                hkck2.Text = sv.Hoc_getHKCuoiKy(mahs.Text.ToString(), ddllop.SelectedValue.ToString(), ddnamhoc.SelectedValue.ToString(), tenhk2).ToString();
            }            
             if( sv.TKNam_GetMaBTKN(ddnamhoc.SelectedValue.ToString(), mahs.Text.ToString()) != 0)
             {
                 diemcuoinam.Text = sv.TKN_get_DiemCuoiNam(ddnamhoc.SelectedValue.ToString(), mahs.Text.ToString().ToString()).ToString();
                 hkcuoinam.Text=sv.TKN_get_HKCuoiNam(ddnamhoc.SelectedValue.ToString(),mahs.Text.ToString()).ToString();
             }
           
        }

    }
    public void TinhDiemCuoiKy(string tenhk)
    {
        float _diem;
        int _heso;
        foreach (GridViewRow grv in gvtkdiem.Rows)
        {
            _diem = 0;
            _heso = 0;
             Label mahs = (Label)grv.FindControl("lblmahs");
             DataTable dt = sv.BDM_HK_getDiemCacMon(ddnamhoc.SelectedValue.ToString(), tenhk, sv.Lop_SearchMakl(ddllop.SelectedValue.ToString(), ddnamhoc.SelectedValue.ToString()), mahs.Text.ToString());
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 _diem += float.Parse(dt.Rows[i]["DTBMon_HK"].ToString()) * int.Parse(dt.Rows[i]["HeSo"].ToString());
                 _heso += int.Parse(dt.Rows[i]["HeSo"].ToString());
             }
             float diemcuoiky = (float)Math.Round(_diem / _heso, 1);
             int n = sv.Hoc_UpdateDiemCK(diemcuoiky, sv.Hoc_GetMaHoc(mahs.Text.ToString(), ddllop.SelectedValue.ToString(), sv.HocKy_GetMaHK(ddnamhoc.SelectedValue.ToString(), tenhk)));
        }
    }
    public void LuuHKCKI()
    {
        string tenhk = "I";
        int n = 0;
        foreach (GridViewRow grv in gvtkdiem.Rows)
        {
            Label mahs = (Label)grv.FindControl("lblmahs");
            TextBox hkck2 = (TextBox)grv.FindControl("txthkck1");
            string ss = hkck2.Text;
             n += sv.Hoc_UpdateHKCK(hkck2.Text.ToString(), sv.Hoc_GetMaHoc(mahs.Text.ToString(), ddllop.SelectedValue.ToString(), sv.HocKy_GetMaHK(ddnamhoc.SelectedValue.ToString(), tenhk)));
        }
        if(n==gvtkdiem.Rows.Count)
            Response.Write("<script>alert('Lưu hạnh kiểm học kì I thành công!')</script>");
        else
            Response.Write("<script>alert('Lưu hạnh kiểm học kì I thất bại')</script>");
    }
    public void LuuHKCKII()
    {
        string tenhk = "II";
        int n = 0;
        foreach (GridViewRow grv in gvtkdiem.Rows)
        {
            Label mahs = (Label)grv.FindControl("lblmahs");
            TextBox hkck2 = (TextBox)grv.FindControl("txthkck2");
            n += sv.Hoc_UpdateHKCK(hkck2.Text.ToString(), sv.Hoc_GetMaHoc(mahs.Text.ToString(), ddllop.SelectedValue.ToString(), sv.HocKy_GetMaHK(ddnamhoc.SelectedValue.ToString(), tenhk)));
        }
        if (n == gvtkdiem.Rows.Count)
            Response.Write("<script>alert('Lưu hạnh kiểm học kì II thành công!')</script>");
        else
            Response.Write("<script>alert('Lưu hạnh kiểm học kì II thất bại')</script>");
    }

    protected void gvtkdiem_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lbtnluuhkk1_Click(object sender, EventArgs e)
    {
        LuuHKCKI();
        string tenhk = "I";
        gvtkdiem.DataSource = sv.Hoc_getDCK_HKCK(ddnamhoc.SelectedValue.ToString(), tenhk, ddllop.SelectedValue.ToString());
        gvtkdiem.DataBind();
        Display();
    }
    protected void lbtnluuhkcuoinam_Click(object sender, EventArgs e)
    {
        int n = 0;
        foreach (GridViewRow grv in gvtkdiem.Rows)
        {
            Label mahs = (Label)grv.FindControl("lblmahs");
            TextBox hkcuoinam = (TextBox)grv.FindControl("txthkcuoinam");
            if (sv.TKNam_GetMaBTKN(ddnamhoc.SelectedValue.ToString(), mahs.Text.ToString()) == 0)
            {
                SSM_Service.TKNAMDTO tkn = new SSM_Service.TKNAMDTO();
                tkn.MaHS = mahs.Text.ToString();
                tkn.MaNam = ddnamhoc.SelectedValue.ToString();
                tkn.HKCuoiNam = "";
                tkn.DiemCuoiNam = 0;
                n += sv.TKNam_Insert(tkn);
            }
            else
            {
                n += sv.TKNam_UpdateHKCuoiNam(ddnamhoc.SelectedValue.ToString(), mahs.Text.ToString(), hkcuoinam.Text.ToString());
            }
        }
        if(n==gvtkdiem.Rows.Count)
            Response.Write("<script>alert('Lưu hạnh kiểm cuối năm thành công!')</script>");
        else
            Response.Write("<script>alert('Lưu hạnh kiểm cuối năm thất bại!')</script>");

    }
    protected void btnluuhkk2_Click(object sender, EventArgs e)
    {
        string tenhk = "I";
        LuuHKCKII();
        gvtkdiem.DataSource = sv.Hoc_getDCK_HKCK(ddnamhoc.SelectedValue.ToString(), tenhk, ddllop.SelectedValue.ToString());
        gvtkdiem.DataBind();
        Display();
    }
    protected void ddnamhoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        string tenhk = "I";
        ddllop.DataSource = sv.Lop_ListbyNamHoc(ddnamhoc.SelectedValue.ToString());
        ddllop.DataBind();
        gvtkdiem.DataSource = sv.Hoc_getDCK_HKCK(ddnamhoc.SelectedValue.ToString(), tenhk, ddllop.SelectedValue.ToString());
        gvtkdiem.DataBind();
        Display();
    }

    protected void ddllop_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string tenhk = "I";
            gvtkdiem.DataSource = sv.Hoc_getDCK_HKCK(ddnamhoc.SelectedValue.ToString(), tenhk, ddllop.SelectedValue.ToString());
            gvtkdiem.DataBind();
            Display();
        }
        catch
        {
            lblinfor.Text = " Không tìm thấy kết quả nào !";
        }
    }
    protected void lbtntinhdiemck2_Click(object sender, EventArgs e)
    {
        string tenhk1 = "II";
        TinhDiemCuoiKy(tenhk1);
        string tenhk = "I";
        gvtkdiem.DataSource = sv.Hoc_getDCK_HKCK(ddnamhoc.SelectedValue.ToString(), tenhk, ddllop.SelectedValue.ToString());
        gvtkdiem.DataBind();
        Display();

    }
    protected void lbtntinhdiemck1_Click(object sender, EventArgs e)
    {
        string tenhk = "I";
        TinhDiemCuoiKy(tenhk);
        gvtkdiem.DataSource = sv.Hoc_getDCK_HKCK(ddnamhoc.SelectedValue.ToString(), tenhk, ddllop.SelectedValue.ToString());
        gvtkdiem.DataBind();
        Display();

    }
    protected void gvtkdiem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string tenhk = "I";
        gvtkdiem.PageIndex = e.NewPageIndex;
        gvtkdiem.DataSource = sv.Hoc_getDCK_HKCK(ddnamhoc.SelectedValue.ToString(), tenhk, ddllop.SelectedValue.ToString());
        gvtkdiem.DataBind();
        Display();
    }
    protected void lbltinhdiemcuoinam_Click(object sender, EventArgs e)
    {
        int n = 0;
        foreach (GridViewRow grv in gvtkdiem.Rows)
        {
            Label mahs = (Label)grv.FindControl("lblmahs");
            Label diemck1 = (Label)grv.FindControl("lbldiemck1");
            Label diemck2 = (Label)grv.FindControl("lbldiemck2");
                 Label diemcn = (Label)grv.FindControl("lbldiemck2");
            float diemcuoinam = (float)Math.Round((float.Parse(diemck2.Text.ToString()) * 2 + float.Parse(diemck1.Text.ToString())) / 3, 1);
            if (sv.TKNam_GetMaBTKN(ddnamhoc.SelectedValue.ToString(), mahs.Text.ToString()) == 0)
            {
                SSM_Service.TKNAMDTO tkn = new SSM_Service.TKNAMDTO();
                tkn.MaHS = mahs.Text.ToString();
                tkn.MaNam = ddnamhoc.SelectedValue.ToString();
                tkn.HKCuoiNam = "";
                tkn.DiemCuoiNam = diemcuoinam;
                n += sv.TKNam_Insert(tkn);
            }
            else
            {
                n += sv.TKNam_UpdateDiemCuoiNam(ddnamhoc.SelectedValue.ToString(), mahs.Text.ToString(), diemcuoinam);
                diemcn.Text = sv.TKN_get_DiemCuoiNam(ddnamhoc.SelectedValue.ToString(), mahs.Text.ToString()).ToString();
            }

        }
         string tenhk = "I";
        gvtkdiem.DataSource = sv.Hoc_getDCK_HKCK(ddnamhoc.SelectedValue.ToString(), tenhk, ddllop.SelectedValue.ToString());
        gvtkdiem.DataBind();
        Display();
     }
}
