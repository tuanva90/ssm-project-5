using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class HocDTO
    {
        private string _MaHoc;

        public string MaHoc
        {
            get { return _MaHoc; }
            set { _MaHoc = value; }
        }
        private string _MaHS;

        public string MaHS
        {
            get { return _MaHS; }
            set { _MaHS = value; }
        }
        private string _MaLop;

        public string MaLop
        {
            get { return _MaLop; }
            set { _MaLop = value; }
        }
        private string _MaHK;

        public string MaHK
        {
            get { return _MaHK; }
            set { _MaHK = value; }
        }
        private float _DiemCuoiKy;

        public float DiemCuoiKy
        {
            get { return _DiemCuoiKy; }
            set { _DiemCuoiKy = value; }
        }
        private string _HKCuoiKy;

        public string HKCuoiKy
        {
            get { return _HKCuoiKy; }
            set { _HKCuoiKy = value; }
        }
        private string _ChucVu;

        public string ChucVu
        {
            get { return _ChucVu; }
            set { _ChucVu = value; }
        }
        //public HocDTO(string _mahoc, string _mahs, string _malop, string _mahk, float _diemcuoiky, string _hkcuoiky, string _chucvu)
        //{
        //    _MaHoc = _mahoc;
        //    _MaHS = _mahs;
        //    _MaLop = _malop;
        //    _MaHK = _mahk;
        //    _DiemCuoiKy = _diemcuoiky;
        //    _HKCuoiKy = _hkcuoiky;
        //    _ChucVu = _chucvu;
        //}
    }
}
