using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class CT_BDM_HKDTO
    {
        private int _MaCT_BDM_HK;

        public int MaCT_BDM_HK
        {
            get { return _MaCT_BDM_HK; }
            set { _MaCT_BDM_HK = value; }
        }
        private int _MaBD_HK;

        public int MaBD_HK
        {
            get { return _MaBD_HK; }
            set { _MaBD_HK = value; }
        }
        private string _Diem15Phut;

        public string Diem15Phut
        {
            get { return _Diem15Phut; }
            set { _Diem15Phut = value; }
        }
        private string _DiemMieng;

        public string DiemMieng
        {
              get { return _DiemMieng; }
          set { _DiemMieng = value; }
        }
        private string _Diem1Tiet;

        public string Diem1Tiet
        {
            get { return _Diem1Tiet; }
            set { _Diem1Tiet = value; }
        }
        private string _DiemHK;

        public string DiemHK
        {
            get { return _DiemHK; }
            set { _DiemHK = value; }
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
