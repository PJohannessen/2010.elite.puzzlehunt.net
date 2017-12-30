namespace PAJ.ElitePuzzleHunt.BusinessObjects
{
   public enum CreateUserResult
   {
       InsufficientData,
       UsernameTaken,
       UserCreatedSuccessfully
   }

    public enum CreateTeamResult
    {
        UserDoesNotExist,
        UserInExistingTeam,
        NameTaken,
        TeamCreatedSuccessfully
    }

    public enum JoinTeamResult
    {
        TeamFull,
        UserInExistingTeam,
        TeamDoesNotExist,
        PasswordIncorrect,
        TeamJoinedSuccessfully
    }

    public enum LoginResult
    {
        IncorrectCredentials,
        LoginSuccessful
    }

    public enum PuzzleStatusResult
    {
        NotInTeam,
        NotStarted,
        Incomplete,
        Complete
    }

    public enum SubmitAnswerResult
    {
        Incorrect,
        Correct,
        AlreadyAnswered
    }
}
