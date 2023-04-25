namespace Area
{

    public delegate void SuspiciousValueSetDelegate(double regi, double uj);

    internal class Program
    {
        static void Main(string[] args)
        {
            Area area = new Area();
            area.SuspiciousValueSet += (x, y) => Console.WriteLine("A változás mértéke: {0}", y - x);
            area.SquareKm = 1;
            area.SquareKm = 2;
            area.SquareKm = 100;
            area.SquareKm = 100000;
        }
    }










    public class Area{
        public event SuspiciousValueSetDelegate SuspiciousValueSet;
        private double squareKm;
        public double SquareKm{
            get => squareKm;
            set{
                if (value < 0) throw new ArgumentException("Nem lehet kisebb mint 0");
                if(value > 10000) SuspiciousValueSet?.Invoke(value, squareKm);

                squareKm = value;
            }
        }
    }
}