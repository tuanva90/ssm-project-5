using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class To_DAO
    {
        ConectData conectData = new ConectData();
        
        public int Insert(ToDTO To)
        {
            string sql = "insert into TOCM values (@MaTo,@TenTo)";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaTo", To.MaTo);
            sp[1] = new SqlParameter("@TenTo", To.TenTo);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int Update(ToDTO To)
        {
            string sql = "update TOCM set TenTo=@TenTo where MaTo=@MaTo";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaTo", To.MaTo);
            sp[1] = new SqlParameter("@TenTo", To.TenTo);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int Delete(string mato)
        {
            string sql = "delete from TOCM where MaTo=@MaTo";
            SqlParameter sp = new SqlParameter("@MaTo", mato);
            return conectData.Insert_Update_Delete(sql, sp);
        }
            
        public DataTable List()
        {
            string sql = "select MaTo as 'Mã tổ',TenTo as 'Tên tổ' from TOCM";
            DataTable dt = conectData.LoadData(sql);
            dt.TableName = "dt";
            if (dt.Rows.Count == 0)
                return null;
            else
                return dt;
        }
        
        public DataTable SearchMaTo(string mato) // tim hoc sinh theo ma to
        {
            string sql = " select MaTo as 'Mã tổ',TenTo as 'Tên tổ' from TOCM where MaTo=@mato";// 
            DataTable dt = new DataTable();
            SqlParameter sp = new SqlParameter("@mato", mato);
            dt = conectData.LoadData(sql, sp);
            dt.TableName = "dts";
            if (dt.Rows.Count == 0)
                return null;
            else
                return dt;
        }
            
        public DataTable SearchbyTenTo(string tento)
        {
            string sql = " select MaTo as 'Mã tổ',TenTo as 'Tên tổ' from TOCM where TenTo like @tento";// 
            DataTable dt = new DataTable();
            SqlParameter sp = new SqlParameter("@tento", "%" + tento + "%");
            dt = conectData.LoadData(sql, sp);
            dt.TableName = "dts";
            return dt;
        }
        string kq;
        
        public string getMaTo() // lay ma to
        {
            string sql = " SELECT MAX(cast(substring(MaTo,2,2) as int)) FROM TOCM ";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == "NULL")
            {
                kq = "T" + "01";
            }
            else
            {
                int s = int.Parse(dt.Rows[0][0].ToString()) + 1;
                if (s < 10)
                    kq = "T" + "0" + s.ToString();
                else
                {
                    if (s < 100)
                        kq = "T" + s.ToString();

                }
            }
            return kq;
        }

        // cac ham select se duoc viet tiep o day.
    }
}
