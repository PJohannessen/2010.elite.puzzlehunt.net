using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAJ.ElitePuzzleHunt.BusinessObjects;

namespace PAJ.ElitePuzzleHunt.WebControls
{
    public class ListUsers : WebControl
    {
        public IEnumerable<Player> Users { private get; set; }

        /// <summary>
        /// Renders the contents of the control to the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client. 
        ///                 </param>
        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (Users == null || Users.Count() == 0)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Span);
                writer.WriteEncodedText("No users were found!");
                writer.RenderEndTag();
            }
            else
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "hor-minimalist-b", true);
                writer.RenderBeginTag(HtmlTextWriterTag.Table);
                RenderTableHeaders(writer);
                writer.RenderBeginTag(HtmlTextWriterTag.Tbody);
                foreach (Player user in Users)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.AddAttribute(HtmlTextWriterAttribute.Href.ToString(), string.Format("{0}/", user.Username), true);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.WriteEncodedText(user.Username);
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    if (user.Team != null)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Href.ToString(), string.Format("../Teams/{0}/", user.Team.Name), true);
                        writer.RenderBeginTag(HtmlTextWriterTag.A);
                        writer.WriteEncodedText(user.Team.Name);
                        writer.RenderEndTag();
                    }
                    else
                    {
                        writer.WriteEncodedText("Team");
                    }
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
            writer.WriteEncodedText("Username");
            writer.RenderEndTag();
            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            writer.Write("Team");
            writer.RenderEndTag();
            writer.RenderEndTag();
            writer.RenderEndTag();
        }
    }
}
