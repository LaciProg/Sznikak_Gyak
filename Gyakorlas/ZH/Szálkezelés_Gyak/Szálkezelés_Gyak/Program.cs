namespace Szálkezelés_Gyak
{
    internal class Program
    {

        private static List<int> list = new List<int>();
        private static Object listLockIbject = new Object();
        private static Random random = new Random();
        private static ManualResetEvent WaitGenEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            Thread thread = new Thread(ThreadFunction)
            {
                IsBackground = true
            };
            thread.Start();
            Thread.Sleep(random.Next(10000));
            if (list.Count < 50) lock (listLockIbject) { list.Add(-1); Console.WriteLine("Yeah {0} {1}", -1, list.Count); };
            WaitGenEvent.WaitOne();
            Console.WriteLine("Köszönöm");
            thread.Join();
            Console.WriteLine(list.Count);
        }


        public static void ThreadFunction()
        {
            for (int i = 0; i < 200; i++)
            {
                lock (listLockIbject)
                {
                    int szam = random.Next(10);
                    Console.WriteLine(szam);
                    list.Add(szam);
                    Thread.Sleep(100);
                }
            }
            WaitGenEvent.Set();
            Thread.Sleep(10000);
            
        }
    }
}