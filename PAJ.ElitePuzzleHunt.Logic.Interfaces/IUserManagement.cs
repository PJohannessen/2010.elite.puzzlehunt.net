using System.Collections.Generic;
using PAJ.ElitePuzzleHunt.BusinessObjects;

namespace PAJ.ElitePuzzleHunt.Logic.Interfaces
{
    public interface IUserManagement
    {
        CreateUserResult CreateUser(string username, string password);
        IEnumerable<Player> GetUsers();
        Player GetUser(string username);
        bool UserInTeam(string username);
    }
}
