using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
  public class CT_ToDTO
    {
        private string _MaTo;

        public string MaTo
        {
            get { return _MaTo; }
            set { _MaTo = value; }
        }
        private string _MaMon;

        public string MaMon
        {
            get { return _MaMon; }
            set { _MaMon = value; }
        }
        //public CT_ToDTO(string _mato, string _mamon)
        //{
        //    _MaTo = _mato;
        //    _MaMon = _mamon;
        //}
    }
}
