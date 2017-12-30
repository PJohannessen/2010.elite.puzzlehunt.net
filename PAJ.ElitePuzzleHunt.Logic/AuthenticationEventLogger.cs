using System;
using System.Web;
using PAJ.ElitePuzzleHunt.BusinessObjects;
using PAJ.ElitePuzzleHunt.Data;
using PAJ.ElitePuzzleHunt.Logic.Interfaces;

namespace PAJ.ElitePuzzleHunt.Logic
{
    public class AuthenticationEventLogger : IAuthentication
    {
        private readonly IAuthentication _Authentication;
        private const string LoginSuccessfulLogTemplate = "The user '{0}' successfully logged in from the IP Address '{1}'";

        public AuthenticationEventLogger(IAuthentication decoratedAuthentication)
        {
            _Authentication = decoratedAuthentication;
        }

        public LoginResult Login(string username, string password)
        {
            LoginResult loginResult = _Authentication.Login(username, password);
            if (loginResult == LoginResult.LoginSuccessful)
            {
                WriteLogEntry(string.Format(LoginSuccessfulLogTemplate, username, HttpContext.Current.Request.UserHostAddress), DateTime.UtcNow);
            }
            return loginResult;
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
