using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class HocSinhDTO
    {
        private string _MaHS;

        public string MaHS
        {
            get { return _MaHS; }
            set { _MaHS = value; }
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
        private string _HoTenCha;

        public string HoTenCha
        {
            get { return _HoTenCha; }
            set { _HoTenCha = value; }
        }
        private string _NgheNghiepCha;

        public string NgheNghiepCha
        {
            get { return _NgheNghiepCha; }
            set { _NgheNghiepCha = value; }
        }
        private string _HoTenMe;

        public string HoTenMe
        {
            get { return _HoTenMe; }
            set { _HoTenMe = value; }
        }
        private string _NgheNghiepMe;

        public string NgheNghiepMe
        {
            get { return _NgheNghiepMe; }
            set { _NgheNghiepMe = value; }
        }
        private string _NgaySinh;

        public string NgaySinh
        {
            get { return _NgaySinh; }
            set { _NgaySinh = value; }
        }
        private string _DiaChi;

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }


        //public HocSinhDTO(string _mahs, string _hoten, int _gioitinh, string _sodienthoai, string _hotencha, string _nghecha, string _hotenme, string _ngheme, DateTime _ngaysinh, string _diachi)
        //{
        //    _MaHS = _mahs;
        //    _HoTen = _hoten;
        //    _GioiTinh = _gioitinh;
        //    _SoDienThoai = _sodienthoai;
        //    _HoTenCha = _hotencha;
        //    _NgheNghiepCha = _nghecha;
        //    _HoTenMe = _hotenme;
        //    _NgheNghiepMe = _ngheme;
        //    _NgaySinh = _ngaysinh;
        //}
    }
}
