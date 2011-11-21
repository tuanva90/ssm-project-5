using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class CT_BDM_HKDTO
    {
        private string _MaCT_BDM_HK;

        public string MaCT_BDM_HK
        {
            get { return _MaCT_BDM_HK; }
            set { _MaCT_BDM_HK = value; }
        }
        private string _MaBD_HK;

        public string MaBD_HK
        {
            get { return _MaBD_HK; }
            set { _MaBD_HK = value; }
        }
        private float _Diem;

        public float Diem
        {
            get { return _Diem; }
            set { _Diem = value; }
        }
        private int _HeSo;

        public int HeSo
        {
            get { return _HeSo; }
            set { _HeSo = value; }
        }
        //public CT_BDM_HKDTO(string _mact_bdm_hk, string _mabd_hk, float _diem, int _heso)
        //{
        //    _MaCT_BDM_HK = _mact_bdm_hk;
        //    _MaBD_HK = _mabd_hk;
        //    _HeSo = _heso;
        //    _Diem = _diem;
        //}
    }
}
