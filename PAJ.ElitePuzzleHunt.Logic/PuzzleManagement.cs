using System;
using System.Collections.Generic;
using System.Linq;
using PAJ.ElitePuzzleHunt.BusinessObjects;
using PAJ.ElitePuzzleHunt.Data;
using PAJ.ElitePuzzleHunt.Logic.Interfaces;
using Puzzle=PAJ.ElitePuzzleHunt.BusinessObjects.Puzzle;

namespace PAJ.ElitePuzzleHunt.Logic
{
    public class PuzzleManagement : IPuzzleManagement
    {
        public IEnumerable<Puzzle> GetPuzzles(string username)
        {
            ICollection<Puzzle> puzzles = new List<Puzzle>();

            using (DatabaseDataContext dataContext = new DatabaseDataContext(DatabaseConfig.ConnectionString))
            {
                foreach (Data.Puzzle puzzle in dataContext.Puzzles)
                {
                    int puzzleId = puzzle.Id;
                    int? teamId = (from user in dataContext.Users
                                   where user.Name == username
                                   select user.TeamId).SingleOrDefault();

                    if (teamId == null) { break; }

                    var teamStatus = (from status in dataContext.TeamResults
                                      where status.PuzzleId == puzzleId
                                      where status.TeamId == teamId
                                      select status).SingleOrDefault();

                    PuzzleStatus? puzzleStatus;
                    Puzzle newPuzzle;

                    if (teamStatus == null)
                    {
                        puzzleStatus = PuzzleStatus.NotStarted;
                        newPuzzle = new Puzzle(puzzle.Id, puzzle.Name, puzzle.Author, puzzle.Difficulty, puzzleStatus);
                    }
                    else if (teamStatus.EndTime == null)
                    {
                        puzzleStatus = PuzzleStatus.Incomplete;
                        TimeSpan timeElapsed = (DateTime.UtcNow - teamStatus.StartTime).Subtract(new TimeSpan(0, teamStatus.TimeOffset, 0));
                        IEnumerable<string> hints = (from hint in dataContext.PuzzleHints
                                                     where hint.PuzzleId == puzzleId
                                                     where hint.MinutesBeforeReveal < timeElapsed.TotalMinutes
                                                     select hint.Hint).AsEnumerable();

                        newPuzzle = new Puzzle(puzzle.Id, puzzle.Name, puzzle.Author, puzzle.Difficulty, puzzleStatus, timeElapsed, hints);
                    }
                    else
                    {
                        puzzleStatus = PuzzleStatus.Complete;
                        TimeSpan timeElapsed = (teamStatus.EndTime - teamStatus.StartTime).Value.Subtract(new TimeSpan(0, teamStatus.TimeOffset, 0));
                        IEnumerable<string> hints = (from hint in dataContext.PuzzleHints
                                                     where hint.PuzzleId == puzzleId
                                                     where hint.MinutesBeforeReveal < timeElapsed.TotalMinutes
                                                     select hint.Hint).AsEnumerable();
                        newPuzzle = new Puzzle(puzzle.Id, puzzle.Name, puzzle.Author, puzzle.Difficulty, puzzleStatus, timeElapsed, hints);
                    }

                    puzzles.Add(newPuzzle);
                }
            }

            return puzzles;
        }

        public PuzzleStatusResult GetPuzzleStatus(int id, string username)
        {
            using (DatabaseDataContext dataContext = new DatabaseDataContext(DatabaseConfig.ConnectionString))
            {
                User user = (from dataUser in dataContext.Users
                                  where dataUser.Name == username
                                  select dataUser).SingleOrDefault();

                if (user == null) return PuzzleStatusResult.NotInTeam;
                if (user.TeamId == null) return PuzzleStatusResult.NotInTeam;

                var puzzleStatus = (from teamResult in dataContext.TeamResults
                                    where teamResult.PuzzleId == id
                                    where teamResult.TeamId == user.TeamId
                                    select teamResult).SingleOrDefault();

                if (puzzleStatus == null) return PuzzleStatusResult.NotStarted;
                if (puzzleStatus.EndTime == null) return PuzzleStatusResult.Incomplete;
                
                return PuzzleStatusResult.Complete;
            }
        }

        public SubmitAnswerResult SubmitPuzzleAnswer(int id, string answer, string username)
        {
            using (DatabaseDataContext dataContext = new DatabaseDataContext(DatabaseConfig.ConnectionString))
            {
                var puzzle = (from dataPuzzle in dataContext.Puzzles
                              where dataPuzzle.Id == id
                              select dataPuzzle).Single();

                if (!string.Equals(answer.Replace(" ", ""), puzzle.Answer, StringComparison.OrdinalIgnoreCase))
                {
                    return SubmitAnswerResult.Incorrect;
                }

                int? teamId = (from user in dataContext.Users
                               where user.Name == username
                               select user.TeamId).Single();

                var puzzleStatus = (from teamStatus in dataContext.TeamResults
                                    where teamStatus.TeamId == teamId
                                    where teamStatus.PuzzleId == puzzle.Id
                                    select teamStatus).Single();

                puzzleStatus.EndTime = DateTime.UtcNow;

                dataContext.SubmitChanges();
            }

            return SubmitAnswerResult.Correct;
        }

        public void StartPuzzle(int id, string username)
        {
            using (DatabaseDataContext dataContext = new DatabaseDataContext(DatabaseConfig.ConnectionString))
            {
                int? teamId = (from dataUser in dataContext.Users
                               where dataUser.Name == username
                               select dataUser.TeamId).Single();

                TeamResult result = new TeamResult
                                        {
                                            PuzzleId = id,
                                            TeamId = teamId.Value,
                                            StartTime = DateTime.UtcNow
                                        };

                dataContext.TeamResults.InsertOnSubmit(result);
                dataContext.SubmitChanges();
            }
        }

        public IEnumerable<string> GetHints(int id, string username)
        {
            using (DatabaseDataContext dataContext = new DatabaseDataContext(DatabaseConfig.ConnectionString))
            {
                int? teamId = (from dataUser in dataContext.Users
                               where dataUser.Name == username
                               select dataUser.TeamId).Single();

                var teamStatus = (from status in dataContext.TeamResults
                                  where status.PuzzleId == id
                                  where status.TeamId == teamId
                                  select status).Single();

                TimeSpan timeElapsed;
                if (teamStatus.EndTime == null)
                {
                    timeElapsed = (DateTime.UtcNow - teamStatus.StartTime).Subtract(new TimeSpan(0, teamStatus.TimeOffset, 0));
                }
                else
                {
                    timeElapsed = (teamStatus.EndTime - teamStatus.StartTime).Value.Subtract(new TimeSpan(0, teamStatus.TimeOffset, 0));
                }

                IEnumerable<string> hints = (from hint in dataContext.PuzzleHints
                                             where hint.PuzzleId == id
                                             where hint.MinutesBeforeReveal < timeElapsed.TotalMinutes
                                             select hint.Hint).ToList();

                return hints;
            }
        }
    }
}
