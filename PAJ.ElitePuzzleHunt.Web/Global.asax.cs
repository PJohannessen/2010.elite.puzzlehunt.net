using System;
using System.Web;
using System.Web.Routing;
using WebFormRouting;

namespace PAJ.ElitePuzzleHunt.Web
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        private void RegisterRoutes(RouteCollection routes)
        {
            routes.MapWebFormRoute(
                "rules",
                "Rules",
                "~/Rules.aspx");

            routes.MapWebFormRoute(
                "faq",
                "FAQ",
                "~/FAQ.aspx");

            routes.MapWebFormRoute(
                "contacts",
                "Contacts",
                "~/Contacts.aspx");

            routes.MapWebFormRoute(
                "teams-browse",
                "Teams",
                "~/Teams.aspx");

            routes.MapWebFormRoute(
                "teams-view",
                "Teams/{name}",
                "~/Team.aspx");

            routes.MapWebFormRoute(
                "users-browse",
                "Users",
                "~/Users.aspx");

            routes.MapWebFormRoute(
                "users-view",
                "Users/{name}",
                "~/User.aspx");

            routes.MapWebFormRoute(
                "user-signup",
                "Signup",
                "~/Signup.aspx");

            routes.MapWebFormRoute(
                "user-login",
                "Login",
                "~/Login.aspx");

            routes.MapWebFormRoute(
                "team-create",
                "Create Team",
                "~/CreateTeam.aspx");

            routes.MapWebFormRoute(
                "puzzle1",
                "Puzzles/Puzzle1",
                "~/Puzzle1.aspx");

            routes.MapWebFormRoute(
                "puzzle2",
                "Puzzles/Puzzle2",
                "~/Puzzle2.aspx");

            routes.MapWebFormRoute(
                "puzzle3",
                "Puzzles/Puzzle3",
                "~/Puzzle3.aspx");

            routes.MapWebFormRoute(
                "puzzle4",
                "Puzzles/Puzzle4",
                "~/Puzzle4.aspx");

            routes.MapWebFormRoute(
                "puzzle5",
                "Puzzles/Puzzle5",
                "~/Puzzle5.aspx");

            routes.MapWebFormRoute(
                "puzzle6",
                "Puzzles/Puzzle6",
                "~/Puzzle6.aspx");

            routes.MapWebFormRoute(
                "puzzle7",
                "Puzzles/Puzzle7",
                "~/Puzzle7.aspx");

            routes.MapWebFormRoute(
                "puzzle8",
                "Puzzles/Puzzle8",
                "~/Puzzle8.aspx");

            routes.MapWebFormRoute(
                "puzzle9",
                "Puzzles/Puzzle9",
                "~/Puzzle9.aspx");

            routes.MapWebFormRoute(
                "puzzle10",
                "Puzzles/Puzzle10",
                "~/Puzzle10.aspx");

            routes.MapWebFormRoute(
                "puzzles-browse",
                "Puzzles",
                "~/Puzzles.aspx");

            routes.MapWebFormRoute(
                "GYSHGKWIV",
                "GYSHGKWIV",
                "~/GYSHGKWIV.aspx");

            routes.MapWebFormRoute(
                "BQWTIVLAO",
                "BQWTIVLAO",
                "~/BQWTIVLAO.aspx");

            routes.MapWebFormRoute(
                "IGWUOKMER",
                "IGWUOKMER",
                "~/IGWUOKMER.aspx");

            routes.MapWebFormRoute(
                "JRYWGVAAW",
                "JRYWGVAAW",
                "~/JRYWGVAAW.aspx");

            
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}