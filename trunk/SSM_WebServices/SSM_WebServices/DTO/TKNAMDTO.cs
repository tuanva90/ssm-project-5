using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class TKNAMDTO
    {
        private string _MaTKN;

        public string MaTKN
        {
            get { return _MaTKN; }
            set { _MaTKN = value; }
        }
        private string _MaHS;

        public string MaHS
        {
            get { return _MaHS; }
            set { _MaHS = value; }
        }
        private float _DiemCuoiNam;

        public float DiemCuoiNam
        {
            get { return _DiemCuoiNam; }
            set { _DiemCuoiNam = value; }
        }
        private string _HKCuoiNam;

        public string HKCuoiNam
        {
            get { return _HKCuoiNam; }
            set { _HKCuoiNam = value; }
        }
        private string _MaNam;

        public string MaNam
        {
            get { return _MaNam; }
            set { _MaNam = value; }
        }
        //public TKNAMDTO(string _matkn, string _mahs, float _diemcuoinam, string _hkcuoinam, string _manam)
        //{
        //    _MaTKN = _matkn;
        //    _MaHS = _mahs;
        //    _DiemCuoiNam = _diemcuoinam;
        //    _HKCuoiNam = _hkcuoinam;
        //    _MaNam = _manam;
        //}
    }
}
