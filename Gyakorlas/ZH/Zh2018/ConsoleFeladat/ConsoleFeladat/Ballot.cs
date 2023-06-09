namespace ConsoleFeladat{ 
    public delegate void VoteDelegate(string name, int num);
    public class Ballot
    {
        public event VoteDelegate vote;

        public int VoteNumber { get; private set; }

        public void CreateVote(string name)
        {
            VoteNumber++;
            vote?.Invoke(name, VoteNumber);
        }

    }
}

