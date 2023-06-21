namespace feladat_1_3
{

    internal class Program
    {
        //public static int hany_paratlan = 0;                                              Ez kell ha nem akarsz lamdázni
        //public static void fuggveny_lamda_helyett(int valtozonev){ hany_paratlan++; }     És ez

        static void Main(string[] args)
        {
            //F1();
            F3();
        }


        /**
         * 1) accumulator osztály, privát int adattag ami összeget tárol, public property amivel változtathatod (10000 felett kivételt dob),
         * lekérdezni a tulajdonsággal nem lehetet
         * Add metódus amivel egy számot tudsz hozzáadni az int-hez, esemény ami akkor sül el, ha az adattag értéke páratlan
         * (példakódban azt kell kiírni hányszor volt ptlan)
         */
        public static void F1()     //Main miatt static
        {
            Accumulator accumulator = new();
            int hany_paratlan = 0;                                  //Ha lamdázol ez itt is jó
            accumulator.Something += valtozonev => hany_paratlan++;
            accumulator.Add(1);
            accumulator.Add(1);
            accumulator.Add(3);
            accumulator.Add(1);
            accumulator.Add(2);
            accumulator.Add(1);
            accumulator.Add(1);
            //accumulator.Add(1001);
            Console.WriteLine(hany_paratlan);
        }

        /**
        * 3, stack-es feladat, két munkaszál dobálja bele az inteket (0-100 között),
        * közben a main törli öket és kiírja a konzolra, hogy mit törölt,
        * ha vmelyik munkaszál 99-et sorsol akkor leáll
        * Változtattam rajta egy kicsit mert túl egyszerűnek tűnt a többi hasonló feladthaz képest
        */
        private static Stack<int> stack = new();    //Tároló
        private static object lockObject = new();
        private static Random Random = new();
        private static int active = 0;
        private static AutoResetEvent AutoResetEvent = new(false);
        public static void F3()
        {
            Thread t1 = new Thread(ThreadFunc) { IsBackground = true };
            Thread t2 = new Thread(ThreadFunc) { IsBackground = true };
            t1.Start();
            t2.Start();
            Thread.Sleep(1000);
            while (true) {
                if(active == 0 && stack.Count == 0) { break; }
                if(stack.Count > 0) {
                    lock(lockObject) {
                        Console.WriteLine(stack.Pop());
                    }
                }
            }
            t1.Join();
            t2.Join();
        }

        public static void ThreadFunc(){
            active++;
            while(true){
                int szam = Random.Next(101);    //0-100
                Console.WriteLine("Generált: "+szam);
                if (szam == 99) {  active--; break; }
                lock (lockObject) { ;
                    stack.Push(szam);
                    AutoResetEvent.Set();
                    Thread.Sleep(100);      //Általában kell , Namemeg amúgy is, így biztos tud dolgozni a main is :D  
                }
            }
        }
    }



    //Első feladat osztály
    public delegate void SomethingDelegate(int a);  //Delegate
    public class Accumulator{
        private int sum;
        public int Sum{
            set{ sum = value; } //Csak változtatható
        }

        public event SomethingDelegate Something;   //Osztály eseménye amit el tud sütni

        public void Add(int a){
            if (a > 1000) throw new ArgumentOutOfRangeException("Túl nagy a szám"); //Kivétel
            sum += a;
            if (sum % 2 == 1) Something?.Invoke(a);
            //if (Something != null) Something(a); Másik megoldás
        }
    }
}