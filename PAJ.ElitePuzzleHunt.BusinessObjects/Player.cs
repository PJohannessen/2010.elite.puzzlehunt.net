namespace PAJ.ElitePuzzleHunt.BusinessObjects
{
    public class Player
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public Team Team { get; private set; }

        public Player(int id, string username, Team team)
        {
            Id = id;
            Username = username;
            Team = team;
        }

        public Player(string username) : this(-1, username, null)
        {   
        }
    }
}
