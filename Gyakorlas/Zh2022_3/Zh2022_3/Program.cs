namespace Zh2022_3
{
    internal class Program
    {

 
        private static List<int> ints = new List<int>();
        private static object lockList = new object();
        private static AutoResetEvent MyAutoResetEvenet = new AutoResetEvent(false);
        private static int ThreadsLeft = 0;
        private static ManualResetEvent manualReset = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            Thread termelő = new Thread(TermelőFunction) { IsBackground = false}; termelő.Start();

            Thread f1 = new Thread(FogyasztoFunction) { IsBackground = true, Name = "f1" }; ThreadsLeft++; f1.Start();
            Thread f2 = new Thread(FogyasztoFunction) { IsBackground = true, Name = "f2" }; ThreadsLeft++; f2.Start();
            Thread f3 = new Thread(FogyasztoFunction) { IsBackground = true, Name = "f3" }; ThreadsLeft++; f3.Start();

            manualReset.WaitOne();
            termelő.Join();
            
        }

            

        private static void TermelőFunction(){
            int i = 1;    
            while(ThreadsLeft>0){
                lock (lockList)
                {
                    ints.Add(i++);
                }
                if (Elemszam() >= 30) MyAutoResetEvenet.Set();
                Thread.Sleep(100);

            }
        }

        private static int Elemszam() => ints.Count;

        private static void FogyasztoFunction(){
            MyAutoResetEvenet.WaitOne();
            Console.WriteLine(Thread.CurrentThread.Name);
            bool ok = false;
            lock (lockList)
            {
                if (Elemszam() >= 30)
                {
                    ints.Clear();
                    Console.WriteLine("megtelt");
                    ThreadsLeft--;
                    if (ThreadsLeft == 0) manualReset.Set();
                    ok = true;
                }
            }
            if(ok) Thread.CurrentThread.Join();
        }
    }
}