using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class HocSinh_LenCap_DAO
    {
        ConectData conectData = new ConectData();
         public int Insert(HocSinh_LenCapDTO Hs_lc)
        {
            string sql = "insert into HOCSINH_LENCAP values (@MaHS_LC,@MaHS,@DTB,@HanhKiem, @DaPhanLop)";
            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@MaHS_LC", Hs_lc.MaHS_LC);
            sp[1] = new SqlParameter("@MaHS", Hs_lc.MaHS);
            sp[2] = new SqlParameter("@DTB", Hs_lc.DTB.ToString());
            sp[3] = new SqlParameter("@HanhKiem", Hs_lc.HanhKiem);
            sp[4] = new SqlParameter("@DaPhanLop", Hs_lc.DaPhanLop);
            return conectData.Insert_Update_Delete(sql, sp);
        }

        public int Update(HocSinh_LenCapDTO Hs_lc)
        {
            string sql = "update HOCSINH_LENCAP set MaHS=@MaHS,DTB=@DTB,HanhKiem=@HanhKiem, DaPhanLop = @DaPhanLop where MaHS_LC=@MaHS_LC";
            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@MaHS_LC", Hs_lc.MaHS_LC);
            sp[1] = new SqlParameter("@MaHS", Hs_lc.MaHS);
            sp[2] = new SqlParameter("@DTB", Hs_lc.DTB);           
            sp[3] = new SqlParameter("@HanhKiem", Hs_lc.HanhKiem);
            sp[4] = new SqlParameter("@DaPhanLop", Hs_lc.DaPhanLop);
            return conectData.Insert_Update_Delete(sql, sp);
        }

        //Creater: Tuan
        //Sỉ sô sau khi phân lớp tự động cho hs mới lên cấp

        public int PhanLopTuDong_getsiso(string makhoilop)
        {            
            string strsql = "select * from LOP where MaKhoiLop = @makhoilop";
            SqlParameter sp = new SqlParameter("@makhoilop", makhoilop);
            DataTable dtLop = conectData.LoadData(strsql, sp);
            int insolop = dtLop.Rows.Count;
            strsql = "select hslc.MaHS, hs.HoTen, hslc.DTB, hslc.HanhKiem from HOCSINH_LENCAP hslc, HOCSINH hs where hslc.MaHS = hs.MaHS and hslc.DaPhanLop = @_daphanlop";
            SqlParameter spdshs = new SqlParameter("@_daphanlop", '0');
            DataTable dtDSHS = conectData.LoadData(strsql, spdshs);
            return dtDSHS.Rows.Count / insolop;
        }

        //Creater: Tuan

        //Phân lớp thủ công
        public int PhanLopThuCong(string MaHS, string MaLop)
        {
            string strsql = "insert into HOC values (@MaHS, @MaLop, @MaHK, '', '', 'CV01')";
            
            //Lay thong tin Lop Hoc
            string strLopHoc = "select * from LOP where MaLop = @MaLop";
            SqlParameter spLopHoc = new SqlParameter("@MaLop", MaLop);
            DataTable dtLopHoc = conectData.LoadData(strLopHoc, spLopHoc);
                
            //Lay DS Mon Hoc
            string strkl_mh = "";
            strkl_mh = "select * from KHOILOP_MONHOC where MaKhoiLop = @makhoilop";
            SqlParameter spkl_mh = new SqlParameter("@makhoilop", dtLopHoc.Rows[0]["MaKhoiLop"].ToString());
            DataTable dtkl_mh = conectData.LoadData(strkl_mh, spkl_mh);

            strkl_mh = "select * from CT_KHOILOP_MONHOC where MaKLMH = @MaKLMH";
            spkl_mh = new SqlParameter("@MaKLMH", dtkl_mh.Rows[0]["MaKLMH"].ToString());
            DataTable dtDSMH = conectData.LoadData(strkl_mh, spkl_mh);
            int kq = 0;

            //Chọn HOCKY 
            string strHocKy = "select hk.* from HOCKY hk, KHOILOP kl, LOP l where l.MaKhoiLop = kl.MaKhoiLop and kl.MaNam = hk.MaNam and l.MaLop = @MaLop";
            SqlParameter sphk = new SqlParameter("@MaLop", MaLop);
            DataTable dtHK = conectData.LoadData(strHocKy, sphk);

            for (int i = 0; i < dtHK.Rows.Count; i++)
            {              
                //insert vao table HOC
                SqlParameter[] spHoc = new SqlParameter[3];
                spHoc[0] = new SqlParameter("@MaHS", MaHS);
                spHoc[1] = new SqlParameter("@MaLop", MaLop);
                spHoc[2] = new SqlParameter("@MaHK", dtHK.Rows[i]["MaHK"].ToString());                
                kq = conectData.Insert_Update_Delete(strsql, spHoc);
                
                //Lay thong tin du lieu moi them vao table HOC
                string strHocNew = "select * from HOC where MaHS = @MaHS and MaLop = @MaLop and MaHK = @MaHK";
                SqlParameter[] spHocNew = new SqlParameter[3];
                spHocNew[0] = new SqlParameter("@MaHS", MaHS);
                spHocNew[1] = new SqlParameter("@MaLop", MaLop);
                spHocNew[2] = new SqlParameter("@MaHK", dtHK.Rows[i]["MaHK"].ToString());
                DataTable dtHocNew = conectData.LoadData(strHocNew, spHocNew);
               
                //insert vao table BDM_HK & CT_BDM_HK
                for (int j = 0; j < dtDSMH.Rows.Count; j++)
                {                    
                    //insert vao table BDM_HK
                    string strBDM_HK = "insert into BDM_HK values (@MaHoc, @CT_KLMH, '', '')";
                    SqlParameter[] spBDM_HK = new SqlParameter[2];
                    spBDM_HK[0] = new SqlParameter("@MaHoc", dtHocNew.Rows[0]["MaHoc"].ToString());
                    spBDM_HK[1] = new SqlParameter("@CT_KLMH", dtDSMH.Rows[j]["CT_KLMH"].ToString());
                    kq = conectData.Insert_Update_Delete(strBDM_HK, spBDM_HK);

                    //Lay thong du lieu moi them vao table BDM_HK
                    string strBDM_HKNew = "select * from BDM_HK where MaHoc = @MaHoc and CT_KLMH = @CT_KLMH";
                    SqlParameter[] spBDM_HKNew = new SqlParameter[2];
                    spBDM_HKNew[0] = new SqlParameter("@MaHoc", dtHocNew.Rows[0]["MaHoc"].ToString());
                    spBDM_HKNew[1] = new SqlParameter("@CT_KLMH", dtDSMH.Rows[j]["CT_KLMH"].ToString());
                    DataTable dtBDM_HKNew = conectData.LoadData(strBDM_HKNew, spBDM_HKNew);

                    //insert vao table CT_BDM_HK
                    strBDM_HK = "insert into CT_BDM_HK values (@MaBDM_HK, '', '', '', '')";
                    SqlParameter[] spCT_BDM_HK = new SqlParameter[1];
                    spCT_BDM_HK[0] = new SqlParameter("@MaBDM_HK", dtBDM_HKNew.Rows[0]["MaBDM_HK"].ToString());
                    kq = conectData.Insert_Update_Delete(strBDM_HK, spCT_BDM_HK);
                }

            }
            for (int i = 0; i < dtDSMH.Rows.Count; i++)
            {
                //insert vao table BDM_NAM
                string strBDM_NAM = "select MAX(MaBDM_NAM) from BDM_NAM";
                strBDM_NAM = "insert into BDM_NAM values (@MaHS, @CT_KLMH, '', @MaNam)";
                SqlParameter[] spBDM_NAM = new SqlParameter[3];
                spBDM_NAM[0] = new SqlParameter("@MaHS", MaHS);
                spBDM_NAM[1] = new SqlParameter("@CT_KLMH", dtDSMH.Rows[i]["CT_KLMH"].ToString());
                spBDM_NAM[2] = new SqlParameter("@MaNam", dtHK.Rows[0]["MaNam"].ToString());
                kq = conectData.Insert_Update_Delete(strBDM_NAM, spBDM_NAM);
            }

            //insert vao table TKNAM
            string strTKNAM = "insert into TKNAM values (@MaHS, '', '', @MaNam)";
            SqlParameter[] spTKNAM = new SqlParameter[2];
            spTKNAM[0] = new SqlParameter("@MaHS", MaHS);
            spTKNAM[1] = new SqlParameter("@MaNam", dtHK.Rows[0]["MaNam"].ToString());
            kq = conectData.Insert_Update_Delete(strTKNAM, spTKNAM);

            //update lai thuoc tinh 'DaPhanLop'
            string sqlupdate = "update HOCSINH_LENCAP set DaPhanLop = @DaPhanLop where MaHS=@MaHS";
            SqlParameter[] spupdate = new SqlParameter[2];
            spupdate[0] = new SqlParameter("@DaPhanLop", '1');
            spupdate[1] = new SqlParameter("@MaHS", MaHS);
            return kq = conectData.Insert_Update_Delete(sqlupdate, spupdate);
        }
//----------------
        //Phân lớp tự động cho hs mới lên cấp
        public int PhanLopTuDong(string manam, string makhoilop)
        {
            string strsql = "select * from KHOILOP where MaKhoiLop = @makhoilop";
            SqlParameter sp = new SqlParameter("@makhoilop", makhoilop);
            DataTable dtkl = conectData.LoadData(strsql, sp);
            strsql = "select * from HOCKY where MaNam = @manam";
            sp = new SqlParameter("@manam", manam);
            DataTable dtHK = conectData.LoadData(strsql, sp);
           
            strsql = "select * from LOP where MaKhoiLop = @makhoilop";
            sp = new SqlParameter("@makhoilop", makhoilop);
            DataTable dtLop = conectData.LoadData(strsql, sp);
            int insolop = dtLop.Rows.Count;
            
            DataTable dtDSHS = List();
            int insiso = dtDSHS.Rows.Count / insolop;
            strsql = "select hs.MaHS_LC, hs.MaHS from HOCSINH_LENCAP hs where hs.HanhKiem = @hanhkiem and hs.DaPhanLop = '0' order by hs.DTB DESC";
           
            sp = new SqlParameter("@hanhkiem", "Tốt");
            DataTable dtDSHSTot = conectData.LoadData(strsql, sp);

            sp = new SqlParameter("@hanhkiem", "Khá");
            DataTable dtDSHSKha = conectData.LoadData(strsql, sp);

            sp = new SqlParameter("@hanhkiem", "Trung Bình");
            DataTable dtDSHSTrungBinh = conectData.LoadData(strsql, sp);

            sp = new SqlParameter("@hanhkiem", "Yếu");
            DataTable dtDSHSYeu = conectData.LoadData(strsql, sp);

            sp = new SqlParameter("@hanhkiem", "Kém");
            DataTable dtDSHSKem = conectData.LoadData(strsql, sp);

            //join nhieu data table
            DataTable dtDSHSsx = new DataTable();
            dtDSHSsx.Merge(dtDSHSTot);
            dtDSHSsx.Merge(dtDSHSKha);
            dtDSHSsx.Merge(dtDSHSTrungBinh);
            dtDSHSsx.Merge(dtDSHSYeu);
            dtDSHSsx.Merge(dtDSHSKem);
           /* for (int i = 0; i < dtDSHSTot.Rows.Count; i++)
            {
                dtDSHSsx.Rows.Add(dtDSHSTot.Rows[i].Table);
            }
            for (int i = 0; i < dtDSHSKha.Rows.Count; i++)
            {
                dtDSHSsx.Rows.Add(dtDSHSKha.Rows[i]);
            }
            for (int i = 0; i < dtDSHSTrungBinh.Rows.Count; i++)
            {
                dtDSHSsx.Rows.Add(dtDSHSTrungBinh.Rows[i]);
            }
            for (int i = 0; i < dtDSHSYeu.Rows.Count; i++)
            {
                dtDSHSsx.Rows.Add(dtDSHSYeu.Rows[i]);
            }
            for (int i = 0; i < dtDSHSKem.Rows.Count; i++)
            {
                dtDSHSsx.Rows.Add(dtDSHSKem.Rows[i]);
            }
             
            */
            //Lay MaHoc MAX
            strsql = "select MAX(MaHoc) from HOC";
            DataTable dtHoc = conectData.LoadData(strsql);
            int MaHoc = int.Parse(dtHoc.Rows[0][0].ToString());
            
            int indem = 0, intam = 0;
            bool bl = true;
            string strkl_mh = "";
            strkl_mh = "select * from KHOILOP_MONHOC where MaKhoiLop = @makhoilop";
            SqlParameter spkl_mh = new SqlParameter("@makhoilop", makhoilop);
            DataTable dtkl_mh = conectData.LoadData(strkl_mh, spkl_mh);

            strkl_mh = "select * from CT_KHOILOP_MONHOC where MaKLMH = @MaKLMH";
            spkl_mh = new SqlParameter("@MaKLMH", dtkl_mh.Rows[0]["MaKLMH"].ToString());
            DataTable dtDSMH = conectData.LoadData(strkl_mh, spkl_mh);
            int kq = 0;
            while (indem < dtDSHSsx.Rows.Count)
            {
                MaHoc++;
                if (intam >= insolop)
                {
                    bl = false;
                    intam--;
                }
                if(intam < 0)
                {
                    bl = true;
                    intam++;
                }
                strsql = "insert into HOC values (@MaHS, @MaLop, @MaHK, '', '', 'CV01')";
               
                for (int i = 0; i < dtHK.Rows.Count; i++)
                {
                    //insert vao table HOC
                    SqlParameter[] spHoc = new SqlParameter[3];
                    spHoc[0] = new SqlParameter("@MaHS", dtDSHSsx.Rows[indem]["MaHS"].ToString());
                    spHoc[1] = new SqlParameter("@MaLop", dtLop.Rows[intam]["MaLop"].ToString());
                    spHoc[2] = new SqlParameter("@MaHK", dtHK.Rows[i]["MaHK"].ToString());
                    kq = conectData.Insert_Update_Delete(strsql, spHoc);

                    //Lay thong tin du lieu moi them vao table HOC
                    string strHocNew = "select * from HOC where MaHS = @MaHS and MaLop = @MaLop and MaHK = @MaHK";
                    SqlParameter[] spHocNew = new SqlParameter[3];
                    spHocNew[0] = new SqlParameter("@MaHS", dtDSHSsx.Rows[indem]["MaHS"].ToString());
                    spHocNew[1] = new SqlParameter("@MaLop", dtLop.Rows[intam]["MaLop"].ToString());
                    spHocNew[2] = new SqlParameter("@MaHK", dtHK.Rows[i]["MaHK"].ToString());
                    DataTable dtHocNew = conectData.LoadData(strHocNew, spHocNew);

                    //insert vao table BDM_HK & CT_BDM_HK
                    for(int j = 0; j < dtDSMH.Rows.Count; j++)
                    {
                        //Lay MaBDM_HK max
                        string strBDM_HK = "select MAX(MaBDM_HK) from BDM_HK";
                        DataTable dtBDM_HK = conectData.LoadData(strBDM_HK);
                        int inMaBDM_HKMax = int.Parse(dtBDM_HK.Rows[0][0].ToString());
                        inMaBDM_HKMax++;

                        //insert vao table BDM_HK
                        strBDM_HK = "insert into BDM_HK values (@MaHoc, @CT_KLMH, '', '')";
                        SqlParameter[] spBDM_HK = new SqlParameter[2];
                        spBDM_HK[0] = new SqlParameter("@MaHoc", dtHocNew.Rows[0]["MaHoc"].ToString());
                        spBDM_HK[1] = new SqlParameter("@CT_KLMH", dtDSMH.Rows[j]["CT_KLMH"].ToString());
                        kq = conectData.Insert_Update_Delete(strBDM_HK, spBDM_HK);

                        //Lay thong du lieu moi them vao table BDM_HK
                        string strBDM_HKNew = "select * from BDM_HK where MaHoc = @MaHoc and CT_KLMH = @CT_KLMH";
                        SqlParameter[] spBDM_HKNew = new SqlParameter[2];
                        spBDM_HKNew[0] = new SqlParameter("@MaHoc", dtHocNew.Rows[0]["MaHoc"].ToString());
                        spBDM_HKNew[1] = new SqlParameter("@CT_KLMH", dtDSMH.Rows[j]["CT_KLMH"].ToString());
                        DataTable dtBDM_HKNew = conectData.LoadData(strBDM_HKNew, spBDM_HKNew);

                        //insert vao table CT_BDM_HK
                        strBDM_HK = "insert into CT_BDM_HK values (@MaBDM_HK, '', '', '', '')";
                        SqlParameter[] spCT_BDM_HK = new SqlParameter[1];
                        spCT_BDM_HK[0] = new SqlParameter("@MaBDM_HK", dtBDM_HKNew.Rows[0]["MaBDM_HK"].ToString());
                        kq = conectData.Insert_Update_Delete(strBDM_HK, spCT_BDM_HK);
                    }
                    
                }
                for (int i = 0; i < dtDSMH.Rows.Count; i++)
                {
                    //insert vao table BDM_NAM
                    string strBDM_NAM = "insert into BDM_NAM values (@MaHS, @CT_KLMH, '', @MaNam)";
                    SqlParameter[] spBDM_NAM = new SqlParameter[3];                  
                    spBDM_NAM[0] = new SqlParameter("@MaHS", dtDSHSsx.Rows[indem]["MaHS"].ToString());
                    spBDM_NAM[1] = new SqlParameter("@CT_KLMH", dtDSMH.Rows[i]["CT_KLMH"].ToString());
                    spBDM_NAM[2] = new SqlParameter("@MaNam", manam);
                    kq = conectData.Insert_Update_Delete(strBDM_NAM, spBDM_NAM);
                }

                //insert vao table TKNAM
                string strTKNAM = "insert into TKNAM values (@MaHS, '', '', @MaNam)";
                SqlParameter[] spTKNAM = new SqlParameter[2];
                spTKNAM[0] = new SqlParameter("@MaHS", dtDSHSsx.Rows[indem]["MaHS"].ToString());
                spTKNAM[1] = new SqlParameter("@MaNam", manam);
                kq = conectData.Insert_Update_Delete(strTKNAM, spTKNAM);

                //update lai thuoc tinh 'DaPhanLop'
                string sqlupdate = "update HOCSINH_LENCAP set DaPhanLop = @DaPhanLop where MaHS_LC=@MaHS_LC";
                SqlParameter[] spupdate = new SqlParameter[2];
                spupdate[0] = new SqlParameter("@DaPhanLop", '1');
                spupdate[1] = new SqlParameter("@MaHS_LC", dtDSHSsx.Rows[indem]["MaHS_LC"].ToString());
                kq = conectData.Insert_Update_Delete(sqlupdate, spupdate);
                if (bl)
                {
                    intam++;
                }
                if (!bl)
                {
                    intam--;
                }
                indem++;
            }
            return 1;
        }

        /*  public int Delete(string mahslc)
          {
              string sql = "delete from HOCSINH_LENCAP where MaHS_LC=@MaHSLC";
              SqlParameter sp = new SqlParameter("@MaHSLC", mahslc);
              return conectData.Insert_Update_Delete(sql, sp);
          }
          */
        public DataTable List()
        {
            string sql = "select hslc.MaHS, hs.HoTen, hslc.DTB, hslc.HanhKiem from HOCSINH_LENCAP hslc, HOCSINH hs where hslc.MaHS = hs.MaHS and hslc.DaPhanLop = @_daphanlop";
          //  SqlParameter sp = new SqlParameter("@_daphanlop", '0');
            SqlParameter sp = new SqlParameter();
            sp.ParameterName = "@_daphanlop";
            sp.Value = '0';
            DataTable dt = conectData.LoadData(sql, sp);
            dt.TableName = "dtlist";
            return dt;
        }
        // cac ham select se duoc viet tiep o day.
    }
}
