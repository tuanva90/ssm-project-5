using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
   public  class MonHoc_DAO
    {
        ConectData conectData = new ConectData();
        
        public int Insert(MonHocDTO Mh)
        {
            string sql = "insert into MONHOC values (@MaMon,@TenMon,@HeSo)";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@MaMon", Mh.MaMon);
            sp[1] = new SqlParameter("@TenMon", Mh.TenMon);
            sp[2] = new SqlParameter("@HeSo",Mh.HeSo);
            return conectData.Insert_Update_Delete(sql, sp);
        }
            
        public int Update(MonHocDTO Mh)
        {
            string sql = "update MONHOC set TenMon=@TenMon,HeSo=@HeSo where MaMon=@MaMon";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@MaMon", Mh.MaMon);
            sp[1] = new SqlParameter("@TenMon", Mh.TenMon);
            sp[2] = new SqlParameter("@HeSo", Mh.HeSo);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int Delete(string mamon)
        {
            string sql = "delete from MONHOC where MaMon=@MaMon";
            SqlParameter sp = new SqlParameter("@MaMon", mamon);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public DataTable List()
        {
            string sql = "select MaMon as 'Mã môn',TenMon as 'Tên môn',HeSo as 'Hệ số' from MONHOC";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            dt.TableName = "dts";
            return dt;
        }
        public DataTable ListbyMaNam_MaLop(string manam, string malop) // lay danh sach mon hoc theo ma nam, malop
        {
            string sql = "select mh.MaMon as 'Mã môn',mh.TenMon as 'Tên môn',mh.HeSo as 'Hệ số' from MONHOC mh, CT_KHOILOP_MONHOC ctklmh, KHOILOP_MONHOC klmh,LOP lop where mh.MaMon=ctklmh.MaMon and ctklmh.MaKLMH=klmh.MaKLMH and klmh.MaNam=@manam and klmh.MaKhoiLop=lop.MaKhoiLop and lop.MaLop=@malop";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@manam", manam);
            sp[1] = new SqlParameter("@malop",malop);
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql,sp);
            dt.TableName = "dts";
            return dt;
        }
        public DataTable SearchbyMa(string mamon) // tim hoc sinh theo ma mon
        {
            string sql = " select MaMon as 'Mã môn',TenMon as 'Tên Môn',HeSo as 'Hệ số' from MONHOC where MaMon=@mamon";// 
            DataTable dt = new DataTable();
            SqlParameter sp = new SqlParameter("@mamon", mamon);
            dt = conectData.LoadData(sql, sp);
            dt.TableName = "dts";
            return dt;
        }
        
        public DataTable SearchbyTen(string ten)
        {
            string sql = " select MaMon as 'Mã môn',TenMon as 'Tên Môn',HeSo as 'Hệ số' from MONHOC where TenMon like @ten";// 
            DataTable dt = new DataTable();
            SqlParameter sp = new SqlParameter("@ten", "%" + ten + "%");
            dt = conectData.LoadData(sql, sp);
            dt.TableName = "dts";
            return dt;
        }
        string kq;
        
        public string getMaMon() // lay ma mon
        {
            string sql = " SELECT MAX(cast(substring(MaMon,2,2) as int)) FROM MONHOC ";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == "NULL")
            {
                kq = "M" + "01";
            }
            else
            {
                int s = int.Parse(dt.Rows[0][0].ToString()) + 1;
                if (s < 10)
                    kq = "M" + "0" + s.ToString();
                else
                {
                    if (s < 100)
                        kq = "M" + s.ToString();

                }
            }
            return kq;
        }

        // cac ham select se duoc viet tiep o day.
    }
}
