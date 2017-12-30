using PAJ.ElitePuzzleHunt.Logic.Interfaces;
using PAJ.ElitePuzzleHunt.BusinessObjects;
using System;

namespace PAJ.ElitePuzzleHunt.Web
{
    public partial class Signup : RoutableHuntPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            bool pageIsValid = ValidateInput();

            if (pageIsValid)
            {
                IUserManagement userManagement = CreateUserManagement();

                var result = userManagement.CreateUser(username.Text, password.Text);

                switch (result)
                {
                    case CreateUserResult.UsernameTaken:
                        Result.Text = "Username taken.";
                        break;
                    case CreateUserResult.UserCreatedSuccessfully:
                        Result.Text = "User created!";
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