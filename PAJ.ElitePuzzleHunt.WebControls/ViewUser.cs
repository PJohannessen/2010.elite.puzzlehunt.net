using System.Web.UI;
using System.Web.UI.WebControls;
using PAJ.ElitePuzzleHunt.BusinessObjects;

namespace PAJ.ElitePuzzleHunt.WebControls
{
    public class ViewUser : WebControl
    {
        public Player User { private get; set; }

        /// <summary>
        /// Renders the contents of the control to the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client. 
        ///                 </param>
        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (User == null)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Span);
                writer.WriteEncodedText("A user with that name could not be found!");
                writer.RenderEndTag();
            }
            else
            {
                writer.WriteEncodedText(string.Format("Username: {0}", User.Username));
                writer.RenderBeginTag(HtmlTextWriterTag.Br);
                writer.WriteEncodedText("Team: ");
                if (User.Team == null)
                {
                    writer.WriteEncodedText("None");
                }
                else
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, string.Format("../Teams/{0}", User.Team.Name), true);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.WriteEncodedText(User.Team.Name);
                    writer.RenderEndTag();
                }
            }
        }
    }
}
