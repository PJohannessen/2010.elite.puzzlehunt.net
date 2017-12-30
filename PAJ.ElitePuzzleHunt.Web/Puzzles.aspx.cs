using System;
using PAJ.ElitePuzzleHunt.Logic.Interfaces;

namespace PAJ.ElitePuzzleHunt.Web
{
    public partial class Puzzles : RoutableHuntPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login/");
            }

            IUserManagement userManagement = CreateUserManagement();
            string username = Context.User.Identity.Name;

            if (userManagement.UserInTeam(username))
            {
                PuzzleList._ValidUser = true;
                IPuzzleManagement puzzleManagement = CreatePuzzleManagement();
                PuzzleList.Puzzles = puzzleManagement.GetPuzzles(username);
            }

            PuzzleList.Visible = false;
        }
    }
}
