using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class KhoiLopDTO
    {
        private string _MaKhoiLop;

        public string MaKhoiLop
        {
            get { return _MaKhoiLop; }
            set { _MaKhoiLop = value; }
        }
        private string _TenKhoiLop;

        public string TenKhoiLop
        {
            get { return _TenKhoiLop; }
            set { _TenKhoiLop = value; }
        }
        private int _SoLop;

        public int SoLop
        {
            get { return _SoLop; }
            set { _SoLop = value; }
        }
        private string _MaNam;
        public string MaNam
        {
            get { return _MaNam; }
            set { _MaNam = value; }
        }
        //public KhoiLopDTO(string _makhoilop, string _tenkhoilop, int _solop)
        //{
        //    _MaKhoiLop = _makhoilop;
        //    _TenKhoiLop = _tenkhoilop;
        //    _SoLop = _solop;
        //}
    }
}
