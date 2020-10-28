using System;
using System.Security.Cryptography.X509Certificates;

namespace Task_4
{
    class Times
    {
        private uint time;
        public uint Time
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
        public uint CorrectnessCheck(string time)
        {
            try
            {
                Time = Convert.ToUInt32(time);
            }
            catch (FormatException)
            {
                Console.WriteLine("Некоректні дані!");
            }
            return Time;
        }
        public TimeSpan TimePointCreator(int hours, int minutes, int seconds)
        {
            TimeSpan timespan = new TimeSpan(hours, minutes, seconds);
            return timespan;
        }
        public TimeSpan TimeSubtraction(TimeSpan timespan_1, TimeSpan timespan_2)
        {
            TimeSpan subtraction_reslt = timespan_1 - timespan_2;
            return subtraction_reslt;
        }
        public TimeSpan TimeAddition(TimeSpan timespan_1, TimeSpan timespan_2)
        {
            TimeSpan addition_reslt = timespan_1 + timespan_2;
            return addition_reslt;
        }
        public TimeSpan ConverterToSeconds(int timespan)
        {
            var converted_1 = TimeSpan.Parse(timespan).TotalSeconds;
            return converted_1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Введіть першу часову точку: ");
            var timespan1 = TimeSpan.FromSeconds(60);
            Console.WriteLine("Введіть другу часову точку: ");
            var timespan2 = TimeSpan.FromSeconds(60);

            Times times = new Times();

            Console.WriteLine(times.TimeAddition(timespan1, timespan2));

        }
    }
}