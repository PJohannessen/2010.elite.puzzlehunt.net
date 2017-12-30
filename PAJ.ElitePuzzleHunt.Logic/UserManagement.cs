using System.Collections.Generic;
using PAJ.ElitePuzzleHunt.BusinessObjects;
using PAJ.ElitePuzzleHunt.Data;
using PAJ.ElitePuzzleHunt.Logic.Interfaces;
using System;
using System.Linq;
using Player = PAJ.ElitePuzzleHunt.BusinessObjects.Player;
using Team = PAJ.ElitePuzzleHunt.BusinessObjects.Team;

namespace PAJ.ElitePuzzleHunt.Logic
{
    public class UserManagement : IUserManagement
    {
        public IEnumerable<Player> GetUsers()
        {
            using (var context = new DatabaseDataContext(DatabaseConfig.ConnectionString))
            {
                var dataUsers = from user in context.Users
                                select user;
                List<Player> users = new List<Player>();
                foreach (var user in dataUsers)
                {
                    Team team = null;

                    if (user.Team != null)
                    {
                        team = new Team(user.Team.Id, user.Team.Name, null);
                    }
                    
                    users.Add(new Player(user.Id, user.Name, team));
                }

                return users.AsEnumerable();
            }
        }

        public Player GetUser(string username)
        {
            using (var context = new DatabaseDataContext(DatabaseConfig.ConnectionString))
            {
                var dataUser = (from user in context.Users
                                where user.Name == username
                                select user).SingleOrDefault();
                if (dataUser == null) return null;

                Team team = null;
                if (dataUser.Team != null)
                {
                    team = new Team(dataUser.Team.Id, dataUser.Team.Name, null);
                }

                Player player = new Player(dataUser.Id, dataUser.Name, team);
                return player;
            }
        }

        public CreateUserResult CreateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return CreateUserResult.InsufficientData;
            }

            using (var context = new DatabaseDataContext(DatabaseConfig.ConnectionString))
            {
                /* Determine if username is taken */
                var usernameTaken = (from user in context.Users
                                     where user.Name == username
                                     select user).Count() != 0;
                if (usernameTaken) { return CreateUserResult.UsernameTaken; }

                /* Create user */
                Security security = new Security();
                Guid salt = Guid.NewGuid();
                string hashedPassword = security.HashPassword(password, salt);
                var player = new User
                                 {
                                     Name = username,
                                     Password = hashedPassword,
                                     PasswordSalt = salt.ToString("N")
                                 };
                context.Users.InsertOnSubmit(player);
                context.SubmitChanges();

                return CreateUserResult.UserCreatedSuccessfully;
            }
        }

        public bool UserInTeam(string username)
        {
            using (var context = new DatabaseDataContext(DatabaseConfig.ConnectionString))
            {
                var user = (from player in context.Users
                            where player.Name == username
                            select player).SingleOrDefault();
                if (user == null) return true;
                return user.TeamId != null;
            }
        }
    }
}
