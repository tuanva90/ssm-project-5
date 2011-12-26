using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using DTO;
using DAO;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Service
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class SSM_Services : System.Web.Services.WebService
{

    public SSM_Services()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    #region DTO
    [WebMethod]
    public ToDTO todto()
    {
        ToDTO todto = new ToDTO();
        return todto;
    }
    [WebMethod]
    public MonHocDTO monhocdto()
    {
        MonHocDTO mon = new MonHocDTO();
        return mon;
    }
    [WebMethod]
    public LopDTO lopdto()
    {
        LopDTO lop = new LopDTO();
        return lop;
    }
    [WebMethod]
    public HocSinhDTO hocsinhdto()
    {
        HocSinhDTO hs = new HocSinhDTO();
        return hs;
    }
    [WebMethod]
    public GiaoVienDTO giaoviendto()
    {
        GiaoVienDTO gv = new GiaoVienDTO();
        return gv;
    }
    [WebMethod]
    public KhoiLopDTO kldto()
    {
        KhoiLopDTO kl = new KhoiLopDTO();
        return kl;
    }
    [WebMethod]
    public NamHocDTO namhocdto()
    {
        NamHocDTO nh = new NamHocDTO();
        return nh;
    }
    [WebMethod]
    public HocKyDTO hkdto()
    {
        HocKyDTO hk = new HocKyDTO();
        return hk;
    }

    #endregion

    #region  cac ham xu ly To (ToDAO)

    To_DAO todao = new To_DAO();
    [WebMethod]
    public int To_Insert(ToDTO todto)
    {
        return todao.Insert(todto);
    }
    [WebMethod]
    public int To_Update(ToDTO todto)
    {
        return todao.Update(todto);
    }
    [WebMethod]
    public int To_Delete(string mato)
    {
        return todao.Delete(mato);
    }
    [WebMethod]
    public DataTable To_List()
    {
        return todao.List();
    }
    [WebMethod]
    public string To_getMa()
    {
        return todao.getMaTo();
    }
    [WebMethod]
    public DataTable To_searchbyMa(string ma)
    {
        return todao.SearchMaTo(ma);
    }
    [WebMethod]
    public DataTable To_SearchTen(string ten)
    {
        return todao.SearchbyTenTo(ten);
    }
    [WebMethod]
    public bool To_checkTrungten(string to)
    {
        DataTable dt = todao.SearchbyTenTo(to);
        if (dt.Rows.Count == 0)
            return false;
        else
            return true;
    }

    #endregion

    #region cac ham xu ly ct_to (cttodao)
    CT_TO_DAO ctt = new CT_TO_DAO();
    [WebMethod]
    public int CT_To_Insert(CT_ToDTO ctto)
    {
        return ctt.Insert(ctto);
    }
    [WebMethod]
    public int CT_To_Delete(string mact, string mamon)
    {
        return ctt.Delete(mact, mamon);
    }
    #endregion

    #region Cac ham xu ly MonHoc (MonHocDAO)
    MonHoc_DAO mhdao = new MonHoc_DAO();
    [WebMethod]
    public int MonHoc_Insert(MonHocDTO mh)
    {
        return mhdao.Insert(mh);
    }
    [WebMethod]
    public int MonHoc_Update(MonHocDTO mh)
    {
        return mhdao.Update(mh);
    }
    [WebMethod]
    public DataTable MonHoc_List()
    {
        return mhdao.List();
    }
    [WebMethod]
    public int MonHoc_Delete(string mamon)
    {
        return mhdao.Delete(mamon);
    }
    [WebMethod]
    public DataTable MonHoc_SearchbyMa(string ma)
    {
        return mhdao.SearchbyMa(ma);
    }
    [WebMethod]
    public DataTable MonHoc_SeaerchbyTen(string ten)
    {
        return mhdao.SearchbyTen(ten);
    }
    [WebMethod]
    public string MonHoc_getMa()
    {
        return mhdao.getMaMon();
    }
    [WebMethod]
    public DataTable MonHoc_ListbyMaNam_MaLop(string manam, string malop)
    {
        return mhdao.ListbyMaNam_MaLop(manam, malop);
    }
    [WebMethod]
    public bool MonHoc_checkTrungtenmon(string monhoc)
    {
        DataTable dt = mhdao.List();
        bool result = false;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["Tên môn"].ToString() == monhoc)
            {
                result = true;
                break;
            }
        }
        return result;
    }
    #endregion

    #region Cac ham xu ly Lop (LopDAO)
    Lop_DAO lopdao = new Lop_DAO();
    [WebMethod]
    public int Lop_Insert(LopDTO lop)
    {
        return lopdao.Insert(lop);
    }
    [WebMethod]
    public int Lop_Update(string malop, string tenlop, string magv)
    {
        return lopdao.Update(malop, tenlop, magv);
    }
    [WebMethod]
    public DataTable Lop_List()
    {
        return lopdao.List();
    }
    [WebMethod]
    public int Lop_Updatesiso(int siso, string malop)
    {
        return lopdao.UpdateSiso(siso, malop);
    }
    [WebMethod]
    public DataTable Lop_searchbyMakl(string makl) // lay danh sach lop theo ma khoi lop
    {
        return lopdao.Searchbymakl(makl);
    }
    [WebMethod]
    public string Lop_getMa()
    {
        return lopdao.getMa();
    }
    [WebMethod]
    public int Lop_Delete(string malop)
    {
        return lopdao.Delete(malop);
    }
    [WebMethod]
    public string Lop_SearchMakl(string malop, string manam)
    {
        return lopdao.SearchMakl(malop, manam);
    }
    [WebMethod]
    public DataTable Lop_ListbyNamHoc(string namhoc)
    {
        return lopdao.ListbyNamHoc(namhoc);
    }
    [WebMethod]
    public string Lop_getTenLop(string malop)
    {
        return lopdao.getTenLop(malop);
    }
    [WebMethod]
    public DataTable Lop_ListbyKhoiLop(string makhoilop)
    {
        return lopdao.ListbyMaKhoi(makhoilop);
    }
    /*
     * kiem tra trung ten lop hay khong, truyen vao ten lop
     * tra ve true neu trung ten
     * nguoc lai false
     * */
    [WebMethod]
    public bool Lop_checkTrungtenlop(string tenlop)
    {
        DataTable dt = lopdao.List();
        bool result = false;
        for (int k = 0; k < dt.Rows.Count; k++)
        {
            if (dt.Rows[k]["Tên lớp"].ToString() == tenlop)
            {
                result = true;
                break;
            }
        }
        return result;
    }
    #endregion

    #region Cac ham xu ly KhoiLop (KhoiLopDAO)
    KhoiLop_DAO kldao = new KhoiLop_DAO();
    [WebMethod]
    public int KLop_Insert(KhoiLopDTO kl)
    {
        return kldao.Insert(kl);
    }
    [WebMethod]
    public int KLop_Update(KhoiLopDTO kl)
    {
        return kldao.Update(kl);
    }
    [WebMethod]
    public DataTable KLop_List()
    {
        return kldao.List();
    }
    [WebMethod]
    public DataTable KLop_ListByMaNam(string manam)
    {
        return kldao.ListbyMaNam(manam);
    }
    [WebMethod]
    public int KLop_Delete(string mkl)
    {
        return kldao.Delete(mkl);
    }
    [WebMethod]
    public string KLop_getMa()
    {
        return kldao.getMa();
    }
    [WebMethod]
    public int KLop_UpdateSoLop(int solop, string makl)
    {
        return kldao.Updatesolop(solop, makl);
    }
    [WebMethod]
    public string KLop_getMaKLbyMaNam(string manam)
    {
        return kldao.get_MaKhoi(manam);
    }
    #endregion

    #region Cac ham xu ly NamHoc ( NamHocDAO)
    NamHoc_DAO nhdao = new NamHoc_DAO();
    [WebMethod] // them vao nam hoc moi
    public int NamHoc_Insert(NamHocDTO nh)
    {
        return nhdao.Insert(nh);
    }
    [WebMethod] // cap nhat thogn tin nam hoc
    public int NamHoc_Update(NamHocDTO nh)
    {
        return nhdao.Update(nh);
    }
    [WebMethod] // lay danh sach cac nam hoc
    public DataTable NamHoc_List()
    {
        return nhdao.List();
    }
    [WebMethod] //lay ma nam hoc
    public string NamHoc_getMa()
    {
        return nhdao.getMa();
    }
    [WebMethod] // xoa nam hoc theo ma nam
    public int NamHoc_Delete(string manam)
    {
        return nhdao.Delete(manam);
    }
    [WebMethod]
    public bool NamHoc_checkTrungtennam(string tennam)
    {
        DataTable dt = nhdao.List();
        bool result = false;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["Năm học"].ToString() == tennam)
            {
                result = true;
                break;
            }
        }
        return result;
    }
    #endregion

    #region Cac ham xu ly HocKy (HocKyDAO)
    HocKy_DAO hkdao = new HocKy_DAO();
    [WebMethod] // them hoc ki moi
    public int HocKy_Insert(HocKyDTO hk)
    {
        return hkdao.Insert(hk);
    }
    [WebMethod] // cap nhat thogn tin hoc ki
    public int HocKy_Update(HocKyDTO hk)
    {
        return hkdao.Update(hk);
    }
    [WebMethod] // xoa hoc ki theo ma nam hoc
    public int HocKy_Delete(string manam)
    {
        return hkdao.Delete(manam);
    }
    [WebMethod] // tim kiem hoc ki theo ma nam
    public DataTable HocKy_searchbyMaNam(string manam) // lay danh sach hoc ky theo nam hoc
    {
        return hkdao.SearchbyMaNam(manam);
    }
    [WebMethod] // lay ma hocky, dung de tao ma  hoc ki khi them vao mot hoc ki moi, se lay ma hoc ki lon nhat  + 1 ==> ma hoc ki de them vao hk moi
    public string HocKy_getMa()
    {
        return hkdao.getMa();
    }
    [WebMethod] // lay ma hoc ki theo manam va tenhk ( lấy hoc ki I or II cua nam nào do)
    public string HocKy_GetMaHK(string manam, string tenhk)
    {
        return hkdao.GetMaHK(manam, tenhk);
    }
    #endregion

    #region Cac ham xu ly HocSinh (HocSinhDAO)
    HocSinh_DAO hsdao = new HocSinh_DAO();
    [WebMethod] //them hoc sinh moi
    public int HocSinh_Insert(HocSinhDTO hs)
    {
        return hsdao.Insert(hs);
    }
    [WebMethod]
    public int HocSinh_Update(HocSinhDTO hs)
    {
        return hsdao.Update(hs);
    }
    [WebMethod]
    public int HocSinh_Dekete(string mahs)
    {
        return hsdao.Delete(mahs);
    }
    [WebMethod] // tim hoc sinh theo ma hs( lay thong tin hoc sinh rut gon)
    public DataTable HocSinh_searchbyMa(string mahs)
    {
        return hsdao.SearchMaHS(mahs);
    }
    [WebMethod] // tim hoc sinh theo ten hs( lay thong tin hoc sinh rut gon)
    public DataTable HocSinh_searchbyTen(string ten)
    {
        return hsdao.SearchByName(ten);
    }
    [WebMethod] // tim hoc sinh thoe mahs ( lay thong tin day du cua hoc sinh)
    public DataTable HocSinh_SearchbyMa_FULL(string mahs)
    {
        return hsdao.SearchMaHS_Full(mahs);
    }
    [WebMethod]
    public string HocSinh_getMa(string ma)
    {
        return hsdao.getMahs(ma);
    }
    [WebMethod]
    public DataTable HocSinh_HSchuaphanlop(string manam) // lay danh sach hoc sinh chua duoc phan lop theo nam hoc
    {
        return hsdao.HSchuaphanlop(manam);
    }

    //Create TuanVA

    [WebMethod]
    public DataTable HocSinh_listHSDuocLenLen(string MaKhoiLop_Cu) // lay danh sach hoc sinh dc len lop theo nam hoc cu
    {
        return hsdao.listHSDuocLenLop(MaKhoiLop_Cu);
    }

    [WebMethod]
    public DataTable HocSinh_listHSLuBan(string MaKhoiLop_Cu) // lay danh sach hoc sinh luu ban theo nam hoc cu
    {
        return hsdao.listHSLuuBan(MaKhoiLop_Cu);
    }

    [WebMethod]
    public int HocSinh_PhanLopThuCong(string MaHS, string MaLop) // Phan lop thu cong cho tung HS theo Lop
    {
        return hsdao.PhanLopThuCong(MaHS, MaLop);
    }

    [WebMethod]
    public int HocSinh_PhanLopTuDong(string MaLop_cu, string MaLop_moi) // Phan lop tu dong
    {
        return hsdao.PhanLopTuDong(MaLop_cu, MaLop_moi);
    }

    [WebMethod]
    public int HocSinh_ChuyenLop(string MaHS, string MaLop_cu, string MaLop_moi) // Chuyen lop
    {
        return hsdao.ChuyenLop(MaHS, MaLop_cu, MaLop_moi);
    }

    [WebMethod]
    public bool HocSinh_KiemTraLenLop(string MaHS, string MaNam) // Kiem tra HS co duoc len lop hay ko
    {
        return hsdao.KiemTraLenLop(MaHS, MaNam);
    }

    //END BY TUANVA

    [WebMethod] // lay danh sach taat ca hoc sinh
    public DataTable HocSinh_List()
    {
        return hsdao.List();
    }
    [WebMethod]
    public string HocSinh_getHoTen(string mahs)
    {
        return hsdao.getHoTen(mahs);
    }
    #endregion

    #region HocSinh_LenCapDAO
    HocSinh_LenCap_DAO hs_lcdao = new HocSinh_LenCap_DAO();
    [WebMethod]
    public DataTable HocSinh_LenCap_List()
    {
        return hs_lcdao.List();
    }

    [WebMethod]
    public int HocSinh_LenCap_Insert(HocSinh_LenCapDTO Hs_lc)
    {
        return hs_lcdao.Insert(Hs_lc);
    }

    [WebMethod]
    public int HocSinh_LenCap_Update(HocSinh_LenCapDTO Hs_lc)
    {
        return hs_lcdao.Update(Hs_lc);
    }

    [WebMethod]
    public int PhanLopTuDong_getsiso(string makhoilop)
    {
        return hs_lcdao.PhanLopTuDong_getsiso(makhoilop);
    }

    [WebMethod]
    public int PhanLopTuDong(string manam, string makhoilop)
    {
        return hs_lcdao.PhanLopTuDong(manam, makhoilop);
    }

    [WebMethod]
    public int PhanLopThuCong(string MaHS, string MaLop)
    {
        return hs_lcdao.PhanLopThuCong(MaHS, MaLop);
    }

    #endregion

    #region Cac ham xu ly GiaoVien (GiaoVienDAO)
    GiaoVien_DAO gvdao = new GiaoVien_DAO();
    [WebMethod]
    public int GiaoVien_Insert(GiaoVienDTO gv)
    {
        return gvdao.InsertGiaoVien(gv);
    }
    [WebMethod]
    public int GiaoVien_Update(GiaoVienDTO gv)
    {
        return gvdao.UpdateGiaoVien(gv);
    }
    [WebMethod]
    public int GiaoVien_Delete(string magv)
    {
        return gvdao.DeleteGiaoVien(magv);
    }
    [WebMethod]
    public DataTable GiaoVien_SearchbyName(string ten)
    {
        return gvdao.SearchbyName(ten);
    }
    [WebMethod]
    public DataTable GiaoVien_SearchbyMa(string ma)
    {
        return gvdao.SearchbyMaGV(ma);
    }
    [WebMethod]
    public DataTable GiaoVien_SearchbyMa_Full(string ma)
    {
        return gvdao.SearchbyMaGV_Full(ma);

    }
    [WebMethod]
    public string GiaoVien_getMa()
    {
        return gvdao.getMaGV();
    }
    [WebMethod]
    public DataTable GiaoVien_List()
    {
        return gvdao.ListGV();
    }
    #endregion

    #region Cac ham xu ly Hoc (HocDAO)
    Hoc_DAO hocdao = new Hoc_DAO();
    [WebMethod] // them mot bảng hoc
    public int Hoc_Insert(HocDTO hoc)
    {
        return hocdao.Insert(hoc);
    }
    [WebMethod]
    public int Hoc_Update(HocDTO hoc)
    {
        return hocdao.Update(hoc);
    }
    [WebMethod] // lay thogn tin lop truong cua mot lop
    public DataTable Hoc_Checkloptruong(string malop, string manam)
    {
        return hocdao.CheckLopTruong(malop, manam);
    }
    [WebMethod]
    public int Hoc_UpdateMalop(string malop, string mahoc)
    {
        return hocdao.UpdateMalop(malop, mahoc);
    }
    [WebMethod] // cập nhat chuc vu 
    public int Hoc_UpdateChucvu(string cv, string mahoc)
    {
        return hocdao.UpdateChucVu(cv, mahoc);
    }
    [WebMethod] // cap nhat diem cuoi ki
    public int Hoc_UpdateDiemCK(float diem, string mahoc)
    {
        return hocdao.UpdateDiemCuoiKy(diem, mahoc);
    }
    [WebMethod] // cap nhat hanh kiem cuoi ki
    public int Hoc_UpdateHKCK(string hk, string mahoc)
    {
        return hocdao.UpdateHKCuoiKy(hk, mahoc);
    }
    [WebMethod]
    public string Hoc_GetMaHoc(string mahs, string malop, string mahk) // lay ma hoc theo ma h s, ma lop, mahk
    {
        return hocdao.getMaHoc(mahs, malop, mahk);
    }
    [WebMethod]
    public int Hoc_Delete(string mahoc)
    {
        return hocdao.Delete(mahoc);
    }
    [WebMethod]
    public DataTable Hoc_getBangDiemHK(int mahoc, string mamon)
    {
        return hocdao.getBangDiem(mahoc, mamon);// lay bang diem hoc ki theo mon
    }
    [WebMethod] // lay bang hoc theo nam va ma kl
    public DataTable Hoc_GetMaHoc_manam_makl(string manam, string makl)
    {
        return hocdao.GetMaHoc(manam, makl);
    }
    [WebMethod] // lay diem cuoi ki
    public string Hoc_getHKCuoiKy(string mahs, string malop, string manam, string tenhk)
    {
        return hocdao.getHKCuoiKy(mahs, malop, manam, tenhk);
    }
    [WebMethod] // lay diem cuoi ki
    public float Hoc_getDiemCK(string mahs, string malop, string manam, string tenhk)
    {
        return hocdao.getDiemCuoiKy(mahs, malop, manam, tenhk);
    } // lay diem cuoi ki , hanh kiem cuoi ki
    [WebMethod]
    public DataTable Hoc_getDCK_HKCK(string manam, string tenhk, string malop)
    {
        return hocdao.getDCK_HKCK(manam, tenhk, malop);
    }
    [WebMethod]// lay danh sach hoc sinh theo lop
    public DataTable Hoc_getListHS_Lop(string mahk, string malop)
    {
        return hocdao.getLisHS_Lop(mahk, malop);
    }
    [WebMethod]
    public string Hoc_getMaLop(string mahs, string mahk)
    {
        return hocdao.getMaLop(mahs, mahk);
    }
    #endregion

    #region Cac ham xu ly BDM_HK (BDM_HKDAo)
    BDM_HK_DAO bdmhkdao = new BDM_HK_DAO();
    [WebMethod]
    public int BDM_HK_Insert(BDM_HKDTO bd)
    {
        return bdmhkdao.Insert(bd);
    }
    [WebMethod]
    public int BDM_HK_Delete(int mahoc, int ctbdmhk)
    {
        return bdmhkdao.Delete(mahoc, ctbdmhk);
    }
    [WebMethod]
    public DataTable BDM_HK_List()
    {
        return bdmhkdao.List();
    }
    [WebMethod]
    public int BDM_HK_UpdateDiemTB(int mahoc, int ctbdmhk, float diem)
    {
        return bdmhkdao.UpdateDiemTBM(mahoc, ctbdmhk, diem);
    }
    [WebMethod]
    public int BDM_HK_UpdateDiemTBM_KT(int mahoc, int ctbdmhk, float diem)
    {
        return bdmhkdao.UpdateDiemTBM_KT(mahoc, ctbdmhk, diem);
    }
    [WebMethod]
    public int BDM_HK_GetMaBDMHK(int mahoc, int ctklmh)
    {
        return bdmhkdao.GetMaBDM_HK(mahoc, ctklmh);
    }
    [WebMethod]
    public bool BDM_HK_Check_MaCTKLMH_BDMHK(int mactklmh)
    {
        return bdmhkdao.Check_MaCTKLMH_BDMHK(mactklmh);
    }
    [WebMethod] // lay danh sach diem cac mon 
    public DataTable BDM_HK_getDiemCacMon(string manam, string tenhk, string makl, string mahs)
    {
        return bdmhkdao.getDiemCacMon(manam, tenhk, makl, mahs);
    }
    [WebMethod]
    public float BDM_HK_getDiemTBM_KT(int mahoc, int ct_klmh)
    {
        return bdmhkdao.GetDiemTBM_KT(mahoc, ct_klmh);
    }
    [WebMethod]
    public float BDM_HK_getDiemTBM_HK(int mahoc, int ct_klmh)
    {
        return bdmhkdao.GetDiemTBM_HK(mahoc, ct_klmh);
    }
    #endregion

    #region Cac ham xu ly CT_BDM_HK (CT_BDM_HKDAO)
    CT_BDM_HK_DAO ctbdmhkdao = new CT_BDM_HK_DAO();
    [WebMethod]
    public int CT_BDM_HK_Insert(CT_BDM_HKDTO bd)
    {
        return ctbdmhkdao.Insert(bd);
    }
    [WebMethod]
    public int CT_BDM_HK_Update(CT_BDM_HKDTO bd)
    {
        return ctbdmhkdao.Update(bd);
    }
    [WebMethod] // lấy maBDM theo ma hoc va mactklmh
    public int CT_BDM_HK_GetMaBDM(int mahoc, int ctklmh)
    {
        return ctbdmhkdao.GetMaBDM_HK(mahoc, ctklmh);
    }
    [WebMethod]
    public int CT_BDM_HK_Delete(int mahoc, int ctklmh)
    {
        return ctbdmhkdao.Delete(mahoc, ctklmh);
    }
    [WebMethod]// kiem tra xem khoi lop nao , nam hoc nao da hoc mon hoc nao. neu mot nam x, khoi lop y da hoc mon z thi tra ve true, nguoc lai tra ve false
    public bool CT_BDM_HK_Check(string manam, string makhoilop, string mamon)
    {
        return ctbdmhkdao.Check(manam, makhoilop, mamon);
    }
    [WebMethod]
    public DataTable CT_BDM_HK_List(string mahk, string malop, string mamon)
    {
        return ctbdmhkdao.List(mahk, malop, mamon);
    }
    [WebMethod]
    public int CT_KL_HK_UpdateDiemHK(int mahoc, int ctklmh, float diem)
    {
        return ctbdmhkdao.UpdateDiemHK(mahoc, ctklmh, diem);
    }
    #endregion

    #region Cac ham xu ly KL_Mon ( KhoiLop_MonDAO)
    KhoiLop_MonHocDAO kl_mondao = new KhoiLop_MonHocDAO();
    [WebMethod]
    public int KhoiLop_Mon_Insert(string manam, string makhoi)
    {
        return kl_mondao.Insert(makhoi);
    }
    [WebMethod]
    public int KhoiLop_Mon_Delete(string manam, string makhoi)
    {
        return kl_mondao.Delete(makhoi);
    }
    [WebMethod]
    public int KhoiLop_Mon_GetMa(string manam, string makhoi)
    {
        return kl_mondao.GetMa(manam, makhoi);
    }
    #endregion

    #region Cac ham xu ly CT_KL_Mon (CT_KL_Mon)
    CT_KhoiLop_MonHocDAO ctklm = new CT_KhoiLop_MonHocDAO();
    [WebMethod]
    public int CT_KL_Mon_Insert(string mamon, int makl_mon)
    {
        return ctklm.Insert(mamon, makl_mon);
    }
    [WebMethod]
    public int CT_KL_Mon_Delete(string mamon, int makl_mon)
    {
        return ctklm.Delete(mamon, makl_mon);
    }
    [WebMethod]
    public bool CT_KL_MH_Check(string manam, string makhoi, string mamon)
    {
        return ctklm.Check(manam, mamon, makhoi);
    }
    [WebMethod] // lay danh sach cac mon hoc theo tun gkhoi lop
    public DataTable CT_KL_MH_List_MH_KL(string manam, string makhoi)
    {
        return ctklm.List_MH_KL(manam, makhoi);
    }
    [WebMethod] // lay ma nam, ma khoi tu bang KL_MH khi biet mamon o bang CT_KL_/mh, khi them mot bang ct_kl_mh (tuc them mot mon hoc moi cho mot khoi lop thi pai them bdm_hk vao tat cac cac bang  hoc co manam la manam, makhoi la makhoi)
    public DataTable CT_KL_MH_Get_MaNam_MaKhoi(string mamon)
    {
        return ctklm.Get_MaNam_MaKhoi(mamon);
    }
    [WebMethod] // lay maCTKLMH( khoa chinh cua bang KhoiLop_MonHoc
    public int CT_KL_MH_GetMaCTKLMH(string mamon, string manam, string makl)
    {
        return ctklm.Get_MaCTKLMH(manam, mamon, makl);
    }
    #endregion

    #region Cac ham xu ly TKnam (TKNAMDAO)
    TKNam_DAO tknamdao = new TKNam_DAO();
    [WebMethod]
    public int TKNam_Insert(TKNAMDTO tkn)
    {
        return tknamdao.Insert(tkn);
    }
    [WebMethod]
    public int TKNam_UpdateDiemCuoiNam(string manam, string mahs, float diemcuoinam)
    {
        return tknamdao.UpdateDiemCuoiNam(manam, mahs, diemcuoinam);
    }
    [WebMethod]
    public int TKNam_UpdateHKCuoiNam(string manam, string mahs, string hkcuoinam)
    {
        return tknamdao.UpdateHKCuoiNam(manam, mahs, hkcuoinam);
    }
    [WebMethod]
    public int TKNam_Delete(string manam, string mahs)
    {
        return tknamdao.Delete(manam, mahs);
    }
    [WebMethod]
    public int TKNam_GetMaBTKN(string manam, string mahs)
    {
        return tknamdao.GetMaBTKN(manam, mahs);
    }
    [WebMethod]
    public string TKN_get_HKCuoiNam(string manam, string mahs)
    {
        return tknamdao.get_HKCuoiNam(manam, mahs);
    }
    [WebMethod]
    public float TKN_get_DiemCuoiNam(string manam, string mahs)
    {
        return tknamdao.get_DiemCuoiNam(manam, mahs);
    }
    #endregion

    #region Cac ham xu ly ChucVu (ChucVuDAO)
    ChucVu_DAO chucvudao = new ChucVu_DAO();
    /*
     * kiiem tra trung ten chuc vu
     * tra ve true neu trung
     * false n eu k trung
     * */
    [WebMethod]
    public bool ChucVu_checkTrungtenchucvu(string tenchucvu)
    {
        DataTable dt = chucvudao.List();
        bool result = false;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["Chức vụ"].ToString() == tenchucvu)
            {
                result = true;
                break;
            }
        }
        return result;
    }
    #endregion

}


