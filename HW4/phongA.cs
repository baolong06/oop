using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4
{
    class phongA : phong
    {
        protected int dichvu;
        public phongA(int songay) : base(songay)
        {
            Console.WriteLine("nhap so tien dich vu: ");
            dichvu = int.Parse(Console.ReadLine());
        }
        public override double tinhTien()
        {
            if (songay < 5)
            {
                return songay * 80 + dichvu;
            }
            else
            {
                return 5* 80 + (songay - 5) * 80 * 0.9 + dichvu;
            }
        }
        public override void xuat()
        {
            Console.WriteLine("loai phong A, so ngay thue: {0}, tien dich vu: {1}, tong tien: {2}", songay, dichvu, tinhTien());
        }
    }
}
