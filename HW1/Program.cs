using System;
namespace lai_suat
{
    class program
    {
        static void Main(string[] args)
        {
            string masv, hoten;
            float diem1, diem2, diem3;
            do
            {
                Console.Write("nhap ma sinh vien: ");
                masv = Console.ReadLine();
                Console.Write("nhap ho ten sinh vien: ");
                hoten = Console.ReadLine();
            } while (masv == "" || hoten == "");
            do
            {
                Console.Write("nhap diem mon 1: ");
                diem1 = float.Parse(Console.ReadLine());
                Console.Write("nhap diem mon 2: ");
                diem2 = float.Parse(Console.ReadLine());
                Console.Write("nhap diem mon 3: ");
                diem3 = float.Parse(Console.ReadLine());
            } while ((diem1 < 0 || diem1 > 10) || (diem2 < 0 || diem2 > 10) || (diem3 < 0 || diem3 > 10));
            Console.WriteLine("ma sinh vien la: {0}, ho ten sinh vien la {1}", masv, hoten);
            Console.WriteLine("diem mon 1 la: {0}, diem mon 2 la: {1}, diem mon 3 la: {2}", diem1, diem2, diem3);
            Console.ReadKey();
        }
    }
}
