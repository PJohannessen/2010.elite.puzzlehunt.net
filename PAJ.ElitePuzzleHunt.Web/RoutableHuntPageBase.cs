using PAJ.ElitePuzzleHunt.Logic;
using PAJ.ElitePuzzleHunt.Logic.Interfaces;
using WebFormRouting;

namespace PAJ.ElitePuzzleHunt.Web
{
    public abstract class RoutableHuntPageBase : RoutablePage
    {
        protected IUserManagement CreateUserManagement()
        {
            IUserManagement userManagement = new UserManagementEventLogger(new UserManagement());
            return userManagement;
        }

        protected ITeamManagement CreateTeamManagement()
        {
            ITeamManagement teamManagement = new TeamManagementEventLogger(new TeamManagement());
            return teamManagement;
        }

        protected IAuthentication CreateAuthentication()
        {
            IAuthentication authentication = new AuthenticationEventLogger(new Authentication());
            return authentication;
        }

        protected IPuzzleManagement CreatePuzzleManagement()
        {
            IPuzzleManagement puzzleManagement = new PuzzleManagementEventLogger(new PuzzleManagement());
            return puzzleManagement;
        }
    }
}
