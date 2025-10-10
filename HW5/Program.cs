using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            yamaha yamaha = new yamaha();
            while (true) 
            {
                Console.Clear();
                Console.WriteLine("1. Nhap thong tin xe");
                Console.WriteLine("2. Hien thi thong tin xe");
                Console.WriteLine("3. Sap xep thong tin xe");
                Console.WriteLine("4. Tim kiem thong tin xe");
                Console.WriteLine("6. Thoat");
                Console.Write("Chon chuc nang: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
                {
                    Console.Write("Chon chuc nang: ");
                }
                switch (choice)
                {
                    case 1:
                        yamaha.input();
                        Console.ReadKey();
                        break;
                    case 2:
                        yamaha.display();
                        Console.ReadKey();
                        break;
                    case 3:
                        yamaha.sort();
                        Console.ReadKey();
                        break;
                    case 4:
                        yamaha.search();
                        Console.ReadKey();
                        break;
                    case 5:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
