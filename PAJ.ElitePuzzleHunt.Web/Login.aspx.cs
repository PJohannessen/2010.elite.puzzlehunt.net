using System;
using PAJ.ElitePuzzleHunt.BusinessObjects;
using PAJ.ElitePuzzleHunt.Logic.Interfaces;

namespace PAJ.ElitePuzzleHunt.Web
{
    public partial class Login : RoutableHuntPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            bool pageIsValid = ValidateInput();

            if (pageIsValid)
            {
                IAuthentication authentication = CreateAuthentication();

                var result = authentication.Login(username.Text, password.Text);

                switch (result)
                {
                    case LoginResult.IncorrectCredentials:
                        Result.Text = "Username or password incorrect.";
                        break;
                    case LoginResult.LoginSuccessful:
                        Response.Redirect("~/Teams/");
                        break;
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(username.Text))
            {
                Result.Text = "No username entered.";
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