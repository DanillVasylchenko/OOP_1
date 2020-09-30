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
                    a = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви ввели некоректне значення!");
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("введіть змінну типу double: ");
                    b = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви ввели некоректне значення!");
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("введіть змінну типу long: ");
                    c = Convert.ToInt64(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви ввели некоректне значення!");
                }
            }
            Console.WriteLine($"a = {a}; b = {b}; с = {c}");
        }
    }
}