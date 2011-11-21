using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class NamHocDTO
    {
        private string _MaNam;

        public string MaNam
        {
            get { return _MaNam; }
            set { _MaNam = value; }
        }
        private string _NamHoc;

        public string Ten_NamHoc
        {
            get { return _NamHoc; }
            set { _NamHoc = value; }
        }
        //public NamHocDTO(string _manam, string _namhoc)
        //{
        //    _MaNam = _manam;
        //    _NamHoc = _namhoc;
        //}
    }
}
