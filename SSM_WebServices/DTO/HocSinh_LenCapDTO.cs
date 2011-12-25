using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class HocSinh_LenCapDTO
    {
        private string _MaHS_LC;

        public string MaHS_LC
        {
            get { return _MaHS_LC; }
            set { _MaHS_LC = value; }
        }
        private string _MaHS;

        public string MaHS
        {
            get { return _MaHS; }
            set { _MaHS = value; }
        }
        private float _DTB;

        public float DTB
        {
            get { return _DTB; }
            set { _DTB = value; }
        }
        private string _HanhKiem;

        public string HanhKiem
        {
            get { return _HanhKiem; }
            set { _HanhKiem = value; }
        }
        //public HocSinh_LenCapDTO(string _mahs_lc, string _mahs, float _dtb, string _hanhkiem)
        //{
        //    _MaHS = _mahs;
        //    _MaHS_LC = _mahs_lc;
        //    _DTB = _dtb;
        //    _HanhKiem = _hanhkiem;
        //}
    }
}
