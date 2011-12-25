using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class MonHocDTO
    {
         private string _MaMon;

        public string MaMon
        {
            get { return _MaMon; }
            set { _MaMon = value; }
        }
        private string _TenMon;

        public string TenMon
        {
            get { return _TenMon; }
            set { _TenMon = value; }
        }
        private int _HeSo;

        public int HeSo
        {
            get { return _HeSo; }
            set { _HeSo = value; }
        }
        //public MonHocDTO(string _mamon, string _tenmon)
        //{
        //    _MaMon = _mamon;
        //    _TenMon = _tenmon;

        //}
    }
}
