using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4
{
    class phongB : phong
    {
        public phongB(int songay) : base(songay)
        {
        }
        public override double tinhTien()
        {
            if (songay < 5)
            {
                return songay * 60;
            }
            else
            {
                return 5 * 60 + (songay - 5) * 60 * 0.9;
            }
        }
        public override void xuat()
        {
            Console.WriteLine("loai phong B, so ngay thue: {0}, tong tien: {1}", songay, tinhTien());
        }
    }
}
