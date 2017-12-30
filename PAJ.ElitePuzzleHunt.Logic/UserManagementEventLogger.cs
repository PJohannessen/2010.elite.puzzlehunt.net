using System.Collections.Generic;
using System.Web;
using PAJ.ElitePuzzleHunt.BusinessObjects;
using PAJ.ElitePuzzleHunt.Data;
using PAJ.ElitePuzzleHunt.Logic.Interfaces;
using System;

namespace PAJ.ElitePuzzleHunt.Logic
{
    public class UserManagementEventLogger : IUserManagement
    {
        private readonly IUserManagement _UserManagement;
        private const string UserCreatedLogTemplate = "A new user has been created with the name '{0}' from the IP Address '{1}'";

        public UserManagementEventLogger(IUserManagement decoratedUserManagement)
        {
            _UserManagement = decoratedUserManagement;
        }

        public CreateUserResult CreateUser(string username, string password)
        {
            CreateUserResult createUserResult = _UserManagement.CreateUser(username, password);

            if (createUserResult == CreateUserResult.UserCreatedSuccessfully)
            {
                string message = string.Format(UserCreatedLogTemplate, username, HttpContext.Current.Request.UserHostAddress);
                WriteLogEntry(message, DateTime.UtcNow);
            }

            return createUserResult;
        }

        public IEnumerable<Player> GetUsers()
        {
            return _UserManagement.GetUsers();
        }

        public Player GetUser(string username)
        {
            return _UserManagement.GetUser(username);
        }

        public bool UserInTeam(string username)
        {
            return _UserManagement.UserInTeam(username);
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
