using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4
{
    abstract class phong
    {
        protected int songay;
        public phong(int songay)
        {
            this.songay = songay;
        }
        public abstract double tinhTien();
        public abstract void xuat();
    }
}
