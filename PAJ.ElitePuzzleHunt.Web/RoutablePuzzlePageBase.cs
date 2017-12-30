using System.Collections.Generic;
using PAJ.ElitePuzzleHunt.BusinessObjects;
using PAJ.ElitePuzzleHunt.Logic.Interfaces;

namespace PAJ.ElitePuzzleHunt.Web
{
    public abstract class RoutablePuzzlePageBase : RoutableHuntPageBase
    {
        protected int PuzzleId;

        protected bool ValidatePuzzleStatus()
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login/");
            }

            string username = Context.User.Identity.Name;

            IPuzzleManagement puzzleManagement = CreatePuzzleManagement();
            PuzzleStatusResult status = puzzleManagement.GetPuzzleStatus(PuzzleId, username);
            bool isAnswered = false;

            switch (status)
            {
                case PuzzleStatusResult.NotInTeam:
                    Response.Redirect("~/Puzzles/");
                    break;
                case PuzzleStatusResult.NotStarted:
                    puzzleManagement.StartPuzzle(PuzzleId, username);
                    break;
                case PuzzleStatusResult.Complete:
                    isAnswered = true;
                    break;
            }

            return isAnswered;
        }

        protected IEnumerable<string> GetHints()
        {
            string username = Context.User.Identity.Name;
            IPuzzleManagement puzzleManagement = CreatePuzzleManagement();
            return puzzleManagement.GetHints(PuzzleId, Context.User.Identity.Name);
        }

        protected SubmitAnswerResult SubmitAnswer(string answer, string username)
        {
            IPuzzleManagement puzzleManagement = CreatePuzzleManagement();
            return puzzleManagement.SubmitPuzzleAnswer(PuzzleId, answer, username);
        }
    }
}
