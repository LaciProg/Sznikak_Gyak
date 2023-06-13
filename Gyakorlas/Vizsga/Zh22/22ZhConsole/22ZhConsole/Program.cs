using System.Text;

namespace _22ZhConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //F1();
            F3();
        }

        private static void F1(){
            NewsServer newsServer = new();
            newsServer.Publish += (s) => Console.WriteLine(s);
            newsServer.PublicNews("XD");
        }

        private static object synobject =new object();
        private static AutoResetEvent AutoResetEvent = new AutoResetEvent(false);
        private static List<int> list = new();

        private static void F3() {
            Thread term = new Thread(teremlo) { IsBackground = true };
            Thread fogy1 = new Thread(fogyaszto);
            Thread fogy2 = new Thread(fogyaszto);
            Thread fogy3 = new Thread(fogyaszto);
            Thread fogy4 = new Thread(fogyaszto);
            Thread fogy5 = new Thread(fogyaszto);
            term.Start();
            fogy1.Start();
            fogy2.Start();
            fogy3.Start();
            fogy4.Start();
            fogy5.Start();
        }

        private static void teremlo(){
            int i = 0;
            while (true)
            {
                lock (synobject)
                {
                    list.Add(i);
                }
                i++;
                if (list.Count == 30) { AutoResetEvent.Set(); }
                Thread.Sleep(100);
            }
        }
        private static void fogyaszto()
        {
            AutoResetEvent.WaitOne();
            lock(synobject){
                list.Clear();
                Console.WriteLine("Megtelt");
            }
        }
    }
}