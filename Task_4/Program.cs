using System;

namespace Task_4
{
    class Time
    {
        private int hours;
        private int minutes;
        private int seconds;

        public Time()
        {
            this.hours = DateTime.Now.Hour;
            this.minutes = DateTime.Now.Minute;
            this.seconds = DateTime.Now.Second;
        }
        public Time(int d, int m)
        {
            if ((1 <= m && m <= 12) && (1 <= d && d <= 30))
            {
                this.hours = DateTime.Now.Hour;
                this.minutes = m;
                this.seconds = d;
            }
            else { Console.WriteLine("Неверная дата."); }
        }
        public Time(int d, int m, int y)
        {
            if ((1 <= m && m <= 12) && (1 <= d && d <= 30))
            {
                this.hours = y;
                this.minutes = m;
                this.seconds = d;
            }
            else { Console.WriteLine("Неверная дата."); }
        }

        public DateTime GetDate() => new DateTime(seconds, minutes, hours);

        public TimeSpan SubDate(DateTime dateValue1, DateTime dateValue2) => dateValue1.Subtract(dateValue2);

        public double toDays(DateTime dateValue) => dateValue.Day + 30 * (dateValue.Month + 12 * dateValue.Year);
        public DateTime toDate(double days)
        {
            int year = Convert.ToInt32(days / 30 / 12);
            int month = Convert.ToInt32(days / 30);
            int day = Convert.ToInt32(days % 30);
            return new DateTime(day, month, year);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            Time dateClass = new Time(10, 2, 2020);
            Time dateClass2 = new Time(1, 2, 2020);
            var date_1 = dateClass.GetDate();
            var date_2 = dateClass2.GetDate();
            Console.WriteLine(date_1);
            Console.WriteLine(date_2);
            Console.WriteLine(dateClass.SubDate(date_1, date_2));
            Console.WriteLine(dateClass.SubDate(date_2, date_1));
            Console.WriteLine(dateClass.toDays(date_1));
            Console.WriteLine(dateClass.toDate(dateClass.toDays(date_1)));
            Console.WriteLine(dateClass2.toDays(date_2));
            Console.WriteLine(dateClass2.toDate(dateClass2.toDays(date_2)));
            Console.WriteLine();
        }
    }
}