using System.Collections.Generic;
using PAJ.ElitePuzzleHunt.BusinessObjects;

namespace PAJ.ElitePuzzleHunt.Logic.Interfaces
{
    public interface ITeamManagement
    {
        IEnumerable<Team> GetTeams();

        Team GetTeam(string teamName);

        CreateTeamResult CreateTeam(string username, string name, string password);

        JoinTeamResult JoinTeam(string username, string teamName, string password);
    }
}
