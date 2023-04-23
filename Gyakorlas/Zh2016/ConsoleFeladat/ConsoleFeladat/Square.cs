namespace ConsoleFeladat
{
    public delegate void AreaChangedDelegate(double d);
    public class Square
    {
        public event AreaChangedDelegate AreaChange;
        private double side;
        public double Side
        {
            get => side;
            set
            {
                if (value > 0)
                {
                    side = value;
                    AreaChange?.Invoke(Area);
                }
            }
        }
        public double Area
        {
            get => side* side; 
        }
    }

}