using PAJ.ElitePuzzleHunt.BusinessObjects;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAJ.ElitePuzzleHunt.WebControls
{
    public class ViewTeam : WebControl
    {
        public Team Team { private get; set; }

        /// <summary>
        /// Renders the contents of the control to the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client. 
        ///                 </param>
        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (Team == null)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Span);
                writer.WriteEncodedText("A team with that name could not be found!");
                writer.RenderEndTag();
            }
            else
            {
                writer.WriteEncodedText(string.Format("Team name: {0}", Team.Name));
                writer.RenderBeginTag(HtmlTextWriterTag.Br);
                writer.RenderBeginTag(HtmlTextWriterTag.Ul);
                foreach (var user in Team.Members)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Li);
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, string.Format("../../Users/{0}", user.Username), true);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.WriteEncodedText(user.Username);
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                }
                writer.RenderEndTag();
            }
        }
    }
}
