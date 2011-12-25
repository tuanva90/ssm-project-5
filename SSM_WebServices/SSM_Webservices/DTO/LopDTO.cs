using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public class LopDTO
    {
        private string _MaLop;

        public string MaLop
        {
            get { return _MaLop; }
            set { _MaLop = value; }
        }
        private string _TenLop;

        public string TenLop
        {
            get { return _TenLop; }
            set { _TenLop = value; }
        }
        private string _MaKhoiLop;

        public string MaKhoiLop
        {
            get { return _MaKhoiLop; }
            set { _MaKhoiLop = value; }
        }
        private string _MaGVCN;

        public string MaGVCN
        {
            get { return _MaGVCN; }
            set { _MaGVCN = value; }
        }
        private int _SiSo;

        public int SiSo
        {
            get { return _SiSo; }
            set { _SiSo = value; }
        }
        //public LopDTO(string _malop, string _tenlop, string _makhoilop, string _magvcn, int _siso)
        //{
        //    _MaLop = _malop;
        //    _TenLop = _tenlop;
        //    _MaKhoiLop = _makhoilop;
        //    _MaGVCN = _magvcn;
        //    _SiSo = _siso;
        //}
    }
}
