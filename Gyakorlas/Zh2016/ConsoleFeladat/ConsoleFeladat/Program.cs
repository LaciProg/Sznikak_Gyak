namespace ConsoleFeladat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            elso();
        }

        private static void elso()
        {
            Square s = new();
            s.AreaChange += x => Console.WriteLine(x);
            s.Side = 10;
            s.Side = 20;
            s.Side = 5;
        }
    }
}