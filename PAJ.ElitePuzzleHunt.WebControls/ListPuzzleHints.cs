using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAJ.ElitePuzzleHunt.WebControls
{
    public class ListPuzzleHints : WebControl
    {
        public IEnumerable<string> Hints { private get; set; }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.H4);
            writer.WriteEncodedText("Hints");
            writer.RenderEndTag();

            if (Hints == null || Hints.Count() == 0)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.P);
                writer.WriteEncodedText("No hints are currently available. Check the rules for when the next one will be available.");
                writer.RenderEndTag();
            }
            else
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Ul);
                foreach (string hint in Hints)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Li);
                    writer.WriteEncodedText(hint);
                    writer.RenderEndTag();
                }
                writer.RenderEndTag();
            }
        }
    }
}
