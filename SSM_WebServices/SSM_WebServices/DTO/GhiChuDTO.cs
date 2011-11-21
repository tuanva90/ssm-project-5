using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public class GhiChuDTO
    {
        private string _MaGC;

        public string MaGC
        {
            get { return _MaGC; }
            set { _MaGC = value; }
        }
        private string _MaHoc;

        public string MaHoc
        {
            get { return _MaHoc; }
            set { _MaHoc = value; }
        }
        private string _LyDo;

        public string LyDo
        {
            get { return _LyDo; }
            set { _LyDo = value; }
        }
        private string _ChiTiet;

        public string ChiTiet
        {
            get { return _ChiTiet; }
            set { _ChiTiet = value; }
        }
        //public GhiChuDTO(string _magc, string _mahoc, string _lydo, string _chitiet)
        //{
        //    _MaGC = _magc;
        //    _MaHoc = _mahoc;
        //    _LyDo = _lydo;
        //    _ChiTiet = _chitiet;
        //}
    }
}
