namespace V2015
{
    internal class Program
    {
        static void Main(string[] args)
        {
            F1();
        }

        public static void F1() {
            Calculator calculator = new();
            calculator.CalculationSquare += (n) => Console.WriteLine(n);
            calculator.CalculatedSquare += (n) => Console.WriteLine(n);
            calculator.Square(2);
            calculator.Square(3);
            calculator.Square(4);
        }

    }
}