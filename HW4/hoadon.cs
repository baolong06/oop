using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4
{
    class hoadon
    {
        private string tenkhachang;
        private int songay;
        private phong loaiphong;
        public void nhap()
        {
            Console.WriteLine("nhap ten khach hang: ");
            tenkhachang = Console.ReadLine();
            Console.WriteLine("nhap so ngay thue: ");
            songay = int.Parse(Console.ReadLine());
            Console.WriteLine("chon loai phong (A, B, C): ");
            char loai = char.Parse(Console.ReadLine());
            switch (loai)
            {
                case 'A':
                    loaiphong = new phongA(songay);
                    break;
                case 'B':
                    loaiphong = new phongB(songay);
                    break;
                case 'C':
                    loaiphong = new phongC(songay);
                    break;
                default:
                    Console.WriteLine("loai phong khong hop le");
                    break;
            }
        }
        public void xuat()
        {
            Console.WriteLine("-----hoa don-----");
            Console.WriteLine("ten khach hang: {0}", tenkhachang);
            loaiphong.xuat();
        }
    }
}
