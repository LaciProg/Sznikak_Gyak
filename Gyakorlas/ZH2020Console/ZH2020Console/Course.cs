namespace ZH2020Console
{
    public delegate void NewStudentDelegate(string name, int count);
    public class Course :IDisposable
    {
    public event NewStudentDelegate studentDelegate;
        public int Count{ get; private set; }
        public void Register(string name){
            if(name.Equals("")){ throw new ArgumentException("A név nem lehet üres"); }
            Count++;
            studentDelegate?.Invoke(name, Count);
            
        }

        public void Dispose()
        {
            Console.WriteLine("Fürdés idő!");
        }
    }
}
