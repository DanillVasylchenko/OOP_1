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
        public IsEqual ConditionCheck = x => x <= 35;
        static public void MyCalculation(int[][] arr, IsEqual func)
        {
            List<List<int>> full_list = new List<List<int>> { };
            List<int> row_list = new List<int> { };
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
                row_list = new List<int> { };
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
                Console.WriteLine("Введіть кількість рядків масиву: ");
                m = Convert.ToUInt32(Console.ReadLine());
                Console.WriteLine("Введіть кількість стовпчиків маисву: ");
                n = Convert.ToUInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Перевірте правильність вводу даних!");
                Environment.Exit(0);
            }
        }
        public int[][] array_creating()
        {
            arr = new int[m][];
            Random random = new Random();
            Console.WriteLine("Масив зегенеровано випадковими числами від 1 до 40: ");

            for (int i = 0; i < m; i++)
            {
                arr[i] = new int[n];

                for (int j = 0; j < n; j++)
                {
                    arr[i][j] = random.Next(1, 41);
                }
            }
            return arr;
        }
        public void key_input()
        {
            try
            {
                Console.WriteLine("Ввдеіть ключ (пошук елемента у масиві): ");
                key = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Перевірте правильність вводу даних!");
                Environment.Exit(0);
            }
        }
        static public void max_element_with_general_output(int[][] arr)
        {
            List<int> column_list = new List<int>();
            List<int> res_list = new List<int>(); 
            int res;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    column_list.Add(arr[j][i]);
                }
            res = column_list.Max() * column_list.Min();
            Console.WriteLine($"{string.Join(" ", arr[i])}");
            res_list.Add(res);
            }
            for (int i = 0; i < res_list.Count(); i++)
                    Console.WriteLine($"Добуток {i}-го стовбчика дорівнює {res_list[i]}");
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
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            massive massive = new massive();
            massive.input_and_correct_data_check();
            int[][] array = massive.array_creating();
            massive.max_element_with_general_output(array);
            massive.key_input();
            massive.key_coordinates_output(array);

            massive.MyCalculation(array, massive.ConditionCheck);
            massive.MyCalculation(array, x => x % 10 != 0);
        }
    }
}