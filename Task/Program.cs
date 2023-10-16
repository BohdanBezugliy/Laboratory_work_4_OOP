using System;

namespace Task
{
    class Parall
    {
        double a, b, c;
        public Parall(double a, double b, double c)
        { 
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public void Print()
        {
            Console.WriteLine($"a={a:F2} b={b:F2} c={c:F2}");
        }
        //Віртуальний метод Sqr - площа поверхні паралелепіпеда
        public virtual double Sqr() 
        {
            return 2 * (a * b + b * c + a * c);
        }
        //Віртуальний метод V- об’єм паралелепіпеда
        public virtual double V()
        {
            return a * b * c;
        }
    }
    class Kub : Parall
    {
        double a;
        public Kub(double a) : base(a, a, a)
        {
            this.a=a;
        }
        //Перевизначений віртуальний метод Sqr
        public override double Sqr()
        {
            return 6 * a * a;
        }
        //Перевизначений віртуальний метод V
        public override double V()
        {
            return a * a * a;
        }
        public double Radius()
        {
            return (a * Math.Sqrt(3)) / 2;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Parall figure;
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("a=");
                    double a = Convert.ToDouble(Console.ReadLine());
                    Console.Write("b=");
                    double b = Convert.ToDouble(Console.ReadLine());
                    Console.Write("c=");
                    double c = Convert.ToDouble(Console.ReadLine());
                    if (a <= 0 || b <= 0 || c <= 0)
                        throw new Exception("Сторони не можуть бути від'ємними або дорівнювати нулю!");
                    Console.WriteLine();
                    if (a == b && a == c)
                    {
                        figure = new Kub(a);
                        Kub childFigure = (Kub)figure;
                        childFigure.Print();
                        Console.WriteLine($"Площа повної поверхні куба={childFigure.Sqr():F2}");
                        Console.WriteLine($"Об'єм куба={childFigure.V():F2}");
                        Console.WriteLine($"Радіус описаної кулі={childFigure.Radius():F2}\n");
                    }
                    else
                    {
                        figure = new Parall(a, b, c);
                        figure.Print();
                        Console.WriteLine($"Площа повної поверхні паралелограма={figure.Sqr():F2}");
                        Console.WriteLine($"Об'єм паралелограма={figure.V():F2}\n");
                    }
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Помилка: некоректно введене значення!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Помилка: " + e.Message);
            }
        }
    }
}