using PAJ.ElitePuzzleHunt.BusinessObjects;

namespace PAJ.ElitePuzzleHunt.Logic.Interfaces
{
    public interface IAuthentication
    {
        LoginResult Login(string username, string password);
    }
}
