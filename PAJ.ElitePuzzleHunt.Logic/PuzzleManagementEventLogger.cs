using System;
using System.Collections.Generic;
using System.Web;
using PAJ.ElitePuzzleHunt.BusinessObjects;
using PAJ.ElitePuzzleHunt.Data;
using PAJ.ElitePuzzleHunt.Logic.Interfaces;
using Puzzle=PAJ.ElitePuzzleHunt.BusinessObjects.Puzzle;

namespace PAJ.ElitePuzzleHunt.Logic
{
    public class PuzzleManagementEventLogger : IPuzzleManagement
    {
        private readonly IPuzzleManagement _PuzzleManagement;

        private const string PuzzleStartedLogTemplate = "User '{0}' started puzzle number '{1}' from the IP Address '{2}'";
        private const string PuzzleAnsweredCorrectlyLogTemplate = "User '{0}' succesfully answered puzzle number '{1}' from the IP Address '{2}'";
        private const string PuzzleAnsweredIncorrectlyLogTemplate = "User '{0}' unsuccesfully answered puzzle number '{1}' from the IP Address '{2}' with the answer {3}";


        public PuzzleManagementEventLogger(IPuzzleManagement decoratedPuzzleManagement)
        {
            _PuzzleManagement = decoratedPuzzleManagement;
        }

        public IEnumerable<Puzzle> GetPuzzles(string username)
        {
            return _PuzzleManagement.GetPuzzles(username);
        }

        public PuzzleStatusResult GetPuzzleStatus(int id, string username)
        {
            return _PuzzleManagement.GetPuzzleStatus(id, username);
        }

        public SubmitAnswerResult SubmitPuzzleAnswer(int id, string answer, string username)
        {
            SubmitAnswerResult isCorrect = _PuzzleManagement.SubmitPuzzleAnswer(id, answer, username);
            
            if (isCorrect == SubmitAnswerResult.Correct)
            {
                WriteLogEntry(string.Format(PuzzleAnsweredCorrectlyLogTemplate, username, id, HttpContext.Current.Request.UserHostAddress), DateTime.UtcNow);
            }
            else if (isCorrect == SubmitAnswerResult.Incorrect)
            {
                WriteLogEntry(string.Format(PuzzleAnsweredIncorrectlyLogTemplate, username, id, HttpContext.Current.Request.UserHostAddress, answer), DateTime.UtcNow);
            }

            return isCorrect;
        }

        public void StartPuzzle(int id, string username)
        {
            _PuzzleManagement.StartPuzzle(id, username);
            WriteLogEntry(string.Format(PuzzleStartedLogTemplate, username, id, HttpContext.Current.Request.UserHostAddress), DateTime.UtcNow);
        }

        public IEnumerable<string> GetHints(int id, string username)
        {
            return _PuzzleManagement.GetHints(id, username);
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
