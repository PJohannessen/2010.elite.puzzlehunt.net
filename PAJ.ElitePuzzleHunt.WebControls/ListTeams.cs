using PAJ.ElitePuzzleHunt.BusinessObjects;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAJ.ElitePuzzleHunt.WebControls
{
    public class ListTeams : WebControl
    {
        public IEnumerable<Team> Teams { private get; set; }

        /// <summary>
        /// Renders the contents of the control to the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client. 
        ///                 </param>
        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (Teams == null || Teams.Count() == 0)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Span);
                writer.WriteEncodedText("No teams were found!");
                writer.RenderEndTag();
            }
            else
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "hor-minimalist-b", true);
                writer.RenderBeginTag(HtmlTextWriterTag.Table);
                RenderTableHeaders(writer);
                writer.RenderBeginTag(HtmlTextWriterTag.Tbody);
                foreach (Team team in Teams)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.AddAttribute(HtmlTextWriterAttribute.Href.ToString(), string.Format("{0}/", team.Name), true);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.WriteEncodedText(team.Name);
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.WriteEncodedText(string.Format("{0} / 2", team.Members.Count()));
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
            writer.WriteEncodedText("Name");
            writer.RenderEndTag();
            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            writer.Write("# of players");
            writer.RenderEndTag();
            writer.RenderEndTag();
            writer.RenderEndTag();
        }
    }
}
