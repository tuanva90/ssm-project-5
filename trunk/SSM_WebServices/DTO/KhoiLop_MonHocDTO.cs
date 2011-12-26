using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public class KhoiLop_MonHocDTO
    {
        private int _MaKLMH;

        public int MaKLMH
        {
            get { return _MaKLMH; }
            set { _MaKLMH = value; }
        }
     
        private string _MaKL;

        public string MaKL
        {
            get { return _MaKL; }
            set { _MaKL = value; }
        }


    }
}
