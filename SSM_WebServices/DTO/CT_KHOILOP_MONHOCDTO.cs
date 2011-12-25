using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class CT_KHOILOP_MONHOCDTO
    {
        private int _MaCT_KLMH;

        public int MaCT_KLMh
        {
            get { return _MaCT_KLMH; }
            set { _MaCT_KLMH = value; }
        }
        private int _MaKLMH;

        public int MaKLMH
        {
            get { return _MaKLMH; }
            set { _MaKLMH = value; }
        }
        private string _MaMon;

        public string MaMon
        {
            get { return _MaMon; }
            set { _MaMon = value; }
        }


    }
}
