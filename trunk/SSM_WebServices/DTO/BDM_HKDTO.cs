using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public class BDM_HKDTO
    {

        private int _MaBDM_HK;

        public int MaBDM_HK
        {
            get { return _MaBDM_HK; }
            set { _MaBDM_HK = value; }
        }
        private int _MaHoc;

        public int MaHoc
        {
            get { return _MaHoc; }
            set { _MaHoc = value; }
        }
        private int _CT_KLMH;

        public int CT_KLMH
        {
            get { return _CT_KLMH; }
            set { _CT_KLMH = value; }
        }

       private float _DTBMon_HK;

        public float DTBMon_HK
        {
            get { return _DTBMon_HK; }
            set { _DTBMon_HK = value; }
        }
        private float _DTBMon_KT;

        public float DTBMon_KT
        {
            get { return _DTBMon_KT; }
            set { _DTBMon_KT = value; }
        }

        //public BDM_HKDTO(string _mabdm_hk, string _mahoc, string _mamonhoc, float _dtbmon_hk)
        //{
        //    _MaBDM_HK = _mabdm_hk;
        //    _MaHoc = _mahoc;
        //    _MaMonHoc = _mamonhoc;
        //    _DTBMon_HK = _dtbmon_hk;
        //}
    }
}
