using System;
using PAJ.ElitePuzzleHunt.Logic.Interfaces;

namespace PAJ.ElitePuzzleHunt.Web
{
    public partial class Users : RoutableHuntPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IUserManagement userManagement = CreateUserManagement();
            UserList.Users = userManagement.GetUsers();
        }
    }
}