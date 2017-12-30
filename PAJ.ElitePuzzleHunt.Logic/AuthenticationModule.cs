using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Security;

namespace PAJ.ElitePuzzleHunt.Logic
{
    public class AuthenticationModule : IHttpModule
    {
        private readonly IFormatter _Formatter;

        public AuthenticationModule()
        {
            _Formatter = new BinaryFormatter();
        }

        #region IHttpModule Members

        public void Init(HttpApplication context)
        {
            context.PostAuthenticateRequest += context_PostAuthenticateRequest;
            context.EndRequest += context_EndRequest;
        }

        public void Dispose()
        {
        }

        #endregion

        private static void context_EndRequest(object sender, EventArgs e)
        {
            HttpContext.Current.User = null;
            Thread.CurrentPrincipal = null;
        }

        private void context_PostAuthenticateRequest(object sender, EventArgs e)
        {
            IPrincipal currentPrincipal = HttpContext.Current.User;

            if (currentPrincipal.Identity is FormsIdentity)
            {
                FormsIdentity currentFormsIdentity = (FormsIdentity)currentPrincipal.Identity;
                string userData = currentFormsIdentity.Ticket.UserData;
                byte[] userDataArray = Convert.FromBase64String(userData);

                using (MemoryStream ms = new MemoryStream(userDataArray))
                {
                    using (GZipStream gz = new GZipStream(ms, CompressionMode.Decompress))
                    {
                        IPrincipal customPrincipal = (IPrincipal)_Formatter.Deserialize(gz);


                        HttpContext.Current.User = customPrincipal;
                        Thread.CurrentPrincipal = customPrincipal;
                    }
                }
            }
        }

        public static void SetAuthenticationTicket(IPrincipal user)
        {
            if (user == null) throw new ArgumentNullException("user");
            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(user.Identity.Name, false);
            FormsAuthenticationTicket tempTicket = FormsAuthentication.Decrypt(authCookie.Value);
            using (MemoryStream ms = new MemoryStream())
            {
                string userData;
                using (GZipStream gZipStream = new GZipStream(ms, CompressionMode.Compress))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(gZipStream, user);
                    gZipStream.Close();
                    ms.Close();
                    byte[] userDataArray = ms.ToArray();
                    userData = Convert.ToBase64String(userDataArray);
                }
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                    tempTicket.Version, tempTicket.Name, tempTicket.IssueDate,
                    tempTicket.Expiration,
                    false, userData);
                authCookie.Value = FormsAuthentication.Encrypt(authTicket);
                HttpContext.Current.Response.Cookies.Add(authCookie);
            }
        }
    }
}
