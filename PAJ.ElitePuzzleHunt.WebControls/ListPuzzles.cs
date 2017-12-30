using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAJ.ElitePuzzleHunt.BusinessObjects;

namespace PAJ.ElitePuzzleHunt.WebControls
{
    public class ListPuzzles : WebControl
    {
        public bool _ValidUser = false;
        public IEnumerable<Puzzle> Puzzles { private get; set; }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (!_ValidUser)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Span);
                writer.WriteEncodedText("You must be logged in and assigned to a team in order to view puzzles.");
                writer.RenderEndTag();
            }
            else if (Puzzles.Count() == 0)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Span);
                writer.WriteEncodedText("No puzzles were found!");
                writer.RenderEndTag();
            }
            else
            {
                writer.RenderBeginTag(HtmlTextWriterTag.P);
                writer.WriteEncodedText("Viewing a puzzle will start the timer, so click carefully!");
                writer.RenderEndTag();

                writer.AddAttribute(HtmlTextWriterAttribute.Class, "hor-minimalist-b", true);
                writer.RenderBeginTag(HtmlTextWriterTag.Table);
                RenderTableHeaders(writer);
                writer.RenderBeginTag(HtmlTextWriterTag.Tbody);
                foreach (Puzzle puzzle in Puzzles)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.WriteEncodedText(puzzle.Id.ToString());
                    writer.RenderEndTag();
                    
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.AddAttribute(HtmlTextWriterAttribute.Href.ToString(), string.Format("{0}/", puzzle.Name), true);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.WriteEncodedText(puzzle.Name);
                    writer.RenderEndTag();
                    writer.RenderEndTag();

                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.WriteEncodedText(puzzle.Author);
                    writer.RenderEndTag();

                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.WriteEncodedText(puzzle.Difficulty);
                    writer.RenderEndTag();
                    
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    RenderPuzzleStatus(writer, puzzle);
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                }
                writer.RenderEndTag();
                writer.RenderEndTag();
            }
        }

        private void RenderTableHeaders(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Thead);
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            writer.WriteEncodedText("#");
            writer.RenderEndTag();
            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            writer.WriteEncodedText("Name");
            writer.RenderEndTag();
            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            writer.WriteEncodedText("Author");
            writer.RenderEndTag();
            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            writer.WriteEncodedText("Difficulty");
            writer.RenderEndTag();
            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            writer.WriteEncodedText("Status");
            writer.RenderEndTag();
            writer.RenderEndTag();
            writer.RenderEndTag();
        }

        private void RenderPuzzleStatus(HtmlTextWriter writer, Puzzle puzzle)
        {
            switch (puzzle.PuzzleStatus)
            {
                case PuzzleStatus.NotStarted:
                    writer.WriteEncodedText("Not Started");
                    break;
                case PuzzleStatus.Incomplete:
                    TimeSpan timeElapsed1 = puzzle.TimeElapsed.Value;
                    writer.WriteEncodedText(string.Format("Incomplete - {0} hours, {1} minutes", timeElapsed1.Hours, timeElapsed1.Minutes));
                    break;
                case PuzzleStatus.Complete:
                    TimeSpan timeElapsed2 = puzzle.TimeElapsed.Value;
                    writer.WriteEncodedText(string.Format("Complete - {0} hours, {1} minutes", timeElapsed2.Hours, timeElapsed2.Minutes));
                    break;
            }
        }
    }
}
