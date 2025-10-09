using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            hoadon hd = new hoadon();
            hd.nhap();
            Console.Clear();
            hd.xuat();
            Console.ReadKey();
        }
    }
}
