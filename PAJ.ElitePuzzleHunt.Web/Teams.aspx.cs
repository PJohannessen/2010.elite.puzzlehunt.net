using System;
using PAJ.ElitePuzzleHunt.Logic.Interfaces;

namespace PAJ.ElitePuzzleHunt.Web
{
    public partial class Teams : RoutableHuntPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ITeamManagement teamManagement = CreateTeamManagement();
            TeamList.Teams = teamManagement.GetTeams();
        }
    }
}
