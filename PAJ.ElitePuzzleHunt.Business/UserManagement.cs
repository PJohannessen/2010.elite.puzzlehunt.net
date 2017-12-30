using System;
using PAJ.ElitePuzzleHunt.BusinessObjects;
using PAJ.ElitePuzzleHunt.Data;
using System.Linq;

namespace PAJ.ElitePuzzleHunt.Business
{
    public class UserManagement
    {
        public CreateUserResult CreateUser(string username, string password, string location)
        {
            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(location)) return CreateUserResult.InsufficientData;

            using (var context = new DatabaseDataContext())
            {
                /* Determine if username is taken */
                var usernameTaken = (from user in context.Players
                                     where user.Username == username
                                     select user).Count() != 0;
                if (usernameTaken) { return CreateUserResult.UsernameTaken; }

                /* Create user */
                Security security = new Security();
                Guid salt = Guid.NewGuid();
                string hashedPassword = security.HashPassword(username, salt);
                var player = new Data.Player
                                 {
                                     Username = username,
                                     Password = hashedPassword,
                                     Location = location,
                                     Salt = salt.ToString("N")
                                 };
                context.Players.InsertOnSubmit(player);
                context.SubmitChanges();

                return CreateUserResult.UserCreatedSuccessfully;
            }
        }
    }
}
