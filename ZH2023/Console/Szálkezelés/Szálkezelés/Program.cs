namespace Szálkezelés
{
    internal class Program
    {

    private static object lockObject = new object();
    private static int szam =0;
    private static ManualResetEvent startEvent = new ManualResetEvent(false);
    private static Random random = new Random();

        static void Main(string[] args)
        {
            Thread firstThread = new Thread(first){ IsBackground = true };  firstThread.Start();
            Thread secondThread = new Thread(second){  IsBackground = true }; secondThread.Start();

            Thread.Sleep(2500);
            startEvent.Set();
            firstThread.Join();
            secondThread.Join();
            Console.WriteLine(szam);
            Console.WriteLine("Jó verseny volt!");
        }

        private static void first()
        {
            startEvent.WaitOne();
            while (true) { 
                lock (lockObject)
                {
                    if(szam <= -20) { return; }
                    int rand = random.Next(13);
                    Console.WriteLine("Rand: {0}", rand);
                    if (rand == 0) { Console.WriteLine(rand); Console.WriteLine("Nyertem"); szam = 20; break; }
                    szam += rand;
                    Console.WriteLine("Szam: {0}",szam);
                    if (szam >= 20) { Console.WriteLine("Nyertem"); break; }
                }
               
                Thread.Sleep(150);
            }
        }

        private static void second()
        {
            startEvent.WaitOne();
            while (true)
            {
                lock (lockObject)
                {
                    if (szam >= 20) { return; }
                    int rand = random.Next(13);
                    Console.WriteLine("Rand: {0}", rand);
                    if (rand == 0) { Console.WriteLine(rand); Console.WriteLine("Nyertem"); szam = -20; break; }
                    szam -= rand;
                    Console.WriteLine("Szam: {0}", szam);
                    if (szam <= -20) { Console.WriteLine("Nyertem"); break; }
                }
                
                Thread.Sleep(150);
            }
        }
    }
}