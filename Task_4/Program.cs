using System;
using System.Security.Cryptography.X509Certificates;

namespace Task_4
{
    class Times
    {
        private TimeSpan time;
        public TimeSpan Time
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
        public TimeSpan TimePointCreator(string hours = "0", string minutes = "0", string seconds = "0")
        {
            string[] arr_str = { hours, minutes, seconds };
            for (int i = 0; i < arr_str.Length; i++)
            {
                try
                {
                    Convert.ToUInt32(arr_str[i]);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Некоректні дані у файлі");
                    Environment.Exit(0);
                }
            }
            Time = new TimeSpan(Convert.ToInt32(hours), Convert.ToInt32(minutes), Convert.ToInt32(seconds));
            return Time;
        }
        public TimeSpan TimeSubtraction(TimeSpan timespan_1, TimeSpan timespan_2)
        {
            return timespan_1 - timespan_2;
        }
        public TimeSpan TimeAddition(TimeSpan timespan_1, TimeSpan timespan_2)
        {
            return timespan_1 + timespan_2;
        }
        public double ConverterToSeconds(TimeSpan timespan)
        {
            return timespan.TotalSeconds;
        }
        public TimeSpan ConverterToFullTime(TimeSpan timespan)
        {
            return timespan;
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
            TimeSpan timespan_1 = times.TimePointCreator(hours, minutes, seconds);

            Console.WriteLine("Введіть другу часову точку: ");
            Console.WriteLine(" ");

            Console.WriteLine("Введіть години: ");
            string hours_2 = Console.ReadLine();
            Console.WriteLine("Введіть хвилини: ");
            string minutes_2 = Console.ReadLine();
            Console.WriteLine("Введіть секунди: ");
            string seconds_2 = Console.ReadLine();

            Console.WriteLine("Введіть часову точку лише у секундах: ");

            string seconds_only = Console.ReadLine();
            TimeSpan timespan_sec = times.TimePointCreator(seconds: seconds_only);

            TimeSpan timespan_2 = times.TimePointCreator(hours_2, minutes_2, seconds_2);

            Console.WriteLine($"Ваші часові точки: \n{timespan_1}\n{timespan_2}");

            Console.WriteLine($"Результат додавання часових точок: {times.TimeAddition(timespan_1, timespan_2)}");
            Console.WriteLine($"Результат віднімання часових точок: {times.TimeSubtraction(timespan_1, timespan_2)}");
            Console.WriteLine($"Результат переведення часу першої точки у секундний формат: {times.ConverterToSeconds(timespan_1)}");
            Console.WriteLine($"Результат переведення часу другої точки у секундний формат: {times.ConverterToSeconds(timespan_2)}");

            Console.WriteLine($"Результат переведення часу точки у секундний формат{times.ConverterToFullTime(timespan_sec)}");
        }
    }
}