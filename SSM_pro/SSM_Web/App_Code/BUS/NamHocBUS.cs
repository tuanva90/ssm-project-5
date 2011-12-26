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
using System.Data;

/// <summary>
/// Summary description for NamHocBUS
/// </summary>
public class NamHocBUS
{  
     SSM_Service.SSM_Services sv = new SSM_Service.SSM_Services();
	 HocKyBUS hk = new HocKyBUS();
     KhoiLopBUS klbus = new KhoiLopBUS();
     KhoiLop_MonHocBUS klmonbus = new KhoiLop_MonHocBUS();
       public NamHocBUS()
   {
		//
		// TODO: Add constructor logic here
		//
	}
   public int Insert(SSM_Service.NamHocDTO nhdto) // tao mot nam moi thi pai tao cac hoc ki, tao luon bảng khoiloo_monhoc
   {
       SSM_Service.HocKyDTO hkdto = new SSM_Service.HocKyDTO();
       SSM_Service.HocKyDTO hkdto1 = new SSM_Service.HocKyDTO();
       SSM_Service.KhoiLopDTO kldto = new SSM_Service.KhoiLopDTO();
          hkdto.MaHK = hk.getMa();
       hkdto.MaNam = nhdto.MaNam;
       hkdto.Ten_HocKy = "I";
       hkdto1.Ten_HocKy = "II";
       hkdto1.MaNam = nhdto.MaNam;
       int n=0;
       if(sv.NamHoc_Insert(nhdto)>0)
       {
           if (hk.Insert(hkdto) > 0)
           {
               hkdto1.MaHK = hk.getMa();
               n= hk.Insert(hkdto1);
               
               
               for(int i =6;i<10;i++)
               {
                   kldto.TenKhoiLop = "Khối ";
                   kldto.MaKhoiLop = sv.KLop_getMa();
                   kldto.TenKhoiLop += i.ToString();
                   n = sv.KLop_Insert(kldto);
               }
               kldto.MaNam = nhdto.MaNam;
               kldto.SoLop = 6;
               DataTable dt = klbus.List();
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   n = klmonbus.Insert(nhdto.MaNam, dt.Rows[i][0].ToString());
               }
               
           }
           return n;
       }
       else
           return 0;
   }
   public int Update(SSM_Service.NamHocDTO  nhdto)
   {
       return sv.NamHoc_Update(nhdto);
   }
   public DataTable List()
   {
       return sv.NamHoc_List();
   }
   public int Delete(string manam)
   {
       if (hk.Delete(manam) > 0)
       {
           return sv.NamHoc_Delete(manam);
       }
       else
           return hk.Delete(manam);
   }
   public string getMa()
   {
        return sv.NamHoc_getMa();
   }

}
