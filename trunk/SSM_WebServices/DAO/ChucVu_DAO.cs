using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
   public  class ChucVu_DAO
    {
        ConectData conectData = new ConectData();

        public int Insert(ChucVuDTO cv)
        {
            string sql = "insert into CHUCVU values (@macv,@chucvu)";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@macv", cv.MaCV);
            sp[1] = new SqlParameter("@chucvu", cv.ChucVu);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int Update(ChucVuDTO cv)
        {
            string sql = "update CHUCVU set ChucVu=@chucvu where MaCV=@macv";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@macv", cv.MaCV);
            sp[1] = new SqlParameter("@chucvu", cv.ChucVu);
            return conectData.Insert_Update_Delete(sql, sp);
        }
      
        public int Delete(string macv)
        {
            string sql = "delete from CHUCVU where MaCV not in ('CV01','CV02') and MaCV=@macv"; // mot lop se maac dinh la co lop truong(cv02) va thanh vien thong thuong(cv01), khong cho xoa 2 cai này
            SqlParameter sp = new SqlParameter("@macv", macv);
            return conectData.Insert_Update_Delete(sql, sp);
        }
     
        public DataTable List()
        {
            string sql = "select MaCV as 'Mã CV', ChucVu as 'Chức vụ' from CHUCVU";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            dt.TableName = "dts";
            return dt;
        }

        string kq;
        public string getMa() // lay ma mon
        {
            string sql = " SELECT MAX(cast(substring(MaCV,3,2) as int)) FROM CHUCVU ";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == "NULL")
            {
                kq = "CV" + "01";
            }
            else
            {
                int s = int.Parse(dt.Rows[0][0].ToString()) + 1;
                if (s < 10)
                    kq = "CV" + "0" + s.ToString();
                else
                {
                    if (s < 100)
                        kq = "CV" + s.ToString();

                }
            }
            return kq;
        }
    }
}
