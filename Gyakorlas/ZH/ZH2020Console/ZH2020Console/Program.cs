using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

namespace ZH2020Console
{
    internal class Program
    {

        //TIPP
        private static int szam;
        private static ManualResetEvent startEvenet = new ManualResetEvent(false);
        private static Random random = new Random();
        private static bool found = false;
        private static object foundLock = new object();

        //Szám Gen
        private static List<int> list = new List<int>();
        private static object listLock = new object();
        private static ManualResetEvent genEvent = new ManualResetEvent(false);
        private static ManualResetEvent vegegenEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            AreaFunc();
            Tipp();
            CourseFunc();
            SzamGenThread();
            ProgressFunc();
            PollFunc();
        }

        private static void PollFunc(){
            Poll poll = new Poll();
            poll.OnVote += (x, y) => Console.WriteLine(x);
            //poll.OnVote += PollFuncDelegate;
            poll.RegisterVote("Goldi");
            poll.RegisterVote("Szirmay");
            poll.RegisterVote("Gajdos");

        }

        private static void PollFuncDelegate(string s, int n){ 
            Console.WriteLine(s);
        }

        private static void ProgressFunc() {
            Progress progress = new Progress();
            progress.ProgressChange += progressDelegateFunc;
            for(int i = 0; i < 100; i+=10) {
                progress.Progress_ += 10;
            }

        }

        private static void progressDelegateFunc(int i) {
            Console.WriteLine(i);
        }
        private static void SzamGenThread() {
            Thread gen = new Thread(SzamGenThreadFunc) { IsBackground = true }; gen.Start(); ;
            Thread.Sleep(random.Next(1001));
            lock(listLock) {
                if(list.Count < 50) { list.Add(-1); }
            }
            genEvent.WaitOne();
            Console.WriteLine("Köszönöm");
            vegegenEvent.WaitOne();
            //Thread.CurrentThread.Join();

        }

        private static void SzamGenThreadFunc(){
            for(int i = 0; i < 200; i++){
                lock(listLock){ list.Add(random.Next(11)); }
                Thread.Sleep(10);
            
            }
            genEvent.Set();
            Thread.Sleep(10000);
            vegegenEvent.Set();
            //Thread.CurrentThread.Join();

        }

        private static void CourseFunc(){
            Course course = new Course();
            course.studentDelegate += CourseDelegateFunc;
            course.Register("A");
            course.Register("B");
            course.Register("C");
            course.Register("D");
            course.Register("E");

            course.Dispose();
        }

        private static void CourseDelegateFunc(string name, int count){
            Console.WriteLine("Egy ember érkezett. Üdvüzüljétek {0}-t, immáron {1}-en vagyunk. Hurrá!!", name, count);
        }


        private static void Tipp(){
            Thread tipp1 = new Thread(TippTheradFunc) {IsBackground =true }; tipp1.Start();
            Thread tipp2 = new Thread(TippTheradFunc) { IsBackground = true }; tipp2.Start();

            szam = random.Next(100);
            //szam = 69;
            Console.WriteLine(szam);
            startEvenet.Set();
            Thread.Sleep(60000);
            //Thread.CurrentThread.Join();   
        }

        private static void TippTheradFunc(){
            startEvenet.WaitOne();
            while(true){
                lock (foundLock) {
                    if (found) { return; /*Thread.CurrentThread.Join();*/ }
                    int tipp = random.Next(100);
                    //tipp = 69;
                    Console.WriteLine(tipp);
                    if (tipp == szam) {
                        Console.WriteLine("Nyertem"); found = true;
                        break;
                        //Thread.CurrentThread.Join();
                    }
                }               
                Thread.Sleep(500);               
            }
        }

        private static void AreaFunc(){
            Area area = new Area();
            area.SUS += AreaDelegateFunc;
            try
            {
                area.SquareKM = 10;
                area.SquareKM = 100;
                area.SquareKM = 1000;
                area.SquareKM = 10000;
                area.SquareKM = 100000;
                area.SquareKM = 1000000;
                area.SquareKM = 0;
            }catch(ArgumentException e){
                Console.WriteLine(e.Message);
            }


        }

        private static void AreaDelegateFunc(double regi, double uj){
            Console.WriteLine("Itt valami nagyon SUS, Vitya te vagy az??? Régi: {0}, új: {1}", regi, uj);
        }
    }
}