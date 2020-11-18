using System;
using System.Linq;
using System.Text;

namespace Task_6
{
    class massive
    {
        private uint m;
        private uint n;
        private int[][] arr;
        private int key;
        public void input_and_correct_data_check()
        {
            try
            {
                Console.WriteLine("Input number of rows of your massive: ");
                m = Convert.ToUInt32(Console.ReadLine());
                Console.WriteLine("Input number of columns of your massive: ");
                n = Convert.ToUInt32(Console.ReadLine());
                Console.WriteLine("Input a key: ");
                key = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("У Вас неадекватне значення!");
                Environment.Exit(0);
            }
        }
        public void array_creating()
        {
            arr = new int[m][];
            Random random = new Random();
            for (int i = 0; i < m; i++)
            {
                arr[i] = new int[n];
            
                for (int j = 0; j < n; j++)
                {
                    arr[i][j] = random.Next(40);
                }
            }
          
        }
        public void key_max_element_with_general_output()
        {
            int max_element;
            StringBuilder all_index = new StringBuilder();
            StringBuilder all_key_equals = new StringBuilder();
            for (int i = 0; i < m; i++)
            {
                max_element = arr[i].Max();
                for (int j = 0; j < n; j++)
                {
                    if (arr[i][j] == max_element)
                    {
                        all_index.Append($"[{j}] ");
                    }
                    if (arr[i][j] == key)
                    {
                        all_key_equals.Append($"{arr[i][j]}; ");
                    }
                }
                Console.Write($"{string.Join("  ", arr[i])} | Max_element - {max_element}|indexes: {all_index}\nKey equals: {all_key_equals}\n");
                all_index = new StringBuilder();
                all_key_equals = new StringBuilder();
            }
        }
    }
    class Program
        {
        static void Main(string[] args)
        {
            massive massive = new massive();
            massive.input_and_correct_data_check();
            massive.array_creating();
            massive.key_max_element_with_general_output();
        }
    }
}