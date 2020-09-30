using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть число типу int: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть число типу double: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введіит число типу long: ");
            long c = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("a = {a}; b = {b}; c = {c}");


        }
    }
}
