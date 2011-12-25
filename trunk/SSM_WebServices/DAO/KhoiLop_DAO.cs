﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class KhoiLop_DAO
    {
        ConectData conectData = new ConectData();
        
        public int Insert(KhoiLopDTO Kl)
        {
            string sql = "insert into KHOILOP values (@MaKhoiLop,@TenKhoiLop,@SoLop)";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@MaKhoiLop", Kl.MaKhoiLop);
            sp[1] = new SqlParameter("@TenKhoiLop", Kl.TenKhoiLop);
            sp[2] = new SqlParameter("@SoLop", Kl.SoLop);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int Update(KhoiLopDTO Kl)
        {
            string sql = "update KHOILOP set TenKhoiLop=@TenKhoiLop,SoLop=@SoLop where MaKhoiLop=@MaKhoiLop";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@MaKhoiLop", Kl.MaKhoiLop);
            sp[1] = new SqlParameter("@TenKhoiLop", Kl.TenKhoiLop);
            sp[2] = new SqlParameter("@SoLop", Kl.SoLop);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public int Updatesolop(int solop, string makhoilop)
        {
            string sql = "update KHOILOP set SoLop=@SoLop where MaKhoiLop=@MaKhoiLop";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaKhoiLop", makhoilop);
            sp[1] = new SqlParameter("@SoLop", solop);
            return conectData.Insert_Update_Delete(sql, sp);
        }
            
        public int Delete(string makhoilop)
        {
            string sql = "delete from KHOILOP where MaKhoiLop=@MaKhoiLop";
            SqlParameter sp = new SqlParameter("@MaKhoiLop", makhoilop);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        
        public DataTable List()
        {
            string sql = "select MaKhoiLop as 'Mã khối',TenKhoiLop as 'Tên khối',SoLop as 'Số lớp' from KHOILOP";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            dt.TableName = "dts";
            return dt;
        }
        string kq;
        
        public string getMa() // lay ma mon
        {
            string sql = " SELECT MAX(cast(substring(MaKhoiLop32,2) as int)) FROM KHOILOP ";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == "NULL")
            {
                kq = "KL" + "01";
            }
            else
            {
                int s = int.Parse(dt.Rows[0][0].ToString()) + 1;
                if (s < 10)
                    kq = "KL" + "0" + s.ToString();
                else
                {
                    if (s < 100)
                        kq = "KL" + s.ToString();

                }
            }
            return kq;
        }

        // cac ham select se duoc viet tiep o day.
    }
}