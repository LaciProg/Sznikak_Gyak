using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2015
{
    public delegate void CalculationSquareDelegate(int n);
    public delegate void CalculatedSquareDelegate(int n);
    public class Calculator
    {
        public event CalculationSquareDelegate CalculationSquare;
        public event CalculatedSquareDelegate CalculatedSquare;

        public int Square(int n){
            CalculationSquare?.Invoke(n);
            n = n * n;
            CalculatedSquare?.Invoke(n);
            return n;
        }

    }
}
