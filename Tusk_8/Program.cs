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
            return new MyComplex(a.Re + b.Re, a.Im + b.Im);
        }
        public static MyComplex operator +(MyComplex a, double b)
        {
            return new MyComplex(a.Re + b, a.Im);
        }
        public static MyComplex operator +(double b, MyComplex a)
        {
            return new MyComplex(a.Re + b, a.Im);
        }
        public static MyComplex operator -(MyComplex a)
        {
            return new MyComplex(-a.Re, -a.Im);
        }
        public static MyComplex operator -(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.Re - b.Re, a.Im - b.Im);
        }
        public static MyComplex operator -(double b, MyComplex a)
        {
            return new MyComplex(a.Re - b, a.Im);
        }
        public static MyComplex operator -(MyComplex a, double b)
        {
            return new MyComplex(a.Re - b, a.Im);
        }
        public static MyComplex operator *(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.Re * b.Re, a.Im * b.Im);
        }
        public static MyComplex operator *(MyComplex a, double b)
        {
            return new MyComplex(a.Re * b, a.Im * b);
        }
        public static MyComplex operator *(double b, MyComplex a)
        {
            return new MyComplex(a.Re * b, a.Im * b);
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
            return ($"{this.Re} +/- {this.Im}i");
        }
        public double this[string type]
        {
            get
            {
                switch (type)
                {
                    case "realValue":
                        return Re;
                    default:
                        return Im;
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

            C = A + B;
            C = A + 10.5;
            C = 10.5 + A;
            D = -C;
            C = A + B + C + D;
            C = A = B = C;

            D.InputFromTerminal();

            Console.WriteLine($"A = {A}, B = {B}, C = {C}, D = {D}");

            Console.WriteLine($"Re(A) = {A["realValue"]}, Im(A) = {A["imaginaryValue"]}");
            Console.WriteLine($"Re(B) = {B["realValue"]}, Im(B) = {B["imaginaryValue"]}");
            Console.WriteLine($"Re(C) = {C["realValue"]}, Im(C) = {C["imaginaryValue"]}");
            Console.WriteLine($"Re(D) = {D["realValue"]}, Im(D) = {D["imaginaryValue"]}");
        }
    }
}