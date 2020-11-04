using System;
using System.Security.Cryptography.X509Certificates;

namespace Task_4
{
    class Times
    {
        private int[] time;
        public int[] Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
        public int[] TimePointCreator(string hours = "0", string minutes = "0", string seconds = "0")
        {
            string[] arr_str = { hours, minutes, seconds };
            int[] arr = new int[arr_str.Length];
            for (int i = 0; i < arr_str.Length; i++)
            {
                try
                {
                    Convert.ToUInt32(arr_str[i]);
                    arr[i] = Convert.ToInt32(arr_str[i]);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Некоректні дані у файлі");
                    Environment.Exit(0);
                }
            }
            arr[1] = arr[1] + arr[2] / 60;
            arr[2] = arr[2] % 60;
            arr[0] = arr[0] + arr[1] / 60;
            arr[1] = arr[1] % 60;
            Time = arr;
            return Time;
        }
        public int[] TimeSubtraction(int[] time_1, int[] time_2)
        {
            time_1 = new int[] { time_1[0], time_1[1], time_1[2] };
            int[] arr = new int[3];
            for (int i = 2; i >= 0; i--)
            {
                arr[i] = time_1[i] - time_2[i];
                if (arr[i] < 0 & i > 0)
                {
                    arr[i] = arr[i] + 60;
                    --time_1[i - 1];
                }
            }
            return arr;
        }
        public int[] TimeAddition(int[] time_1, int[] time_2)
        {
            time_1 = new int[] {time_1[0], time_1[1], time_1[2] };
            int[] arr = new int[3];
            for (int i = 2; i >= 0; i--)
            {
                arr[i] = time_1[i] + time_2[i];
                if (arr[i] >= 60 & i > 0)
                {
                    arr[i] = arr[i] - 60;
                    ++time_1[i - 1];
                }
            }
            return arr;
        }
        public int ConverterToSeconds(int[] time)
        {
            return time[0] * 60 * 60 + time[1] * 60 + time[2];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Введіть першу часову точку: ");
            Console.WriteLine(" ");

            Console.WriteLine("Введіть години: ");
            string hours = Console.ReadLine();
            Console.WriteLine("Введіть хвилини: ");
            string minutes = Console.ReadLine();
            Console.WriteLine("Введіть секунди: ");
            string seconds = Console.ReadLine();

            Times times = new Times();
            int[] timespan_1 = times.TimePointCreator(hours, minutes, seconds);

            Console.WriteLine("");
            Console.WriteLine("Введіть другу часову точку: ");
            Console.WriteLine("");

            Console.WriteLine("Введіть години: ");
            string hours_2 = Console.ReadLine();
            Console.WriteLine("Введіть хвилини: ");
            string minutes_2 = Console.ReadLine();
            Console.WriteLine("Введіть секунди: ");
            string seconds_2 = Console.ReadLine();

            int[] timespan_2 = times.TimePointCreator(hours_2, minutes_2, seconds_2);

            Console.WriteLine("");
            Console.WriteLine("Введіть часову точку лише у секундах: ");
            Console.WriteLine("");

            string seconds_only = Console.ReadLine();
            int[] timespan_sec = times.TimePointCreator(seconds: seconds_only);
 
            Console.WriteLine($"Ваші часові точки: \n1 - {timespan_1[0]}:{timespan_1[1]}:{timespan_1[2]}\n2 - {timespan_2[0]}:{timespan_2[1]}:{timespan_2[2]}");

            Console.WriteLine($"Результат додавання часових точок: {String.Join(":",times.TimeAddition(timespan_1, timespan_2))}");
            Console.WriteLine($"Результат віднімання часових точок: {String.Join(":", times.TimeSubtraction(timespan_1, timespan_2))}");
            Console.WriteLine($"Результат переведення часу першої точки у секундний формат: {times.ConverterToSeconds(timespan_1)}");
            Console.WriteLine($"Результат переведення часу другої точки у секундний формат: {times.ConverterToSeconds(timespan_2)}");

            Console.WriteLine($"Результат переведення часу точки з секундного формату у ГОДИНИ:ХВИЛИНИ:СЕКУНДИ - " +
                $"{timespan_sec[0]}:{timespan_sec[1]}:{timespan_sec[2]}");
        }
    }
}