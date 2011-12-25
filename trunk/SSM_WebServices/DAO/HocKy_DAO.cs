using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class HocKy_DAO
    {
        ConectData conectData = new ConectData();
        
        public int Insert(HocKyDTO Hk)
        {
            string sql = "insert into HOCKY values (@MaHK,@HocKy,@MaNam)";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@MaHK", Hk.MaHK);
            sp[1] = new SqlParameter("@HocKy", Hk.Ten_HocKy);
            sp[2] = new SqlParameter("@MaNam", Hk.MaNam);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int Update(HocKyDTO Hk)
        {
            string sql = "update HOCKY set HocKy=@HocKy,MaNam=@MaNam where MaHK=@MaHK";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@MaHK", Hk.MaHK);
            sp[1] = new SqlParameter("@HocKy", Hk.Ten_HocKy);
            sp[2] = new SqlParameter("@MaNam", Hk.MaNam);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int Delete(string manam)
        {
            string sql = "delete from HOCKY where MaNam=@MaNam";
            SqlParameter sp = new SqlParameter("@MaNam", manam);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public DataTable List()
        {
            string sql = "select hk.MaHK as 'Mã HK',hk.HocKy as 'Học Kỳ', hk.MaNam as 'Mã Năm',(select n.NamHoc from NAMHOC n where hk.MaNam=n.MaNam) as 'Năm Học' from HOCKY hk";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            dt.TableName = "dts";
            return dt;
        }
        
        public DataTable SearchbyMaNam(string manam)
        {
            string sql = "select hk.MaHK as 'Mã HK',hk.HocKy as 'Học kỳ',(select n.NamHoc from NAMHOC n where hk.MaNam=n.MaNam) as 'Năm học' from HOCKY hk where hk.MaNam=@manam";// hk.MaNam as 'Mã năm',(select n.NamHoc from NAMHOC n where hk.MaNam=n.MaNam) as 'Năm học'
            DataTable dt = new DataTable();
            SqlParameter sp = new SqlParameter("@manam", manam);
            dt = conectData.LoadData(sql, sp);
            dt.TableName = "dts";
            return dt;
        }
        public string GetMaHK(string manam, string tenhk)// lay ma hk dua vao ma nam va ten
        {
            string sql = "select MaHK from  HOCKY where MaNam=@manam and HocKy=@tenhk";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@manam", manam);
            sp[1] = new SqlParameter("@tenhk", tenhk);
            DataTable dt = conectData.LoadData(sql, sp);
            dt.TableName = "dt";
            return dt.Rows[0][0].ToString();
        }
        string kq;
    
        public string getMa() // lay ma mon
        {
            string sql = " SELECT MAX(cast(substring(MaHK,3,2) as int)) FROM HOCKY ";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == "NULL")
            {
                kq = "HK" + "01";
            }
            else
            {
                int s = int.Parse(dt.Rows[0][0].ToString()) + 1;
                if (s < 10)
                    kq = "HK" + "0" + s.ToString();
                else
                {
                    if (s < 100)
                        kq = "HK" + s.ToString();

                }
            }
            return kq;
        }
    }
}
