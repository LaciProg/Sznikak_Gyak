namespace Zh2022_1
{
    public delegate void PublishDelegate(string t, string a, string n);
    public class NewsServer
    {
        public event PublishDelegate Publish;

        public void PublicNews(string t, string a, string n ){
            if(t== null || a== null || n == null){
                throw new Exception("Some arugments are null");            
            }
            Publish?.Invoke(t, n, a);

        }
    }
}
