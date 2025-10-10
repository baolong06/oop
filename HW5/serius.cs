using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5
{
    class serius : motor
    {
        private int warranty; // in months
        public int Warranty { get => warranty; set => warranty = value; }
        public override void nhap()
        {
            try
            {
                base.thaydoi();
                Console.Write("Nhap thoi gian bao hanh (thang): ");
                Warranty = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Nhap sai dinh dang, vui long nhap lai!");
                thaydoi();
            }
        }
        public override void xuat()
        {
            base.xuat();
            Console.WriteLine("Thoi gian bao hanh (thang): " + Warranty);
        }
        public override void thaydoi()
        {
            base.thaydoi();
            Console.Write("Nhap thoi gian bao hanh moi (thang): ");
            Warranty = Convert.ToInt32(Console.ReadLine());
        }
    }
}
