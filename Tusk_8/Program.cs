using System;

namespace task_8
{
    class MyComplex
    {
        private double Re, Im;
        public MyComplex(double initRe = 0, double initIm = 0)
        {
            Re = initRe;
            Im = initIm;
        }
        public static MyComplex operator +(MyComplex a, MyComplex b)
        {
            MyComplex res = new MyComplex();
            res.Re = a.Re + b.Re;
            res.Im = a.Im + b.Im;
            return res;
        }
        public static MyComplex operator +(MyComplex a, double b)
        {
            MyComplex res = new MyComplex();
            res.Re = a.Re + b;
            res.Im = a.Im;
            return res;
        }
        public static MyComplex operator +(double b, MyComplex a)
        {
            return a + b;
        }
        public static MyComplex operator -(MyComplex a)
        {
            MyComplex res = new MyComplex();
            res.Re = -a.Re;
            res.Im = -a.Im;
            return res;
        }
        public static MyComplex operator -(MyComplex a, MyComplex b)
        {
            MyComplex res = new MyComplex();
            res.Re = a.Re - b.Re;
            res.Im = a.Im - b.Im;
            return res;
        }
        public static MyComplex operator -(MyComplex a, double b)
        {
            MyComplex res = new MyComplex();
            res.Re = a.Re - b;
            res.Im = a.Im - b;
            return res;
        }
        public static MyComplex operator -(double b, MyComplex a)
        {
            return a - b;
        } 
        public static MyComplex operator *(MyComplex a, MyComplex b)
        {
            MyComplex res = new MyComplex();
            res.Re = a.Re - b.Re;
            res.Im = a.Im - b.Im;
            return res;
        }
        public static MyComplex operator *(MyComplex a, double b)
        {
            MyComplex res = new MyComplex();
            res.Re = a.Re * b;
            res.Im = a.Im * b;
            return res;
        }
        public static MyComplex operator *(double b, MyComplex a)
        {
            return a * b;
        }
        public void InputFromTerminal()
        {
            Re = CheckNumber("real");
            Im = CheckNumber("imagine");
        }
        private double CheckNumber(string text)
        {
            double num = 0;
            Console.Write($"Enter {text} value: ");
            string num_for_check = Console.ReadLine();
            try
            {
                num = (Convert.ToInt64(num_for_check));
            }
            catch
            {
                Console.WriteLine("INVALID DATA!");
                Environment.Exit(0);
            }
            return num;
        }
        public override string ToString()
        {
            if (this.Im < 0)
            {
                return ($"{this.Re} {this.Im}i");
            }
            else
            {
                return ($"{this.Re} + {this.Im}i");
            }
            
        }
        public double this[string type]
        {
            get
            {
                switch (type)
                {
                    case "realValue":
                        return Re;
                    case "imaginaryValue":
                        return Im;
                    default:
                        return 0;
                }
                
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyComplex A = new MyComplex(1, 1);
            MyComplex B = new MyComplex();
            MyComplex C = new MyComplex(1);
            MyComplex D = new MyComplex();

            D.InputFromTerminal();
            C = A + D;
            Console.WriteLine($"C = {C}");
            C = A + 10.5;

            Console.WriteLine($"A = {A}, B = {B}, C = {C}, D = {D}");
            C = 10.5 + A;
            D = -C;
            C = A + B + C + D;
            C = A = B = C;

            Console.WriteLine($"A = {A}, B = {B}, C = {C}, D = {D}");

            Console.WriteLine($"Re(A) = {A["realValue"]}, Im(A) = {A["imaginaryValue"]}");
            Console.WriteLine($"Re(B) = {B["realValue"]}, Im(B) = {B["imaginaryValue"]}");
            Console.WriteLine($"Re(C) = {C["realValue"]}, Im(C) = {C["imaginaryValue"]}");
            Console.WriteLine($"Re(D) = {D["realValue"]}, Im(D) = {D["imaginaryValue"]}");
        }
    }
}