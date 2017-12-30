using System;
using System.Linq;
using System.Security.Principal;
using PAJ.ElitePuzzleHunt.BusinessObjects;
using PAJ.ElitePuzzleHunt.Data;
using PAJ.ElitePuzzleHunt.Logic.Interfaces;

namespace PAJ.ElitePuzzleHunt.Logic
{
    public class Authentication : IAuthentication
    {
        public LoginResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username)) { throw new ArgumentNullException("username"); }
            if (string.IsNullOrEmpty(password)) { throw new ArgumentNullException("password"); }

            using (DatabaseDataContext context = new DatabaseDataContext(DatabaseConfig.ConnectionString))
            {
                var currentUser = (from user in context.Users
                                   where user.Name == username
                                   select user).SingleOrDefault();

                if (currentUser == null) return LoginResult.IncorrectCredentials;

                Security security = new Security();
                string hashedPassword = security.HashPassword(password, new Guid(currentUser.PasswordSalt));
                if (currentUser.Password != hashedPassword) { return LoginResult.IncorrectCredentials; }

                Login(username, UserPermissions.AuthenticatedUser);
                return LoginResult.LoginSuccessful;
            }
        }

        private void Login(string userId, UserPermissions permissions)
        {
            UserPrincipal newPrincipal = new UserPrincipal(new GenericIdentity(userId), permissions);
            AuthenticationModule.SetAuthenticationTicket(newPrincipal);
        }
    }
}
