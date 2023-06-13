using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22ZhConsole
{

    public delegate void PublishDelegate(string s);
    public class NewsServer
    {
        public event PublishDelegate Publish;
        public void PublicNews(string s){
            if(s == null){ throw new ArgumentNullException(); }
            Publish?.Invoke(s);
        }
    }
}
