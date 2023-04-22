namespace Zh2022_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NewsServer server = new NewsServer();
            server.Publish += DelegateFunc;
            server.PublicNews("Grafika", "Sajnálom Uram, Ön megbukott grafikából, jöjjön legközelebb :D", "Kanos");
        }

        public static void DelegateFunc(string t, string a, string n){
            Console.WriteLine("{0}\n{1}\n{2}", t, n, a);
        }
    }

}
