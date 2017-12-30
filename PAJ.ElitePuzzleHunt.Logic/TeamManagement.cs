using System;
using System.Linq;
using PAJ.ElitePuzzleHunt.Data;
using PAJ.ElitePuzzleHunt.BusinessObjects;
using System.Collections.Generic;
using Player = PAJ.ElitePuzzleHunt.BusinessObjects.Player;
using Team = PAJ.ElitePuzzleHunt.BusinessObjects.Team;
using PAJ.ElitePuzzleHunt.Logic.Interfaces;


namespace PAJ.ElitePuzzleHunt.Logic
{
    public class TeamManagement : ITeamManagement
    {
        public IEnumerable<Team> GetTeams()
        {
            using (var context = new DatabaseDataContext(DatabaseConfig.ConnectionString))
            {
                var dataTeams = from team in context.Teams
                                select team;

                List<Team> teams = new List<Team>();
                foreach (var team in dataTeams)
                {
                    Team currentTeam = null; 
                    List<Player> players = new List<Player>();
                    foreach (var player in team.Users)
                    {
                        players.Add(new Player(player.Id, player.Name, currentTeam));
                    }
                    currentTeam = new Team(team.Id, team.Name, players.AsEnumerable());
                    teams.Add(currentTeam);
                }

                return teams.AsEnumerable();
            }
        }

        public Team GetTeam(string teamName)
        {
            using (var context = new DatabaseDataContext(DatabaseConfig.ConnectionString))
            {
                var dataTeam = (from team in context.Teams
                               where team.Name == teamName
                               select team).SingleOrDefault();
                if (dataTeam == null) return null;
                
                List<Player> players = new List<Player>();
                foreach (var player in dataTeam.Users)
                {
                    players.Add(new Player(player.Id, player.Name, null));
                }
                Team existingTeam = new Team(dataTeam.Id, dataTeam.Name, players.AsEnumerable());
                return existingTeam;
            }
        }

        public CreateTeamResult CreateTeam(string username, string name, string password)
        {
            using (var context = new DatabaseDataContext(DatabaseConfig.ConnectionString))
            {
                /* Determine if user exists */
                var dataUser = (from user in context.Users
                                where user.Name == username
                                select user).SingleOrDefault();
                if (dataUser == null) return CreateTeamResult.UserDoesNotExist;
                if (dataUser.TeamId != null) return CreateTeamResult.UserInExistingTeam;
                
                /* Determine if supplied team name is taken */
                bool nameTaken = (from team in context.Teams
                                  where team.Name == name
                                  select team).Count() != 0;
                if (nameTaken) { return CreateTeamResult.NameTaken; }

                
                Security security = new Security();
                Guid salt = Guid.NewGuid();
                string hashedPassword = security.HashPassword(password, salt);
                var newTeam = new Data.Team
                {
                    Name = name,
                    Password = hashedPassword,
                    PasswordSalt = salt.ToString("N")
                };

                context.Teams.InsertOnSubmit(newTeam);
                context.SubmitChanges();
                dataUser.TeamId = newTeam.Id;
                context.SubmitChanges();

                return CreateTeamResult.TeamCreatedSuccessfully;
            }
        }

        public JoinTeamResult JoinTeam(string username, string teamName, string password)
        {
            using (var context = new DatabaseDataContext(DatabaseConfig.ConnectionString))
            {

                /* Determine if user exists, and if so, whether or not they are in a team already. */
                var player = (from user in context.Users
                              where user.Name == username
                              select user).Single();
                
                if (player.TeamId != null) return JoinTeamResult.UserInExistingTeam;

                /* Determine if team exists, and if so, whether or not it is full. */
                Data.Team teamToJoin = (from team in context.Teams
                                        where team.Name == teamName
                                        select team).SingleOrDefault();
                if (teamToJoin == null) return JoinTeamResult.TeamDoesNotExist;
                if (teamToJoin.Users.Count() >= 2) return JoinTeamResult.TeamFull;

                /* Determine if supplied password is correct. */
                Security security = new Security();
                string hashedPassword = security.HashPassword(password, new Guid(teamToJoin.PasswordSalt));
                if (hashedPassword != teamToJoin.Password)
                {
                    return JoinTeamResult.PasswordIncorrect;
                }

                /* Join team */
                player.TeamId = teamToJoin.Id;
                context.SubmitChanges();

                return JoinTeamResult.TeamJoinedSuccessfully;
            }
        }
    }
}
