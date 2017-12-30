using System.Collections.Generic;
using PAJ.ElitePuzzleHunt.BusinessObjects;

namespace PAJ.ElitePuzzleHunt.Logic.Interfaces
{
    public interface IPuzzleManagement
    {
        IEnumerable<Puzzle> GetPuzzles(string username);
        PuzzleStatusResult GetPuzzleStatus(int id, string username);
        SubmitAnswerResult SubmitPuzzleAnswer(int id, string answer, string username);
        void StartPuzzle(int id, string username);
        IEnumerable<string> GetHints(int id, string username);
    }
}
