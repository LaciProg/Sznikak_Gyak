namespace ConsoleFeladat
{
    public delegate void ProgressChangeDelegate(int regi, int uj);
    public class Progress
    {
        
        private int progressPercent;
        public int Progress_{

            get => progressPercent;
            set
            {
                if (value >= 0 && value <= 100)
                {
                    ProgressChange?.Invoke(progressPercent, value);

                    progressPercent = value;
                }
            }
        }
        public event ProgressChangeDelegate ProgressChange;


    }
}
