using System;
using PAJ.ElitePuzzleHunt.BusinessObjects;
using PAJ.ElitePuzzleHunt.Logic.Interfaces;

namespace PAJ.ElitePuzzleHunt.Web
{
    public partial class User : RoutableHuntPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IUserManagement userManagement = CreateUserManagement();
            Player player = userManagement.GetUser(RouteData.Values["name"] as string);
            ViewUser.User = player;
        }
    }
}