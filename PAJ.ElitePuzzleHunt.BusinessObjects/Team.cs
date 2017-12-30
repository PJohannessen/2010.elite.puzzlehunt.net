using System.Collections.Generic;

namespace PAJ.ElitePuzzleHunt.BusinessObjects
{
    public class Team
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<Player> Members { get; set; }

        public Team(int id, string name, IEnumerable<Player> members)
        {
            Id = id;
            Name = name;
            Members = members;
        }
    }
}
