namespace ZH2020Console
{
    public delegate void ProgressChangeDelegate(int ertek);
    public class Progress
    {
        private int progressPercent;
        public event ProgressChangeDelegate ProgressChange;
        public int Progress_{
            get => progressPercent;
            set{
                if(value < 0 || value > 100) throw new ArgumentOutOfRangeException("Érvénytelen érték");
                ProgressChange?.Invoke(progressPercent);
                progressPercent = value;

            }
        }
    }
}
