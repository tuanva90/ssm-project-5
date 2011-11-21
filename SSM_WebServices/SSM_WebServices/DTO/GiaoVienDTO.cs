using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class GiaoVienDTO
    {
        private string _MaGV;

        public string MaGV
        {
            get { return _MaGV; }
            set { _MaGV = value; }
        }
        private string _HoTen;

        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }
        private int _GioiTinh;

        public int GioiTinh
        {
            get { return _GioiTinh; }
            set { _GioiTinh = value; }
        }
        private string _SoDienThoai;

        public string SoDienThoai
        {
            get { return _SoDienThoai; }
            set { _SoDienThoai = value; }
        }
        private string _ChuyenNghanh;

        public string ChuyenNghanh
        {
            get { return _ChuyenNghanh; }
            set { _ChuyenNghanh = value; }
        }
        private string _TrinhDoChuyenMon;

        public string TrinhDoChuyenMon
        {
            get { return _TrinhDoChuyenMon; }
            set { _TrinhDoChuyenMon = value; }
        }
        private string _SoTruong;

        public string SoTruong
        {
            get { return _SoTruong; }
            set { _SoTruong = value; }
        }
        private string _MaTo;

        public string MaTo
        {
            get { return _MaTo; }
            set { _MaTo = value; }
        }
        //public GiaoVienDTO(string _magv, string _hoten, int _gioitinh, string _sodienthoai, string _chuyennganh, string _trindochuyenmon, string _sotruong, string _mato)
        //{
        //    _MaGV = _magv;
        //    _HoTen = _hoten;
        //    _GioiTinh = _gioitinh;
        //    _SoDienThoai = _sodienthoai;
        //    _ChuyenNghanh = _chuyennganh;
        //    _TrinhDoChuyenMon = _trindochuyenmon;
        //    _SoTruong = _sotruong;
        //    _MaTo = _mato;
        //}
    }
}
