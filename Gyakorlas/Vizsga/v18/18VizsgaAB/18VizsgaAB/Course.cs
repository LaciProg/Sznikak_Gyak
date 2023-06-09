using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18VizsgaAB
{
    public delegate void NameDelegate(string name, int num);
    public class Course
    {
        public NameDelegate nameDelegate;
        private int num;
        public int StudentCount {
            get => num;
            private set{ num = value; }
        }
        public void register(string name) {
            StudentCount = ++StudentCount;
            nameDelegate?.Invoke(name, StudentCount);
        }
    }
}
