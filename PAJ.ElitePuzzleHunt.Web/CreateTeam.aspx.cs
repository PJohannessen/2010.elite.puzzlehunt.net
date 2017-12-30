using System;
using PAJ.ElitePuzzleHunt.BusinessObjects;
using PAJ.ElitePuzzleHunt.Logic.Interfaces;

namespace PAJ.ElitePuzzleHunt.Web
{
    public partial class CreateTeam : RoutableHuntPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login/");
            }

            IUserManagement userManagement = CreateUserManagement();
            bool isInTeam = userManagement.UserInTeam(Context.User.Identity.Name);
            if (isInTeam)
            {
                Result.Text = "You are already in a team!";
                Submit.Enabled = false;
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            bool pageIsValid = ValidateInput();

            if (pageIsValid)
            {
                ITeamManagement teamManagement = CreateTeamManagement();
                var result = teamManagement.CreateTeam(User.Identity.Name, teamName.Text, password.Text);

                switch (result)
                {
                    case CreateTeamResult.UserDoesNotExist:
                        Result.Text = "Specified user does not exist.";
                        break;
                    case CreateTeamResult.UserInExistingTeam:
                        Result.Text = "Cannot create team as you are already assigned to one.";
                        break;
                    case CreateTeamResult.NameTaken:
                        Result.Text = "The team name you specified has already been taken.";
                        break;
                    case CreateTeamResult.TeamCreatedSuccessfully:
                        Result.Text = "Team created successfully!";
                        break;
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(teamName.Text))
            {
                Result.Text = "No team name entered.";
                return false;
            }
            if (string.IsNullOrEmpty(password.Text))
            {
                Result.Text = "No password entered.";
                return false;
            }

            return true;
        }
    }
}