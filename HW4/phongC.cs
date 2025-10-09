using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4
{
    class phongC : phong
    {
        public phongC(int songay) : base(songay)
        {
        }
        public override double tinhTien()
        {
            return songay * 40;
        }
        public override void xuat()
        {
            Console.WriteLine("loai phong C, so ngay thue: {0}, tong tien: {1}", songay, tinhTien());
        }
    }
}
