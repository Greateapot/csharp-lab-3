namespace Lab3
{
    public class Program
    {
        private const double epsilon = .0001;
        private const double k = 10;
        private const double a = .1;
        private const double b = 1;
        private const double step = (b - a) / k;
        private const int n = 20;

        public static void Main()
        {
            Console.WriteLine($"a = {a}; b = {b}; k = {k}; n = {n}; epsilon = {epsilon}; step = {step}.");
            for (var x = a; x <= b; x += step)
                Console.WriteLine($"X = {x:f4}; SN = {CalculateSum(x, n):f4}; SE = {CalculateSum(x):f4}; Y = {F(x):f4}.");
        }

        private static double F(double x) =>
            Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x));

        private static double CalculateSum(double x)
        {
            var previousSum = CalculateSum(x, 0);
            var sum = CalculateSum(x, 1);
            var difference = Math.Abs(sum - previousSum);

            for (var i = 2; difference > epsilon; i++)
            {
                previousSum = sum;
                sum = CalculateSum(x, i);
                difference = Math.Abs(sum - previousSum);
            }

            return sum;
        }

        private static double CalculateSum(double x, int n)
        {
            var sum = .0;
            var fact = 1;

            for (var i = 0; i <= n; i++)
            {
                fact *= i;
                if (fact == 0) fact = 1;
                sum += Math.Cos(x * i) / fact;
            }

            return sum;
        }
    }
}