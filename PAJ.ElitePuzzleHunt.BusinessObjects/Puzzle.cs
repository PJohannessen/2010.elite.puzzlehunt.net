using System;
using System.Collections.Generic;

namespace PAJ.ElitePuzzleHunt.BusinessObjects
{
    public class Puzzle
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string Difficulty { get; private set; }
        public PuzzleStatus? PuzzleStatus { get; private set; }
        public TimeSpan? TimeElapsed { get; private set; }
        public IEnumerable<string> Hints { get; set; }

        public Puzzle(int id, string name, string author, string difficulty, PuzzleStatus? puzzleStatus, TimeSpan? timeElapsed, IEnumerable<string> hints)
        {
            Id = id;
            Name = name;
            Author = author;
            Difficulty = difficulty;
            PuzzleStatus = puzzleStatus;
            TimeElapsed = timeElapsed;
            Hints = Hints;
        }

        public Puzzle(int id, string name, string author, string difficulty, PuzzleStatus? puzzleStatus) : this(id, name, author, difficulty, puzzleStatus, null, new List<string>())
        {

        }
    }

    public enum PuzzleStatus
    {
        NotStarted,
        Incomplete,
        Complete
    }
}
