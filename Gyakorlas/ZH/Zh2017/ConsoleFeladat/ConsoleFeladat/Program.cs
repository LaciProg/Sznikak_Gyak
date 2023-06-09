namespace ConsoleFeladat
{
    internal class Program
    {

        private static long value;
        private static object valueLock = new object();
        private static AutoResetEvent AutoResetEvent = new AutoResetEvent(false);
        private static Random _random = new Random();

        static void Main(string[] args)
        {
            elso();
            harmadik();
        }

        private static void harmadik(){
            Thread t = new Thread(MainThread); t.Start();

            Thread f1 = new Thread(ThreadFunc) { IsBackground = true, Name= "f1" }; f1.Start();
            Thread f2 = new Thread(ThreadFunc) { IsBackground = true, Name = "f2" }; f2.Start();
            Thread f3 = new Thread(ThreadFunc) { IsBackground = true, Name = "f3" }; f3.Start();
            Thread f4 = new Thread(ThreadFunc) { IsBackground = true, Name = "f4" }; f4.Start();
            Thread f5 = new Thread(ThreadFunc) { IsBackground = true, Name = "f5" }; f5.Start();
        }


        private static void ThreadFunc(){
            AutoResetEvent.WaitOne();
            lock (valueLock) {
                Console.WriteLine(value +" "+ Thread.CurrentThread.Name);
            }
            //Thread.CurrentThread.Join();
        }

        private static void MainThread(){
            while(true){
                lock(valueLock){
                    value = _random.Next();
                    AutoResetEvent.Set();
                }
                Thread.Sleep(1000);
            }
        }


        private static void elso(){
            Progress progress = new Progress();
            progress.ProgressChange += (x, y) => { int c = y - x; Console.WriteLine("A változás értéke: {0}", c); };
            progress.Progress_ = 10;
            progress.Progress_ = 5;
            progress.Progress_ = 6;



        }
    }
}