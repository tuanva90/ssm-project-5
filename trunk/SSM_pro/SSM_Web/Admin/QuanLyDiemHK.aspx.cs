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


public partial class Admin_QuanLyDiemHK : System.Web.UI.Page
{
  
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
    SSM_Service.CT_BDM_HKDTO ctbdmhkdto = new SSM_Service.CT_BDM_HKDTO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ddnamhoc.DataSource = sv.NamHoc_List();
                ddnamhoc.DataBind();
                ddlhk.DataSource = sv.HocKy_searchbyMaNam(ddnamhoc.SelectedValue.ToString());
                ddlhk.DataBind();
                // ddllop.DataSource = sv.Lop_List();
                ddllop.DataSource = sv.Lop_ListbyNamHoc(ddnamhoc.SelectedValue.ToString());
                ddllop.DataBind();
                ddlmonhoc.DataSource = sv.CT_KL_MH_List_MH_KL(ddnamhoc.SelectedValue.ToString(), sv.Lop_SearchMakl(ddllop.SelectedValue.ToString(), ddnamhoc.SelectedValue.ToString()));
                ddlmonhoc.DataBind();
                gvhocsinh.DataSource = AutoNumberedTable(sv.CT_BDM_HK_List(ddlhk.SelectedValue.ToString(), ddllop.SelectedValue.ToString(), ddlmonhoc.SelectedValue.ToString()));
                gvhocsinh.DataBind();
                Display();
            }
            catch
            {
                lblinfor.Text = " Không có kết quả nào tương ứng !";
            }
        }
    }
    private DataTable AutoNumberedTable(DataTable SourceTable)
    {

        DataTable ResultTable = new DataTable();
        DataColumn AutoNumberColumn = new DataColumn(); AutoNumberColumn.ColumnName = "STT";

        AutoNumberColumn.DataType = typeof(int);
        AutoNumberColumn.AutoIncrement = true;

        AutoNumberColumn.AutoIncrementSeed = 1;

        AutoNumberColumn.AutoIncrementStep = 1;

        ResultTable.Columns.Add(AutoNumberColumn);

        ResultTable.Merge(SourceTable);
        return ResultTable;

    }  
    public void Display()
    {
        int mahoc;
        int mactklmh;
        foreach (GridViewRow gvr in gvhocsinh.Rows)
        {
            Label mahs = (Label)gvr.FindControl("lblmahs");
            TextBox diemhk = (TextBox)gvr.FindControl("txtdiemhk");
            mahoc = int.Parse(sv.Hoc_GetMaHoc(mahs.Text.ToString(), ddllop.SelectedValue.ToString(), ddlhk.SelectedValue.ToString()));
            mactklmh = sv.CT_KL_MH_GetMaCTKLMH(ddlmonhoc.SelectedValue.ToString(), ddnamhoc.SelectedValue.ToString(), sv.Lop_SearchMakl(ddllop.SelectedValue.ToString(), ddnamhoc.SelectedValue.ToString())); 
            Label diemtbkt = (Label)gvr.FindControl("lbldiemtbkt");
            Label diemtbhk = (Label)gvr.FindControl("lbldiemtb");
            diemtbhk.Text = sv.BDM_HK_getDiemTBM_HK(mahoc, mactklmh).ToString();
            diemtbkt.Text = sv.BDM_HK_getDiemTBM_KT(mahoc, mactklmh).ToString();
        }
    }
    protected void gvhocsinh_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddnamhoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlhk.DataSource = sv.HocKy_searchbyMaNam(ddnamhoc.SelectedValue.ToString());
        ddlhk.DataBind();
      }
    protected void ddlhk_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvhocsinh.DataSource = sv.CT_BDM_HK_List(ddlhk.SelectedValue.ToString(), ddllop.SelectedValue.ToString(), ddlmonhoc.SelectedValue.ToString());
        gvhocsinh.DataBind();
        Display();
    }
    protected void ddllop_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvhocsinh.DataSource = sv.CT_BDM_HK_List(ddlhk.SelectedValue.ToString(), ddllop.SelectedValue.ToString(), ddlmonhoc.SelectedValue.ToString());
        gvhocsinh.DataBind();
        Display();
    }
    protected void ddlmonhoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvhocsinh.DataSource = sv.CT_BDM_HK_List(ddlhk.SelectedValue.ToString(), ddllop.SelectedValue.ToString(), ddlmonhoc.SelectedValue.ToString());
        gvhocsinh.DataBind();
        Display();
    }
    public void VisibleDiemTBKTcolumn()
    {
        foreach (GridViewRow gvr in gvhocsinh.Rows)
        {

            Label diemtbkt = (Label)gvr.FindControl("lbldiemtbkt");
            diemtbkt.Visible = false;           
        }
    }
    int mahoc;
    int mactklmh;
    protected void btnluudiem_Click(object sender, EventArgs e)
    {
        
        int n=0;
        int check = 0;
        foreach (GridViewRow gvr in gvhocsinh.Rows)
        {
           
            TextBox diem15p = (TextBox)gvr.FindControl("txtdiem15p");
            TextBox diemmieng = (TextBox)gvr.FindControl("txtdiemmieng");
            TextBox diem1tiet = (TextBox)gvr.FindControl("txtdiem1tiet");
            Label mahs = (Label)gvr.FindControl("lblmahs");
            TextBox diemhk = (TextBox)gvr.FindControl("txtdiemhk");
             mahoc = int.Parse(sv.Hoc_GetMaHoc(mahs.Text.ToString(),ddllop.SelectedValue.ToString(),ddlhk.SelectedValue.ToString()));
            mactklmh = sv.CT_KL_MH_GetMaCTKLMH(ddlmonhoc.SelectedValue.ToString(),ddnamhoc.SelectedValue.ToString(),sv.Lop_SearchMakl(ddllop.SelectedValue.ToString(),ddnamhoc.SelectedValue.ToString())); 
            ctbdmhkdto.MaBD_HK = sv.BDM_HK_GetMaBDMHK(mahoc,mactklmh);
            ctbdmhkdto.Diem15Phut = diem15p.Text.ToString();
            ctbdmhkdto.DiemMieng = diemmieng.Text.ToString();
            ctbdmhkdto.Diem1Tiet = diem1tiet.Text.ToString();
            ctbdmhkdto.DiemHK = diemhk.Text.ToString();
            n += sv.CT_BDM_HK_Update(ctbdmhkdto);
            check++;
        }
        if(n==check)
            Response.Write("<script>alert('Lưu điểm thành công!')</script>");
    }
    float _diem15p;
    float _diem1tiet;
    float _diemmieng;
    float _diemhk;
    public void TinhdiemTBLT()
    {
        foreach (GridViewRow gvr in gvhocsinh.Rows)
        {
            _diemhk = 0;
            Label mahs = (Label)gvr.FindControl("lblmahs");
            mahoc = int.Parse(sv.Hoc_GetMaHoc(mahs.Text.ToString(), ddllop.SelectedValue.ToString(), ddlhk.SelectedValue.ToString()));
            mactklmh = sv.CT_KL_MH_GetMaCTKLMH(ddlmonhoc.SelectedValue.ToString(), ddnamhoc.SelectedValue.ToString(), sv.Lop_SearchMakl(ddllop.SelectedValue.ToString(), ddnamhoc.SelectedValue.ToString()));
            TextBox diemhk = (TextBox)gvr.FindControl("txtdiemhk");
            Label diemtbkt = (Label)gvr.FindControl("lbldiemtbkt");
            mahoc = int.Parse(sv.Hoc_GetMaHoc(mahs.Text.ToString(), ddllop.SelectedValue.ToString(), ddlhk.SelectedValue.ToString()));
            
            ctbdmhkdto.DiemHK = diemhk.Text.ToString();
            int m = sv.CT_KL_HK_UpdateDiemHK(mahoc, mactklmh, float.Parse(diemhk.Text.ToString()));
            float diemtb = (float)(Math.Round((float.Parse(diemhk.Text.ToString())*2 + float.Parse(diemtbkt.Text.ToString()))/ 3, 1));
            int n = sv.BDM_HK_UpdateDiemTB(mahoc, mactklmh, diemtb);
        }
    }
    public void TinhdiemTBMhk()
    {
      
        int count ;//dem so con diem
        float diemtbkt;
        foreach (GridViewRow gvr in gvhocsinh.Rows)
        {
            _diem15p = 0;
            _diem1tiet = 0;
            _diemmieng = 0;
            _diemhk = 0;
            count = 0;
            Label mahs = (Label)gvr.FindControl("lblmahs");
            mahoc = int.Parse(sv.Hoc_GetMaHoc(mahs.Text.ToString(), ddllop.SelectedValue.ToString(), ddlhk.SelectedValue.ToString()));
            mactklmh = sv.CT_KL_MH_GetMaCTKLMH(ddlmonhoc.SelectedValue.ToString(), ddnamhoc.SelectedValue.ToString(), sv.Lop_SearchMakl(ddllop.SelectedValue.ToString(), ddnamhoc.SelectedValue.ToString()));
            TextBox diem15p = (TextBox)gvr.FindControl("txtdiem15p");
            TextBox diemmieng = (TextBox)gvr.FindControl("txtdiemmieng");
            TextBox diem1tiet = (TextBox)gvr.FindControl("txtdiem1tiet");
            TextBox diemhk = (TextBox)gvr.FindControl("txtdiemhk");
            mahoc = int.Parse(sv.Hoc_GetMaHoc(mahs.Text.ToString(), ddllop.SelectedValue.ToString(), ddlhk.SelectedValue.ToString()));
            foreach (string d15p in diem15p.Text.Split(' '))
            {
                if (d15p.Length > 0)
                {
                    _diem15p += float.Parse(d15p.ToString());
                    count++;
                }
            }
            foreach (string dm in diemmieng.Text.Split(' '))
            {
                if (dm.Length > 0)
                {
                    _diemmieng += float.Parse(dm.ToString());
                    count++;
                }
            }
            foreach (string d1t in diem1tiet.Text.Split(' '))
            {
                if (d1t.Length > 0)
                {
                    _diem1tiet += float.Parse(d1t.ToString()) * 2;
                    count += 2;// diem 1tiet he so 2
                }
            }
                 float diem = (float)(Math.Round((_diem1tiet + _diem15p + _diemmieng ) / count, 1));
                 diemtbkt = diem;
                 int n = sv.BDM_HK_UpdateDiemTBM_KT(mahoc, mactklmh, diemtbkt);
           
        }
             
    }
    protected void lbldiemtb_Click(object sender, EventArgs e)
    {
        TinhdiemTBLT();
        gvhocsinh.DataSource = sv.CT_BDM_HK_List(ddlhk.SelectedValue.ToString(), ddllop.SelectedValue.ToString(), ddlmonhoc.SelectedValue.ToString());
        gvhocsinh.DataBind();
        Display();
    }
    protected void lbtntinhdiemtbkt_Click(object sender, EventArgs e)
    {
         TinhdiemTBMhk();
        gvhocsinh.DataSource = sv.CT_BDM_HK_List(ddlhk.SelectedValue.ToString(), ddllop.SelectedValue.ToString(), ddlmonhoc.SelectedValue.ToString());
        gvhocsinh.DataBind();
        Display();
    }
}
