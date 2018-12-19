using System;
using System.Threading.Tasks;

namespace GoldenCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("requires a term number");
                return;
            }                      

            var term = double.Parse(args[0]);

            Console.WriteLine($"Term : {term}");

            var result = Fibonacci(term).GetAwaiter().GetResult();

            Console.WriteLine($"Iterative {result}");

            double fib = Fib(term);

            Console.WriteLine($"Formula   {fib}");

        }

        public static double Fib(double n)
        {
            var sqrt5 = Math.Sqrt(5);
            var phi = (1 + sqrt5) / 2;
            return Math.Round(Math.Pow(phi, n + 2) / sqrt5);
        }


        public static async Task<double> Fibonacci(double term)
        {
            var count = 0;
            var a = 0d;
            var b = 1d;
            var c = 0d;

            var r = await Task.Factory.StartNew(() =>
            {
                while (count <= term)
                {
                    c = a + b ;

                    Console.WriteLine($"# {count} : {a} + {b} = {c}");

                    a = b;
                    b = c;

                    count++;
                }

                return c;
            });

            return r;
        }
    }
}
