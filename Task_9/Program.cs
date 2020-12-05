using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Task_9
{
    class massive
    {
        static uint m;
        static uint n;
        int[][] arr;
        static int key;

        public delegate bool IsEqual(int x);
        public IsEqual ConditionCheck = x => x > 15;
        static public void MyCalculation(int[][] arr, IsEqual func)
        {
            List<List<int>> full_list = new List<List<int>>();
            List<int> row_list = new List<int>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (func(arr[i][j]) == true)
                    {
                        row_list.Add(arr[i][j]);
                    }
                }
                if (row_list.Count == 0)
                {   
                    continue;
                }
                full_list.Add(row_list);
                row_list.Clear();
            }
            int full_list_lenght = full_list.Count;
            arr = new int[full_list.Count][];
            for (int i = 0; i < full_list_lenght; i++)
            {
                arr[i] = new int[full_list[i].Count];
                for (int j = 0; j < full_list[i].Count; j++)
                {
                    arr[i][j] = full_list[i][j];
                }
            }
            max_element_with_general_output(arr);
            key_coordinates_output(arr);
        }
        public void input_and_correct_data_check()
        {
            try
            {
                Console.WriteLine("Input number of rows of your massive: ");
                m = Convert.ToUInt32(Console.ReadLine());
                Console.WriteLine("Input number of columns of your massive: ");
                n = Convert.ToUInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("У Вас неадекватне значення!");
                Environment.Exit(0);
            }
        }
        public int[][] array_creating()
        {
            arr = new int[m][];
            Random random = new Random();
            Console.WriteLine("Ваш масив, що любий серцю...");
            for (int i = 0; i < m; i++)
            {
                arr[i] = new int[n];

                for (int j = 0; j < n; j++)
                {
                    arr[i][j] = random.Next(41);
                }
            }
            return arr;
        }
        public void key_input()
        {
            try
            {
                Console.WriteLine("Input a key: ");
                key = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("У Вас неадекватне значення!");
                Environment.Exit(0);
            }
        }
        static public void max_element_with_general_output(int[][] arr)
        {
            int max_element;
            StringBuilder all_max_index = new StringBuilder();

            for (int i = 0; i < arr.Length; i++)
            {
                max_element = arr[i].Max();
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] == max_element)
                    {
                        all_max_index.Append($"[{j}] ");
                    }
                }
                Console.WriteLine($"{string.Join("  ", arr[i])} | Max_element - {max_element} | indexes: {all_max_index}\n-----------------------------------");
                all_max_index = new StringBuilder();
            }
        }
        static public void key_coordinates_output(int[][] arr)
        {
            StringBuilder all_key_equals = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] == key)
                    {
                        all_key_equals.Append($"[{i}][{j}] ");
                    }
                }
            }
            Console.WriteLine($"\nAll key coordinates: {all_key_equals}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            massive massive = new massive();
            massive.input_and_correct_data_check();
            int[][] array = massive.array_creating();
            massive.max_element_with_general_output(array);
            massive.key_input();
            massive.key_coordinates_output(array);

            massive.MyCalculation(array, massive.ConditionCheck);
        }
    }
}