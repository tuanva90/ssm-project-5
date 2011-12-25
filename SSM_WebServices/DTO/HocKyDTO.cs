using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class HocKyDTO
    {
        private string _MaHK;

        public string MaHK
        {
            get { return _MaHK; }
            set { _MaHK = value; }
        }
        private string _HocKy;

        public string Ten_HocKy
        {
            get { return _HocKy; }
            set { _HocKy = value; }
        }
        private string _MaNam;

        public string MaNam
        {
            get { return _MaNam; }
            set { _MaNam = value; }
        }
        //public HocKyDTO(string _mahk, string _hocky, string _manam)
        //{
        //    _MaHK = _mahk;
        //    _HocKy = _hocky;
        //    _MaNam = _manam;
        //}
    }
}
