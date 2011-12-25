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

/// <summary>
/// Summary description for HocBUS
/// </summary>
public class HocBUS
{

    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
    BDM_HKBUS bdmhkbus = new BDM_HKBUS();
    public HocBUS()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string getMaHoc(string mahs, string malop, string mahk)
    {
        return sv.Hoc_GetMaHoc(mahs, malop, mahk);
    }
    public int Insert(SSM_Service.HocDTO hoc, SSM_Service.CT_BDM_HKDTO ctbd, SSM_Service.BDM_HKDTO bd, string manam) // them mot bang hoc thi them luon bang bdm_hk va ct_bdm_hk
    {
        int n = 0;

        string makhoi = sv.Lop_SearchMakl(hoc.MaLop);
        DataTable dt = sv.CT_KL_MH_List_MH_KL(manam, makhoi);
        if (dt.Rows.Count == 0)
        {
            return 0;
            //Response.Write("<script>alert('Chưa phân môn cho các khối lớp, vui lòng thực hiện thao tác phân môn cho khối lớp trước!')</script>");
        }
        else
        {
            n = sv.Hoc_Insert(hoc);
            bd.MaHoc = int.Parse(getMaHoc(hoc.MaHS, hoc.MaLop, hoc.MaHK));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bd.CT_KLMH = int.Parse(dt.Rows[i][0].ToString());
                n = bdmhkbus.Insert(bd, ctbd);
            }
            return n;
        }
    }

    public DataTable Checkloptruong(string malop, string manam)
    {
        return sv.Hoc_Checkloptruong(malop, manam);
    }
}
