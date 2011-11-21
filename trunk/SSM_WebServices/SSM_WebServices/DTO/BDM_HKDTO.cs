using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public class BDM_HKDTO
    {

        private string _MaBDM_HK;

        public string MaBDM_HK
        {
            get { return _MaBDM_HK; }
            set { _MaBDM_HK = value; }
        }
        private string _MaHoc;

        public string MaHoc
        {
            get { return _MaHoc; }
            set { _MaHoc = value; }
        }
        private string _MaMonHoc;

        public string MaMonHoc
        {
            get { return _MaMonHoc; }
            set { _MaMonHoc = value; }
        }
        private float _DTBMon_HK;

        public float DTBMon_HK
        {
            get { return _DTBMon_HK; }
            set { _DTBMon_HK = value; }
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
