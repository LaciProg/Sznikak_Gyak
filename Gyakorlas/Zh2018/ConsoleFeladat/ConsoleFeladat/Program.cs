namespace ConsoleFeladat
{

    internal class Program
    {
        static void Main(string[] args)
        {
            elso();
            harmadik();
        }

        private static void elso()
        {
            Ballot ballot = new Ballot();
            ballot.vote += (x, y) => Console.WriteLine("{0}", x);
            ballot.CreateVote("Vitya");
            ballot.CreateVote("Lölő");
            ballot.CreateVote("Csányi");
            ballot.CreateVote("Matolcso");
            ballot.CreateVote("Németh Szilárd");
            ballot.CreateVote("Szíjártó");

        }

        private static List<int> ints = new List<int>();
        private static object listLock = new object();
        private static AutoResetEvent wait = new AutoResetEvent(false);

        private static int elemets() { lock (listLock) { return ints.Count; } }

        private static void harmadik()
        {
            harmadikText();

            Thread p = new Thread(ProductorThreadFunc) { IsBackground = false }; p.Start();

            Thread t1 = new Thread(ConsnumerThreadFunc) { IsBackground = true }; t1.Start();
            Thread t2 = new Thread(ConsnumerThreadFunc) { IsBackground = true }; t2.Start();
            Thread t3 = new Thread(ConsnumerThreadFunc) { IsBackground = true }; t3.Start();
        }

        private static void ProductorThreadFunc()
        {
            int i = 0;
            while (true)
            {
                lock (listLock)
                {
                    ints.Add(i++);
                }
                Console.WriteLine(i.ToString());
                wait.Set();
                Thread.Sleep(1000);
            }

        }

        private static void ConsnumerThreadFunc()
        {
            bool succes = false;
            while (true)
            {
                wait.WaitOne();
                lock (listLock)
                {
                    if (elemets() == 5)
                    {
                        Console.WriteLine("full");
                        ints.Clear();
                        succes = true;
                        break;
                    }

                }
            }
            if (succes) Thread.CurrentThread.Join();
        }

        private static void harmadikText()
        {
            Console.WriteLine("1. GUI esetén felhasználói interakcióra várakozás közben / Hosszú blokkoló művelet GUI alkalmazásokban");
            Console.WriteLine("2. Ha a feladatoknak nem feltétlenül egymás után kell következniük");
            Console.WriteLine("3. Többfelhasznáójú rendszereknél");
            Console.WriteLine("4. Átlagosnál jobb CPU kihasználás elérése");
            Console.WriteLine("5. Időzítésérzékeny feladatok");
            Console.WriteLine("6. Kiszolgáló alkalmazások esetében kisebb átlagos válaszidő");
        }
    }
}