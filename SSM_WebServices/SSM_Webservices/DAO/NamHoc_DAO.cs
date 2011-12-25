using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
   public class NamHoc_DAO
    {
        ConectData conectData = new ConectData();
        
        public int Insert(NamHocDTO Dt)
        {
            string sql = "insert into NAMHOC values (@MaNam,@NamHoc)";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaNam", Dt.MaNam);
            sp[1] = new SqlParameter("@NamHoc", Dt.Ten_NamHoc);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int Update(NamHocDTO Dt)
        {
            string sql = "update NAMHOC set NamHoc=@NamHoc where MaNam=@MaNam";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaNam", Dt.MaNam);
            sp[1] = new SqlParameter("@NamHoc", Dt.Ten_NamHoc);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int Delete(string manam)
        {
            string sql = "delete from NAMHOC where MaNam=@MaNam";
            SqlParameter sp = new SqlParameter("@MaNam", manam);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public DataTable List()
        {
            string sql = "select MaNam as 'Mã năm', NamHoc as 'Năm học' from NAMHOC order by (MaNam)DESC";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            dt.TableName = "dts";
            return dt;
        }
        string kq;
        
        public string getMa() // 
        {
            string sql = " SELECT MAX(cast(substring(MaNam,2,2) as int)) FROM NAMHOC ";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == "NULL")
            {
                kq = "N" + "01";
            }
            else
            {
                int s = int.Parse(dt.Rows[0][0].ToString()) + 1;
                if (s < 10)
                    kq = "N" + "0" + s.ToString();
                else
                {
                    if (s < 100)
                        kq = "N" + s.ToString();

                }
            }
            return kq;
        }
    }
}
