using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class ToDTO
    {
          private string _MaTo;

        public string MaTo
        {
            get { return _MaTo; }
            set { _MaTo = value; }
        }
        private string _TenTo;

        public string TenTo
        {
            get { return _TenTo; }
            set { _TenTo = value; }
        }
        //public ToDTO(string _mato, string _tento)
        //{
        //    _MaTo = _mato;
        //    _TenTo = _tento;
        //}
    }
}
