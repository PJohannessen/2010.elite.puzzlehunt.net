using System.Linq;
using PAJ.ElitePuzzleHunt.BusinessObjects;
using PAJ.ElitePuzzleHunt.Logic.Interfaces;
using System;

namespace PAJ.ElitePuzzleHunt.Web
{
    public partial class Team : RoutableHuntPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ITeamManagement teamManagement = CreateTeamManagement();
            BusinessObjects.Team team = teamManagement.GetTeam(RouteData.Values["name"] as string);
            ViewTeam.Team = team;

            if (team.Members.Count() >= 2)
            {
                Result.Text = "This team is full!";
                Submit.Visible = false;
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login/");
            }

            if (ValidateInput())
            {
                string username = User.Identity.Name;

                ITeamManagement teamManagement = CreateTeamManagement();
                JoinTeamResult result = teamManagement.JoinTeam(username, RouteData.Values["name"] as string, password.Text);

                switch (result)
                {
                    case JoinTeamResult.UserInExistingTeam:
                        Result.Text = "You are already in a team!";
                        break;
                    case JoinTeamResult.TeamFull:
                        Result.Text = "The team is full!";
                        break;
                    case JoinTeamResult.PasswordIncorrect:
                        Result.Text = "The password you entered is incorrect";
                        break;
                    case JoinTeamResult.TeamJoinedSuccessfully:
                        Result.Text = "Welcome to the team!";
                        break;
                }
            }
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(password.Text))
            {
                isValid = false;
                Result.Text = "Please enter a password.";
            }
            return isValid;
        }
    }
}