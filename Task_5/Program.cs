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
        private static void obrobka_x(ref double[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] < 0)
                {
                    x[i] = x[i] * (-1);
                }
            }
        }
        private static void obrobka_z(double[] x, double[] y, ref double[] z)
        {
            for (int i = 0; i < x.Length; i++)
            {
                z[i] = y[i] - x[i];
            }

        }
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string path_to_x = @"files\x.txt";

            double[] x = FileReading(path_to_x);

            Console.WriteLine("Масив файлу х.txt: ");
            Console.WriteLine(string.Join('|', x));

            obrobka_x(ref x);
            Console.WriteLine("Оброблений масив файлу х.txt: ");
            Console.WriteLine(string.Join('|', x));

            string path_to_y = @"files\y.txt";

            double[] y = FileReading(path_to_y);

            Console.WriteLine("Масив файлу у.txt: ");
            Console.WriteLine(string.Join('|', y));

            double[] z = new double[x.Length];

            obrobka_z(x, y, ref z);
            Console.WriteLine("Масив z: ");
            Console.WriteLine(string.Join('|', z));
        }
    }
}