using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5
{
    public class yamaha
    {
        private Jupiter[] jupiters;
        private serius[] seriuses;
        private int n, m;
        public  void input()
        {
            try
            {
                Console.Write("Nhap so luong xe jupier: ");
                n = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Nhap sai dinh dang, vui long nhap lai!");
                Console.Write("Nhap so luong xe jupier: ");
                n = Convert.ToInt32(Console.ReadLine());

            }
            jupiters = new Jupiter[n];
            try
            {
                Console.Write("Nhap so luong xe serius: ");
                m = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Nhap sai dinh dang, vui long nhap lai!");
                Console.Write("Nhap so luong xe serius: ");
                m = Convert.ToInt32(Console.ReadLine());
            }
                seriuses = new serius[m];
            Console.WriteLine("Nhap thong tin xe jupier: ");
            for (int i = 0; i < n; i++)
            {
                jupiters[i] = new Jupiter();
                jupiters[i].nhap();
            }
            Console.WriteLine("Nhap thong tin xe serius: ");
            for (int i = 0; i < m; i++)
            {
                seriuses[i] = new serius();
                seriuses[i].nhap();
            }
        }
        public void display()
        {
            if (jupiters == null)
            {
                Console.WriteLine("Chua co thong tin xe jupiters");
            }
            else 
            { 

                Console.WriteLine("Thong tin xe jupier: ");
                for (int i = 0; i < n; i++)
                {
                    jupiters[i].xuat();
                }
            }
            if (seriuses == null)
            {
                Console.WriteLine("Chua co thong tin xe serius");
                return;
            }
            Console.WriteLine("Thong tin xe serius: ");
            for (int i = 0; i < m; i++)
            {
                seriuses[i].xuat();
            }
        }
        public void sort()
        {
            try
            {
                Console.WriteLine("thong tin xe jupier truoc khi sap xep: ");
                display();
                Array.Sort(jupiters, (x, y) => x.Warranty.CompareTo(y.Warranty));
                Console.WriteLine("Sap xep thanh cong");
                Console.WriteLine("thong tin xe jupier sau khi sap xep: ");
                display();
            }
            catch
            {
                Console.WriteLine("Chua co thong tin jupier de sap xep");
            }
            try
            {
                Console.WriteLine("thong tin xe serius truoc khi sap xep: ");
                display();
                Array.Sort(seriuses, (x, y) => x.Warranty.CompareTo(y.Warranty));
                Console.WriteLine("Sap xep thanh cong");
                Console.WriteLine("thong tin xe serius sau khi sap xep: ");
                display();
            }
            catch
            {
                Console.WriteLine("Chua co thong tin serius de sap xep");
            }
        }
        public void search()
        {
            Console.WriteLine("Nhap ten xe: ");
            string name = Console.ReadLine();
            for (int i = 0; i < n; i++)
            {
                if (jupiters[i].Ten == name)
                {
                    Console.WriteLine("Da Tim Thay");
                    jupiters[i].xuat();
                    return;
                }
            }
            for (int i = 0; i < m; i++)
            {
                if (seriuses[i].Ten == name)
                {
                    Console.WriteLine("Da Tim Thay");
                    seriuses[i].xuat();
                    return;
                }
            }
            Console.WriteLine("Khong Tim Thay");
        }
    }
}
