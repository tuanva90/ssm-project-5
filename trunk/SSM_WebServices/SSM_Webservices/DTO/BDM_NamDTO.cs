using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public class BDM_NamDTO
    {
        private int _MaBDM_Nam;

        public int MaBDM_Nam
        {
            get { return _MaBDM_Nam; }
            set { _MaBDM_Nam = value; }
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
        private int _CT_KLMH;

        public int CT_KLMH
        {
            get { return _CT_KLMH; }
            set { _CT_KLMH = value; }
        }

        private float _DTBMon_Nam;

        public float DTBMon_Nam
        {
            get { return _DTBMon_Nam; }
            set { _DTBMon_Nam = value; }
        }
        private string _MaNam;

        public string MaNam
        {
            get { return _MaNam; }
            set { _MaNam = value; }
        }

        //public BDM_NamDTO(string _mabdm_nam, string _mahs, string _malop, string _mamon, float _dtbmon_nam)
        //{
        //    _MaBDM_Nam = _mabdm_nam;
        //    _MaHS = _mahs;
        //    _MaLop = _malop;
        //    _MaMon = _mamon;
        //    _DTBMon_Nam = _dtbmon_nam;
        //}
    }
}
