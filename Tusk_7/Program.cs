using System;
using System.IO;
using System.Linq;

namespace task_7
{
    public enum WeatherType
    {
        undefined = 0,
        rain = 1,
        short_time_rain = 2,
        thunderstorm = 3,
        snow = 4,
        fog = 5,
        sunny = 6,
        darkly = 7
    }
    class WeatherParametersDay
    {
        public double average_day_temperarure;
        public double average_night_temperature;
        public double average_atmospheric_pressure;
        public double precipitation;
        public WeatherType weather_type;
        public WeatherParametersDay(double averageTemperatureDay, double averageTemperatureNight, double averageAtmosphericPressure,
            double precipitation, int weatherType)
        {
            average_day_temperarure = averageTemperatureDay;
            average_night_temperature = averageTemperatureNight;
            average_atmospheric_pressure = averageAtmosphericPressure;
            this.precipitation = precipitation;
            weather_type = (WeatherType)weatherType;
        }
    }
    class WeatherDays
    {
        private WeatherParametersDay[] weather_array;
        public WeatherDays(WeatherParametersDay[] WeatherArr)
        {
            weather_array = WeatherArr;
        }
        public int DarklyDaysCounter(params WeatherType[] weatherType)
        {
            int this_condition_days_counter = 0;
            foreach (WeatherParametersDay day in weather_array)
                if (weatherType.Contains(day.weather_type))
                {
                    this_condition_days_counter += 1;
                }
            return this_condition_days_counter;
        }
        public int NoPrecipitationDaysCounter(params WeatherType[] weatherType)
        {
            int this_condition_days_counter = 0;
            foreach (WeatherParametersDay day in weather_array)
                if (!weatherType.Contains(day.weather_type))
                {
                    this_condition_days_counter += 1;
                }
            return this_condition_days_counter;
        }
        public double AverageNightTemperature()
        {
            double sum = 0;
            foreach (WeatherParametersDay day in weather_array)
            {
                sum += day.average_night_temperature;
            }
            return sum / 31;
        }
    }
    class Program
    {
        private static void FileRead(ref int[,] days)
        {
            string[] check_replace_arr;
            string[] data_lines = File.ReadAllLines(@"Days.txt");
            for (int i = 0; i < data_lines.Length; i++)
            {
                if (data_lines[i].Split(' ').Length != 31)
                {
                    Console.WriteLine($"EVERY LINE MUST BE FILLED WITH ***31*** NUMBERS, YOUR FILE IS CORRUPTED ");
                    Environment.Exit(0);
                }
                check_replace_arr = data_lines[i].Split(' ');
                for (int j = 0; j < 31; j++)
                    try
                    {
                        days[i, j] = Convert.ToInt32(check_replace_arr[j]);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("INVALID DATA FORMAT");
                        Environment.Exit(0);
                    }
            }
            CorrectNumbersCheck(ref days);
        }
        private static void ConsoleRead(ref int[,] days, ref string[] words)
        {
            string[] check_replace_arr;
            Console.WriteLine("Input your values(31 number with ONE GAP between): ");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Enter *{words[i]}* line");
                check_replace_arr = Console.ReadLine().Split(" ");
                if (check_replace_arr.Length != 31)
                {
                    Console.WriteLine("READ AGAIN WHAT I TOLD YOU BEFORE");
                    Environment.Exit(0);
                }
                for (int j = 0; j < check_replace_arr.Length; j++)
                {
                    try
                    {
                        days[i, j] = Convert.ToInt32(check_replace_arr[j]);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("INVALID DATA FORMAT");
                        Environment.Exit(0);
                    }
                }
            }
            CorrectNumbersCheck(ref days);
        }
        private static int[,] CorrectNumbersCheck(ref int[,] days)
        {
            for (int i = 0; i < days.GetLength(1); i++)
            {
                if (days[4, i] < 0 || days[4, i] > 7 || days[3, i] < 0 || days[2, i] < 0)
                {
                    Console.WriteLine("INVALID NUMBERS");
                    Environment.Exit(0);
                }
            }
            return days;
        }
        private static void DaysOutput(int[,] days, string[] words)
        {
            for (int i = 0; i < days.GetLength(0); i++)
            {
                Console.Write($"{words[i]}: ");
                for (int j = 0; j < days.GetLength(1); j++)
                {
                    Console.Write($"{days[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            string[] words = { "Average Temperature at day", "Average Temperature at night", "Average Atmospheric Pressure", "Precipitation",
            "Weather Type" };
            int[,] days = new int[5, 31];
            Console.Write("Write anything for *ConsoleReading* or just press ENTER for *FileReading*: ");
            Console.WriteLine();
            switch (Console.ReadLine().Length)
            {
                case 0:
                    FileRead(ref days);
                    break;
                default:
                    ConsoleRead(ref days, ref words);
                    break;
            }
            DaysOutput(days, words);
            WeatherParametersDay[] weatherParametersDays = new WeatherParametersDay[days.GetLength(1)];
            for (int i = 0; i < days.GetLength(1); i++)
                weatherParametersDays[i] = new WeatherParametersDay(days[0, i], days[1, i], days[2, i], days[3, i], (int)days[4, i]);
            WeatherDays weatherDays = new WeatherDays(weatherParametersDays);
            Console.WriteLine($"Number of darkly days: {weatherDays.DarklyDaysCounter(WeatherType.darkly)}");
            Console.WriteLine($"The number of days without precipitation: " +
                $"{weatherDays.NoPrecipitationDaysCounter(WeatherType.snow, WeatherType.rain, WeatherType.short_time_rain)}");
            Console.WriteLine($"Average nightime temperature: {weatherDays.AverageNightTemperature()}");
        }
    }
}
