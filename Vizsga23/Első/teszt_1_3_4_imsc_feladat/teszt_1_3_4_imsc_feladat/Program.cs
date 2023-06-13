namespace teszt_1_3_4_imsc_feladat
{
    /* A tesztek a Vik Wikihez nagyon hasonlóak voltak. A vizsgás részében vannak még hibák amikor néztem
     * Volt egyszerű kérdés az utolsó, async részből. Kb annyi, hogy mivel tér vissza egy ilyen függvény (Task vagy Task<T> Task<void> nincs)
     * Lehet kérdés az ADO.NET-ből is
     */

    /* A 4es feladat a Composit minta bemutatása volt
     * Osztálydiagram fontosabb részekhez pszeudkódpt (diákon ott van) + leírás, hogy mit csinál,mire jó a minta
     * Lehetett konkrét példa is vagy általános osztélydiagram (amihez volt előadáson kérhetnek szekvencia diagramot is)
     */

    /* Imsc feladatban egy leírás alapján kellett rájönni a mintára:
     * Történelmi korokon átívelő játék, több fajta korabeli épület ablakkal, ajtóval stb... => Abstract Factory
     * Adni kellett egy osztálydiagramot a fontosabb részekhez pszeudkódpt (diákon ott van)
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            F1();
            F3();
        }

        public static void F1()
        {
            SpeedLimiter speedLimiter = new();
            speedLimiter.SpeedIsLimited += (v) => Console.WriteLine(v); //Lamda függvény amit berigisztrálunk az eseményre és kirja a paraméter értékét
            speedLimiter.Speed = 30;
            speedLimiter.Speed = 100;
        }
        private static void FuggvenyPelda(int v){ Console.WriteLine(v); }   

        private static AutoResetEvent autoResetEvent = new(false);  //Várakozás a 200 számra
        private static List<int> list = new();
        private static object synobj = new();   //Lock object (statitc mert a main és az F3() is az
        private static Random random = new();
        public static void F3()
        {
            Thread t = new Thread(threadFunc);
            t.Start();
            Thread.Sleep(random.Next(11)*1000);
            lock(synobj) { if (list.Count > 0) if (list[list.Count - 1] % 2 == 0) list.Add(-1); }   //Ha a legutolsó ebben a pillantban páros...
            autoResetEvent.WaitOne();
            Console.WriteLine("Köszönöm");
            t.Join();
        }

        public static void threadFunc(){
            for(int i = 0; i != 200;  i++){
                lock(synobj){ list.Add(random.Next(11));}   //Csak az írás idejére lokkolunk
                Thread.Sleep(100);
            }
            autoResetEvent.Set();
            Thread.Sleep(10000);
        }

    }

    //Első faladathoz tartozó osztály. Tipikus zh első feladat
    public delegate void SpeedIsLimitedDelegate(int v); //A namspecbe kell egy delegate
    public class SpeedLimiter{
        public event SpeedIsLimitedDelegate SpeedIsLimited; //Esemény így csak += lehetséges
        private int speed;
        private int speedLimit = 90;
        public int Speed{   //Properity
            get =>speed;    // get{ return speed;}
            set{
                if(value > speedLimit){
                    speed = speedLimit;
                    SpeedIsLimited?.Invoke(value);  //Null vizsgálat
                }
                else { speed = value; }
            }
        }
    }


}