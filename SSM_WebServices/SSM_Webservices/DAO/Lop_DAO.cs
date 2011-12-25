using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class Lop_DAO
    {
        public Lop_DAO()
        {
        }
        ConectData conectData = new ConectData();
        public int Insert(LopDTO Lop1)
        {
            string sql = "insert into LOP values (@MaLop,@TenLop,@MaKhoiLop,@SiSo,@MaGVCN)";
            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@MaLop", Lop1.MaLop);
            sp[1] = new SqlParameter("@TenLop", Lop1.TenLop);
            sp[2] = new SqlParameter("@MaKhoiLop", Lop1.MaKhoiLop);
            sp[3] = new SqlParameter("@SiSo", Lop1.SiSo);
            sp[4] = new SqlParameter("@MaGVCN", Lop1.MaGVCN);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int Update(string MaLop, string TenLop, string MaGVCN)
        {
            string sql = "update LOP set TenLop=@TenLop,MaGVCN=@MaGVCN where MaLop=@MaLop";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@MaLop", MaLop);
            sp[1] = new SqlParameter("@TenLop", TenLop);
            sp[2] = new SqlParameter("@MaGVCN", MaGVCN);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public string getTenLop(string malop)
        {
            string sql = "select TenLop as 'Tên lớp' from LOP where MaLop=@malop";
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@malop", malop);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt.Rows.Count == 0)
            {
                return "NULL";
            }
            else
            {
                return dt.Rows[0][0].ToString();
            }
        }
        public int UpdateSiso(int siso, string malop)
        {
            string sql = "update LOP set SiSo=@SiSo where MaLop=@MaLop";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaLop", malop);
            sp[1] = new SqlParameter("@SiSo", siso);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int Delete(string malop)
        {
            string sql = "delete from LOP where MaLop=@malop";
            SqlParameter sp = new SqlParameter("@malop", malop);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public DataTable List()
        {
            string sql = "select l.MaLop as 'Mã lớp',l.TenLop as 'Tên Lớp',l.SiSo as 'Sĩ số',l.MaGVCN as 'Mã GVCN',(select gv.HoTen from GIAOVIEN gv where gv.MaGV = l.MaGVCN ) as 'GVCN' from LOP l ";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            dt.TableName = "dts";
            return dt;
        }
        public DataTable ListbyNamHoc(string namhoc)//lay danh sach cac lop hoc theo năm
        {
            string sql = "select distinct l.MaLop as 'Mã lớp',l.TenLop as 'Tên Lớp',l.SiSo as 'Sĩ số',l.MaGVCN as 'Mã GVCN',(select gv.HoTen from GIAOVIEN gv where gv.MaGV = l.MaGVCN ) as 'GVCN' from LOP l, HOC hoc, HOCKY hk where l.MaLop=hoc.MaLop and hoc.MaHK=hk.MaHK and hk.MaNam=@manam ";
            SqlParameter sp = new SqlParameter("@manam", namhoc);
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql,sp);
            dt.TableName = "dts";
            return dt;
        }
        public DataTable Searchbymakl(string makl)// lanh danh sach lop theo ma khoi lop!
        {
            string sql = "select l.MaLop as 'Mã lớp',l.TenLop as 'Tên Lớp',l.SiSo as 'Sĩ số',l.MaGVCN as 'Mã GVCN',(select gv.HoTen from GIAOVIEN gv where gv.MaGV = l.MaGVCN ) as 'GVCN' from LOP l where l.MaKhoiLop=@makl";
            DataTable dt = new DataTable();
            SqlParameter sp = new SqlParameter("@makl", makl);
            dt = conectData.LoadData(sql, sp);
            dt.TableName = "dts";
            return dt;
        }
        public string SearchMakl(string malop)// tim ma khoi lop tu ma lop
        {
            string sql = "select MaKhoiLop from LOP where MaLop=@malop";
            SqlParameter sp = new SqlParameter("@malop", malop);
            DataTable dt = conectData.LoadData(sql, sp);
            return dt.Rows[0][0].ToString();

        }
        string kq;
        public string getMa() // lay ma
        {
            string sql = " SELECT MAX(cast(substring(MaLop,2,2) as int)) FROM LOP ";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == "NULL")
            {
                kq = "L" + "01";

            }
            else
            {
                int s = int.Parse(dt.Rows[0][0].ToString()) + 1;
                if (s < 10)
                    kq = "L" + "0" + s.ToString();
                else
                {
                    if (s < 100)
                        kq = "L" + s.ToString();

                }
            }
            return kq;
        }
    }
}
