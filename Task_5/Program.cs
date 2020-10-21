using System;
using System.IO;

namespace Task_5
{
    class Program
    {
        private static double[] FileReading(string path_to)
        {
            string[] file_nums = File.ReadAllText(path_to).Split(",");
            double[] arr = new double[file_nums.Length];
            for (int i = 0; i < file_nums.Length; i++)
            {
                try
                {
                    arr[i] = Convert.ToDouble(file_nums[i]);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Некоректні дані у файлі");
                    Environment.Exit(0);
                }
            }
            return arr;
        }
        private static double[] obrobka_x(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    arr[i] = arr[i] * (-1);
                }

            }
            return arr;
        }
        private static double[] obrobka_z(double[] x, double[] y, double[] z)
        {
            for (int i = 0; i < x.Length; i++)
            {
                z[i] = y[i] - x[i];
            }
            return z;
        }
        
        static void Main(string[] args)
        {
            string path_to_x = @"D:\OOP_1\Task_5\files\x.txt";

            double[] x = FileReading(path_to_x);
            Console.WriteLine("Масив файлу х.txt: ");
            Console.WriteLine(string.Join('|', x));

            x = obrobka_x(x);
            Console.WriteLine("Оброблений масив файлу х.txt: ");
            Console.WriteLine(string.Join('|', x));

            string path_to_y = @"D:\OOP_1\Task_5\files\y.txt";

            double[] y = FileReading(path_to_y);
            Console.WriteLine("Масив файлу у.txt: ");
            Console.WriteLine(string.Join('|', y));

            double[] z = new double[x.Length];
            double[] new_z = obrobka_z(x, y, z);
            Console.WriteLine("Масив z: ");
            Console.WriteLine(string.Join('|', new_z));
        }
    }
}