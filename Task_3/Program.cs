using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int a = 0;
            double b = 0;
            long c = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine("введіть змінну типу int: ");
                    int a1 = Convert.ToInt32(Console.ReadLine());
                    a = a + a1;
                    break;
                }
                catch
                {
                    Console.WriteLine("Ви ввели некоректне значення!");
                    continue;
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("введіть змінну типу double: ");
                    double b1 = Convert.ToDouble(Console.ReadLine());
                    b = b + b1;
                    break;
                }
                catch
                {
                    Console.WriteLine("Ви ввели некоректне значення!");
                    continue;
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("введіть змінну типу long: ");
                    long c1 = Convert.ToInt64(Console.ReadLine());
                    c = c + c1;
                    break;
                }
                catch
                {
                    Console.WriteLine("Ви ввели некоректне значення!");
                    continue;
                }
            }
            Console.WriteLine($"a = {a}; b = {b}; с = {c}");
        }
    }
}