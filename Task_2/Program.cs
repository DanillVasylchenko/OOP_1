using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            Console.WriteLine("Введіть число типу int: ");
            s = Console.ReadLine();
            int a = Convert.ToInt32(s);
            Console.WriteLine("Введіть число типу double: ");
            s = Console.ReadLine();
            double b = Convert.ToDouble(s);
            Console.WriteLine("Введіит число типу long: ");
            s = Console.ReadLine();
            long c = Convert.ToInt64(s);

            Console.WriteLine($"a = {a}; b = {b}; c = {c}");


        }
    }
}
