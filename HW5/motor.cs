using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5
{
    internal class motor:Imotor
    {
        private string ma;
        private string ten;
        private double capacity;
        private int num;
        public string Ma { get => ma; set => ma = value; }
        public string Ten { get => ten; set => ten = value; }
        public double Capacity { get => capacity; set => capacity = value; }
        public int Num { get => num; set => num = value; }
        public virtual void nhap()
        {
            try
            {
                thaydoi();
            } catch 
            {
                Console.WriteLine("Nhap sai dinh dang, vui long nhap lai!");
                thaydoi();
            }
        }
        public virtual void xuat()
        {
            Console.WriteLine("Ma xe: " + Ma);
            Console.WriteLine("Ten xe: " + Ten);
            Console.WriteLine("Dung tich xe: " + Capacity);
            Console.WriteLine("So luong xe: " + Num);
        }
        public virtual void thaydoi()
        {
            Console.Write("Nhap ma xe moi: ");
            Ma = Console.ReadLine();
            Console.Write("Nhap ten xe moi: ");
            Ten = Console.ReadLine();
            Console.Write("Nhap dung tich xe moi: ");
            Capacity = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nhap so luong xe moi: ");
            Num = Convert.ToInt32(Console.ReadLine());
        }
    }
}
