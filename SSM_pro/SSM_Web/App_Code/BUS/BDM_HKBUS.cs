using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for BDM_HKBUS
/// </summary>
public class BDM_HKBUS
{
    SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
	public BDM_HKBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Insert(SSM_Service.BDM_HKDTO bd,SSM_Service.CT_BDM_HKDTO ctbd)
    {
        int n = 0;
        n=sv.BDM_HK_Insert(bd);
        ctbd.MaBD_HK = GetMaBDMHK(bd.MaHoc,bd.CT_KLMH);
        ctbd.Diem15Phut = "";
        ctbd.Diem1Tiet = "";
       ctbd.DiemMieng = "";
        ctbd.DiemHK = "";
        n = sv.CT_BDM_HK_Insert(ctbd);
        return n;

    }
    public int Insert1(string manam, string mamon, string makl) //khi tao mot bang CT_KL_MH moi thi pai tao bang BDM_Hk cho tat cac cac bang hoc co MaKhoi=makk, MaNam=manam
    {
        SSM_Service.BDM_HKDTO bd= new SSM_Service.BDM_HKDTO();
        SSM_Service.CT_BDM_HKDTO ctbd = new SSM_Service.CT_BDM_HKDTO();
        int n = 0;
        //n=sv.CT_KL_Mon_Insert(mamon, sv.KhoiLop_Mon_GetMa(manam, makl));
        bd.CT_KLMH = sv.CT_KL_MH_GetMaCTKLMH(mamon, manam, makl);
       
            DataTable dt = sv.Hoc_GetMaHoc_manam_makl(manam, makl);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bd.MaHoc = int.Parse(dt.Rows[i][0].ToString());
                n = Insert(bd, ctbd);
            }
            return n;   
              
    }
    public int UpdateDiemTB(int mahoc, int ctklmh, float diem)
    {
        return sv.BDM_HK_UpdateDiemTB(mahoc, ctklmh, diem);
    }
    public int Delete(int mahoc, int ctklmh)
    {
        return sv.BDM_HK_Delete(mahoc, ctklmh);
    }
    public DataTable List()
    {
        return sv.BDM_HK_List();
    }
    public int GetMaBDMHK(int hoc, int ctklmh)
    {
        return sv.BDM_HK_GetMaBDMHK(hoc, ctklmh);
    }
    string[] diem;
    public DataTable List_DiemCacMon(string malop,string manam, string mahk)// lay danh sach diem cuoi ki cac mon cua mot hoc sinh 
    {
        DataTable dt = new DataTable();
        
        dt.Columns.Add("Mã HS");
        dt.Columns.Add("Họ tên");
        DataTable monhoc = sv.CT_KL_MH_List_MH_KL(manam, sv.Lop_SearchMakl(malop,manam));
        DataTable hocsinh = sv.Hoc_getListHS_Lop(mahk, malop);
        for (int i = 0; i < monhoc.Rows.Count; i++)
        {
            dt.Columns.Add(monhoc.Rows[i]["Tên môn"].ToString());
        }
        dt.Columns.Add("Điểm TBM");
        int lengh = 0;
        if (hocsinh.Rows.Count > 0)
        {
            for (int j = 0; j < hocsinh.Rows.Count; j++)
            {
                lengh = 0;
                Array.Resize(ref diem, lengh + 1);
                diem[lengh] = hocsinh.Rows[j]["Mã HS"].ToString();
                lengh++;
                Array.Resize(ref diem, lengh + 1);
                diem[lengh] = hocsinh.Rows[j]["Họ tên"].ToString();
                lengh++;
                for (int i = 0; i < monhoc.Rows.Count; i++)
                {
                    Array.Resize(ref diem, lengh + 1);
                    diem[lengh] = ((float)Math.Round(sv.BDM_HK_getDiemTBM_HK(int.Parse(sv.Hoc_GetMaHoc(hocsinh.Rows[j]["Mã HS"].ToString(), malop, mahk).ToString()), sv.CT_KL_MH_GetMaCTKLMH(monhoc.Rows[i]["Mã môn"].ToString(), manam, sv.Lop_SearchMakl(malop,manam).ToString())),1)).ToString();
                    lengh++;
                }
                if (int.Parse(mahk.Substring(3, 2).ToString()) % 2 != 0) // hk1 thi mahk la le, hocky 2 thi mahk lachan(mac dinh la vay vi hoc cu them mot nam hoc thi lai them 2 hoc ki) ( vi ham hoc_getdiemck co tham so truyen vao la ten hocky nen pai phan tich ra vay)
                {
                    Array.Resize(ref diem, lengh + 1);
                    diem[lengh] = ((float)Math.Round(sv.Hoc_getDiemCK(hocsinh.Rows[j]["Mã HS"].ToString(), malop, manam, "I"), 1)).ToString();
                    lengh++;
                }
                else
                {
                    Array.Resize(ref diem, lengh + 1);
                    diem[lengh] = ((float)Math.Round(sv.Hoc_getDiemCK(hocsinh.Rows[j]["Mã HS"].ToString(), malop, manam, "II"),1)).ToString();
                    lengh++;
                }
                dt.Rows.Add(diem);
            }
        }
        return dt;
    }
    public DataTable HS_TKHocKy(string mahs, string manam, string mahk) // lay bang tong ket ( diem cac mon, hanh kiem ) cua mot hoc sinh theo tung hoc kỳ...
    {
        int lengh;
        string malop = sv.Hoc_getMaLop(mahs, mahk);
        DataTable result = new DataTable();
        if (sv.Hoc_GetMaHoc(mahs, malop, mahk).ToString() != "NULL") // kiem tra xem hco sinh da hoc trong nam hoc nay chua, neu chua k co thong tin gì
        {
            DataTable monhoc = sv.CT_KL_MH_List_MH_KL(manam, sv.Lop_SearchMakl(malop,manam));
            result.Columns.Add("Môn học");
            string hk;// hanh kiem

            if (int.Parse(mahk.Substring(3, 2).ToString()) % 2 != 0)// là hk1
            {
                result.Columns.Add("Điểm hk I");
                hk = sv.Hoc_getHKCuoiKy(mahs, malop, manam, "I").ToString();
            }
            else
            {
                result.Columns.Add("Điểm hk II");
                hk = sv.Hoc_getHKCuoiKy(mahs, malop, manam, "II").ToString();
            }
            for (int i = 0; i < monhoc.Rows.Count; i++)
            {
                lengh = 0;
                Array.Resize(ref diem, lengh + 1);
                diem[lengh] = monhoc.Rows[i]["Tên môn"].ToString();
                lengh++;
                
                Array.Resize(ref diem, lengh + 1);
                diem[lengh] = ((float)Math.Round(sv.BDM_HK_getDiemTBM_HK(int.Parse(sv.Hoc_GetMaHoc(mahs, malop, mahk).ToString()), sv.CT_KL_MH_GetMaCTKLMH(monhoc.Rows[i]["Mã môn"].ToString(), manam, sv.Lop_SearchMakl(malop,manam).ToString())), 1)).ToString();
                lengh++;
          
                result.Rows.Add(diem);
            }
        }
        return result;
    }
    public DataTable HS_TKNam(string mahs, string manam) // lay bang tong ket ca nam hoc cua mot hoc sinh (diem hk1,2 hk hk1,2)
    {
        int lengh;
        string mahk =  sv.HocKy_GetMaHK(manam, "I"); // co the 2 hoc ki mot hoc sinh hoc 2 lop khac nhau, pai xu ly truong hop hay
        string malop = sv.Hoc_getMaLop(mahs, mahk);
        mahk = sv.HocKy_GetMaHK(manam, "II");
        string malop1 = sv.Hoc_getMaLop(mahs, mahk);
        string hk1;//hanh kiem k1
        string hk2;
        string hkcn;// hanh kiem ca nam
        DataTable result = new DataTable();
        if (sv.Hoc_GetMaHoc(mahs, malop, mahk).ToString() != "NULL")//kiem tra xem hoc sinh nay co hoc nam nay chua, neu chua k hien thong tin gi het
        {
            DataTable monhoc = sv.CT_KL_MH_List_MH_KL(manam, sv.Lop_SearchMakl(malop,manam));
            result.Columns.Add("Môn học");
            result.Columns.Add("Điểm hk I");
            result.Columns.Add("Điểm hk II");
            result.Columns.Add("Điểm CN");
            hk1 = sv.Hoc_getHKCuoiKy(mahs, malop, manam, "I").ToString();
            hk2 = sv.Hoc_getHKCuoiKy(mahs, malop, manam, "II").ToString();
            hkcn = sv.TKN_get_HKCuoiNam(manam, mahs);
            if (monhoc.Rows.Count != 0)
            {
                for (int i = 0; i < monhoc.Rows.Count; i++)
                {
                    lengh = 0;
                    Array.Resize(ref diem, lengh + 1);
                    diem[lengh] = monhoc.Rows[i]["Tên môn"].ToString();
                    lengh++;
                    mahk = sv.HocKy_GetMaHK(manam, "I");//hoc ky 1
                    Array.Resize(ref diem, lengh + 1);
                    float diemk1 = ((float)Math.Round(sv.BDM_HK_getDiemTBM_HK(int.Parse(sv.Hoc_GetMaHoc(mahs, malop, mahk).ToString()), sv.CT_KL_MH_GetMaCTKLMH(monhoc.Rows[i]["Mã môn"].ToString(), manam, sv.Lop_SearchMakl(malop,manam).ToString())), 1));
                    diem[lengh] = diemk1.ToString();
                    lengh++;
                    mahk = sv.HocKy_GetMaHK(manam, "II");// hoc ky 2
                    Array.Resize(ref diem, lengh + 1);
                    float diemki2 = ((float)Math.Round(sv.BDM_HK_getDiemTBM_HK(int.Parse(sv.Hoc_GetMaHoc(mahs, malop, mahk).ToString()), sv.CT_KL_MH_GetMaCTKLMH(monhoc.Rows[i]["Mã môn"].ToString(), manam, sv.Lop_SearchMakl(malop,manam).ToString())), 1));
                    diem[lengh] = diemki2.ToString();
                    lengh++;
                    Array.Resize(ref diem, lengh + 1);
                    diem[lengh] = ((float)Math.Round((diemk1 + diemki2 * 2) / 3, 1)).ToString();
                    lengh++;
                    result.Rows.Add(diem);
                }
            }
        }
         return result;
    }
}
