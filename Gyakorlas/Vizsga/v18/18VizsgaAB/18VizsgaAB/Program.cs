namespace _18VizsgaAB
{
    internal class Program
    {
        static List<int> values = new();
        static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        static object lockObject = new();
        static object syncObject = new object();

        static void Main(string[] args)
        {
            lock (syncObject)
            {
                f();
            }
        
            F1();
            F3();
        }
        static void f()
        {
            lock (syncObject)
            {
                Console.WriteLine("Hello!");
            }
        }

        private static void F3() {
            Thread thread = new Thread(ThreadFunc) { IsBackground = true };     
            thread.Start();
            values.Add(new Random().Next());
            autoResetEvent.Set();
            thread.Join();
        }
        private static void ThreadFunc(){
            autoResetEvent.WaitOne();
            int val = values.First();
            values.Remove(values.First());
            Console.WriteLine(val);
        }

        private static int GetCount(){
            lock(lockObject){
                return values.Count;
            }
        }

        private static void F1(){
            Course course = new();
            course.nameDelegate += (name, num) => Console.WriteLine(name + "\t{0}", num);
            course.register("Béla");
            course.register("Lajcsi");
            course.register("Józsi");
        }
    }
}