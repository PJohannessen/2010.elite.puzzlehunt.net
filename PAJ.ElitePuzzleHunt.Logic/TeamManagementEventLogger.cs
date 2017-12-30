using System;
using System.Collections.Generic;
using System.Web;
using PAJ.ElitePuzzleHunt.BusinessObjects;
using PAJ.ElitePuzzleHunt.Data;
using PAJ.ElitePuzzleHunt.Logic.Interfaces;
using Team=PAJ.ElitePuzzleHunt.BusinessObjects.Team;

namespace PAJ.ElitePuzzleHunt.Logic
{
    public class TeamManagementEventLogger : ITeamManagement
    {
        private readonly ITeamManagement _TeamManagement;
        
        private const string TeamCreatedLogTemplate = "A new team has been created with the name '{0}' by the user with the name '{1}' from the IP Address '{2}'";
        private const string TeamJoinedLogTemplate = "The user with the name '{0}' has joined the team with the name '{1}' from the IP Address '{2}'";

        public TeamManagementEventLogger(ITeamManagement decoratedTeamManagement)
        {
            _TeamManagement = decoratedTeamManagement;
        }

        public IEnumerable<Team> GetTeams()
        {
            return _TeamManagement.GetTeams();
        }

        public Team GetTeam(string teamName)
        {
            return _TeamManagement.GetTeam(teamName);
        }

        public CreateTeamResult CreateTeam(string username, string name, string password)
        {
            CreateTeamResult createTeamResult = _TeamManagement.CreateTeam(username, name, password);
            
            if (createTeamResult == CreateTeamResult.TeamCreatedSuccessfully)
            {
                WriteLogEntry(string.Format(TeamCreatedLogTemplate, name, username, HttpContext.Current.Request.UserHostAddress), DateTime.UtcNow);
            }

            return createTeamResult;
        }

        public JoinTeamResult JoinTeam(string username, string teamName, string password)
        {
            JoinTeamResult joinTeamResult = _TeamManagement.JoinTeam(username, teamName, password);
            
            if (joinTeamResult == JoinTeamResult.TeamJoinedSuccessfully)
            {
                WriteLogEntry(string.Format(TeamJoinedLogTemplate, username, teamName, HttpContext.Current.Request.UserHostAddress), DateTime.UtcNow);
            }

            return joinTeamResult;
        }

        private void WriteLogEntry(string message, DateTime time)
        {
            using (DatabaseDataContext dataContext = new DatabaseDataContext(DatabaseConfig.ConnectionString))
            {
                Logging newLog = new Logging
                {
                    Message = message,
                    Time = time
                };
                dataContext.Loggings.InsertOnSubmit(newLog);
                dataContext.SubmitChanges();
            }
        }
    }
}
