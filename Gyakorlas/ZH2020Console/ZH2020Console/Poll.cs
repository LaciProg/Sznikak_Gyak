using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2020Console
{
    public delegate void VoteDelegate(string id, int n);
    public class Poll{ 
        public event VoteDelegate OnVote;
    public int VoteCount {
            get;
            private set;
    }
    public void RegisterVote(string CardID){
        if(CardID == null){ throw new ArgumentException("Nem lehet null a CardID"); }
        VoteCount++;
            OnVote?.Invoke(CardID, VoteCount);
    }

    }
}
