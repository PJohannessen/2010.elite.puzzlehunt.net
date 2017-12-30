using System;
using PAJ.ElitePuzzleHunt.BusinessObjects;

namespace PAJ.ElitePuzzleHunt.Web
{
    public partial class Puzzle6 : RoutablePuzzlePageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PuzzleId = 6;
            bool isAnswered = ValidatePuzzleStatus();
            if (isAnswered)
            {
                Result.Text = "You have already answered this puzzle correctly.";
                Submit.Visible = false;
                answer.Visible = false;
            }
            PuzzleHints.Hints = GetHints();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            bool pageIsValid = ValidateInput();

            if (pageIsValid)
            {
                SubmitAnswerResult result = SubmitAnswer(answer.Text, Context.User.Identity.Name);
                switch (result)
                {
                    case SubmitAnswerResult.AlreadyAnswered:
                        Result.Text = "You have already answered this puzzle correctly.";
                        break;
                    case SubmitAnswerResult.Incorrect:
                        Result.Text = "The answer you submitted is incorrect.";
                        break;
                    case SubmitAnswerResult.Correct:
                        Result.Text = "Correct! Please move on to the next puzzle.";
                        break;
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(answer.Text))
            {
                Result.Text = "No answer entered.";
                return false;
            }

            return true;
        }
    }
}
