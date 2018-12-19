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

            // var term = int.Parse(args[0]);
            var term = double.Parse(args[0]);

            int result = Fibonacci((int)term).GetAwaiter().GetResult();

            Console.WriteLine(result);


            double fib = Fib(term);

            Console.WriteLine(fib);

        }

        public static double Fib(double n)
        {
            var sqrt5 = Math.Sqrt(5);
            double phi = (1 + sqrt5) / 2;
            //return Math.Round(Math.Pow(phi, n + 1) / sqrt5);
            return Math.Pow(phi, n + 1) / sqrt5;
        }


        public static async Task<int> Fibonacci(int term)
        {
            var count = 0;
            var a = 0;
            var b = 1;
            var c = 0;

            var r = await Task.Factory.StartNew(() =>
            {
                while (count < term)
                {
                    c = a + b ;

                    Console.WriteLine($"{count} : {c}", count, c);

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
