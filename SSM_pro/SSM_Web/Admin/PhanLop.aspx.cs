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

public partial class Admin_PhanLop : System.Web.UI.Page
{
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
    HocSinh_LenCapBUS hs_lcbus = new HocSinh_LenCapBUS();
    HocSinhBUS hsbus = new HocSinhBUS();
    HocBUS hocbus = new HocBUS();
    //HocDAO.HocDTO hocdto = new HocDAO.HocDTO();
    SSM_Service.HocDTO hocdto = new SSM_Service.HocDTO();
    HocKyBUS hkbus = new HocKyBUS();
    NamHocBUS nhbus = new NamHocBUS();

    SSM_Service.SSM_Services service = new SSM_Service.SSM_Services();
    public DataTable getDatatableLop()
    {
        return sv.Lop_ListbyKhoiLop(drlKhoiLopMoiLL.SelectedValue.ToString());
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            drlNamhoc0.DataTextField = "Năm học";
            drlNamhoc0.DataValueField = "Mã năm";
            drlNamhoc0.DataSource = sv.NamHoc_List();
            drlNamhoc0.DataBind();
            //drlNamhoc0.SelectedIndex = 0;
            

            drlNamHocCuLL.DataTextField = "Năm học";
            drlNamHocCuLL.DataValueField = "Mã năm";
            drlNamHocCuLL.DataSource = sv.NamHoc_List();
            drlNamHocCuLL.DataBind();
         //   drlNamHocTD.SelectedIndex = 1;
            drlNamHocMoiLL.DataTextField = "Năm học";
            drlNamHocMoiLL.DataValueField = "Mã năm";
            drlNamHocMoiLL.DataSource = sv.NamHoc_List();
            drlNamHocMoiLL.DataBind();

            drlKhoiLopCuLL.DataTextField = "Tên khối";
            drlKhoiLopCuLL.DataValueField = "Mã khối";
            drlKhoiLopCuLL.DataSource = sv.KLop_ListByMaNam(drlNamHocCuLL.SelectedValue.ToString());
            drlKhoiLopCuLL.DataBind();
         //   drlKhoiLopCuTD.SelectedIndex = 0;
            drlKhoiLopMoiLL.DataTextField = "Tên khối";
            drlKhoiLopMoiLL.DataValueField = "Mã khối";
            drlKhoiLopMoiLL.DataSource = sv.KLop_ListByMaNam(drlNamHocMoiLL.SelectedValue.ToString());
            drlKhoiLopMoiLL.DataBind();

            //drlNamhoc0.SelectedIndex = sv.NamHoc_List().Rows.Count - 1;
            DataTable dt = hs_lcbus.ListHocSinh_LenCap();
            grdvHSLencap.DataSource = AutoNumberedTable(dt);
            grdvHSLencap.DataBind();

            DataTable dtHSCu = sv.HocSinh_listHSDuocLenLop(drlKhoiLopCuLL.SelectedValue.ToString());
            grdvHSCu_TuDong.DataSource = AutoNumberedTable(dtHSCu);
            grdvHSCu_TuDong.DataBind();

            grdvHSCuThuCong.DataSource = AutoNumberedTable(dtHSCu);
            grdvHSCuThuCong.DataBind();

            DataTable dtHSLuuBan = sv.HocSinh_listHSLuBan(drlKhoiLopCuLL.SelectedValue.ToString());
            grdvHSCuLuuBan.DataSource = AutoNumberedTable(dtHSLuuBan);
            grdvHSCuLuuBan.DataBind();

            //grdvHSLencap.DataSource = AutoNumberedTable(dt);
            //grdvHSLencap.DataBind();
        }
      //  if (!IsPostBack)
      //  {
            if (rdlistHSLC.SelectedValue.Equals("HS Lên Cấp"))
            {
                pnlHeadHSLB.Visible = false;
                pnlHeadKPL.Visible = false;

                pnlHSMoilencap.Visible = true;
                pnlHSDuoclenlop.Visible = false;
                pnlHSLuuban.Visible = false;
                pnlHSMoilencap_Load(sender, e);

            }
            if (rdlistHSLC.SelectedValue.Equals("HS Cũ"))
            {
                pnlHeadHSLB.Visible = true;
                pnlHeadKPL.Visible = false;

                pnlHSDuoclenlop.Visible = false;
                pnlHSLuuban.Visible = false;
                pnlHSMoilencap.Visible = false;
                if (rdlistLB.SelectedValue.Equals("HS Được Lên Lớp"))
                {
                    pnlHeadKPL.Visible = true;

                    pnlHSDuoclenlop.Visible = true;
                    if (rdlistKPL.SelectedValue.Equals("Tự Động"))
                    {
                        pnlTudong.Visible = true;
                        pnlThucong.Visible = false;
                    }
                    if (rdlistKPL.SelectedValue.Equals("Thủ Công"))
                    {
                        pnlTudong.Visible = false;
                        pnlThucong.Visible = true;
                    }
                }
                if (rdlistLB.SelectedValue.Equals("HS Lưu Ban"))
                {
                    pnlHSLuuban.Visible = true;
                }

            }
     //   }
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

    protected void pnlHSMoilencap_Load(object sender, EventArgs e)
    {

        
    }
    protected void grdvHSLencap_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdvHSLencap_Load(object sender, EventArgs e)
    {
       
    }
    protected void btPhanLopTD_Click(object sender, EventArgs e)
    {
        int n = sv.HocSinh_LenCap_PhanLopTuDong(drlNamhoc0.SelectedValue.ToString(), sv.KLop_getMaKLbyMaNam(drlNamhoc0.SelectedValue.ToString()));
        if (n == 1)
        {
            Response.Write("<script>alert('Phân lớp thành công')</script>");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void rdlistHSLC_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void drlNamHocTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        drlKhoiLopCuLL.DataTextField = "Tên khối";
        drlKhoiLopCuLL.DataValueField = "Mã khối";
        drlKhoiLopCuLL.DataSource = sv.KLop_ListByMaNam(drlNamHocCuLL.SelectedValue.ToString());
        drlKhoiLopCuLL.DataBind();

        DataTable dtHSCu = sv.HocSinh_listHSDuocLenLop(drlKhoiLopCuLL.SelectedValue.ToString());
        grdvHSCu_TuDong.DataSource = AutoNumberedTable(dtHSCu);
        grdvHSCu_TuDong.DataBind();
        grdvHSCuThuCong.DataSource = AutoNumberedTable(dtHSCu);
        grdvHSCuThuCong.DataBind();
    }
    protected void drlKhoiLopCuTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtHSCu = sv.HocSinh_listHSDuocLenLop(drlKhoiLopCuLL.SelectedValue.ToString());
        grdvHSCu_TuDong.DataSource = AutoNumberedTable(dtHSCu);
        grdvHSCu_TuDong.DataBind();
        grdvHSCuThuCong.DataSource = AutoNumberedTable(dtHSCu);
        grdvHSCuThuCong.DataBind();
    }
    protected void drlNamHocMoiLL_SelectedIndexChanged(object sender, EventArgs e)
    {
        drlKhoiLopMoiLL.DataTextField = "Tên khối";
        drlKhoiLopMoiLL.DataValueField = "Mã khối";
        drlKhoiLopMoiLL.DataSource = sv.KLop_ListByMaNam(drlNamHocMoiLL.SelectedValue.ToString());
        drlKhoiLopMoiLL.DataBind();
    }
    protected void drlKhoiLopMoiLL_selectchange(object sender, EventArgs e)
    {
       // getDatatableLop();
    }
}
