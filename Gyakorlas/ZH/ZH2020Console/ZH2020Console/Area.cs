using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2020Console
{
    public delegate void SuspiciousValueSet(double regi, double uj);
    public class Area
    {
        public event SuspiciousValueSet SUS;
        private double squareKM;
        public double SquareKM {
            get => squareKM;
            set{
                if (value <= 0) throw new ArgumentException("Nem lehet a terület 0nál kisebb");
                if (value > 100000) SUS?.Invoke(squareKM, value);
                squareKM = value;
            }
        }
    }
}
