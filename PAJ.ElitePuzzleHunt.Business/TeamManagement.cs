﻿using System;
using System.Linq;
using PAJ.ElitePuzzleHunt.Data;
using PAJ.ElitePuzzleHunt.BusinessObjects;
using System.Collections.Generic;
using Player = PAJ.ElitePuzzleHunt.BusinessObjects.Player;
using Team = PAJ.ElitePuzzleHunt.BusinessObjects.Team;


namespace PAJ.ElitePuzzleHunt.Business
{
    public class TeamManagement
    {
        public IEnumerable<Team> GetTeams()
        {
            using (var context = new DatabaseDataContext())
            {
                var dataTeams = from team in context.Teams
                                select team;
                List<Team> teams = new List<Team>();
                foreach (var team in dataTeams)
                {
                    List<Player> players = new List<Player>();
                    foreach (var player in players)
                    {
                        players.Add(new Player(player.Id, player.Username, player.Location));
                    }
                    teams.Add(new Team(team.Id, team.Name, players.AsEnumerable()));
                }

                return teams.AsEnumerable();
            }
        }

        public Team GetTeam(string teamName)
        {
            using (var context = new DatabaseDataContext())
            {
                var dataTeam = (from team in context.Teams
                               where team.Name == teamName
                               select team).SingleOrDefault();
                if (dataTeam == null) return null;
                
                List<Player> players = new List<Player>();
                foreach (var player in players)
                {
                    players.Add(new Player(player.Id, player.Username, player.Location));
                }
                Team existingTeam = new Team(dataTeam.Id, dataTeam.Name, players.AsEnumerable());
                return existingTeam;
            }
        }

        public CreateTeamResult CreateTeam(int userId, string name, string password)
        {
            using (var context = new DatabaseDataContext())
            {
                /* Determine if user exists */
                var dataUser = (from user in context.Players
                                where user.Id == userId
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
                string hashedPassword = security.HashPassword(name, salt);
                var newTeam = new Data.Team
                {
                    Name = name,
                    Password = hashedPassword,
                    Salt = salt.ToString("N")
                };

                context.Teams.InsertOnSubmit(newTeam);
                context.SubmitChanges();
                dataUser.TeamId = newTeam.Id;
                context.SubmitChanges();

                return CreateTeamResult.TeamCreatedSuccessfully;
            }
        }

        public JoinTeamResult JoinTeam(int userId, int teamId, string password)
        {
            using (var context = new DatabaseDataContext())
            {

                /* Determine if user exists, and if so, whether or not they are in a team already. */
                var player = (from user in context.Players
                              where user.Id == userId
                              select user).SingleOrDefault();
                if (player == null) throw new ArgumentOutOfRangeException("userId", "User does not exist.");
                if (player.TeamId == null) return JoinTeamResult.UserInExistingTeam;

                /* Determine if team exists, and if so, whether or not it is full. */
                Data.Team teamToJoin = (from team in context.Teams
                                        where team.Id == teamId
                                        select team).SingleOrDefault();
                if (teamToJoin == null) return JoinTeamResult.TeamDoesNotExist;
                if (teamToJoin.Players.Count() >= 2) return JoinTeamResult.TeamFull;

                /* Determine if supplied password is correct. */
                Security security = new Security();
                if (security.HashPassword(password, new Guid(teamToJoin.Salt)) != teamToJoin.Password)
                    return JoinTeamResult.PasswordIncorrect;

                /* Join team */
                player.TeamId = teamId;
                context.SubmitChanges();

                return JoinTeamResult.TeamJoinedSuccessfully;
            }
        }


    }
}
