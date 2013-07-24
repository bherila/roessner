using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace roessner
{
    public partial class Content : System.Web.UI.Page
    {
        List<ContentItem> ci;
        ContentItem citem;

        string CapText(Match m) {
            return Helpers.GetContentURL(m.Groups[1].Value);
        }

        protected void Page_PreInit(object sender, EventArgs e) {
            ci = Helpers.GetContentItems();

            /** page content **/

            var cq = from a in ci
                     where a.name == (Request["id"] ?? "default")
                     orderby a.l1order ascending, a.l2order ascending
                     select a;

            try { citem = cq.First(); }
            catch { throw new Exception(Request["id"]); }
            if (!String.IsNullOrEmpty(citem.theme)) {
                Page.Theme = citem.theme;
            }
            if (!String.IsNullOrEmpty(citem.HtmlTitle))
                Page.Title = citem.HtmlTitle;
            else if (!String.IsNullOrEmpty(citem.title)) {
                Page.Title = citem.title + " | Roessner &amp; Co.";
            }
        }
        protected override void  OnLoad(EventArgs e)
        {
 	        base.OnLoad(e);

            // set meta tags
            if (!String.IsNullOrEmpty(citem.MetaDescription))
                d.Attributes["content"] = citem.MetaDescription;
            if (!String.IsNullOrEmpty(citem.MetaKeywords))
                d.Attributes["content"] = citem.MetaKeywords;

            // process content
            Markdown m = new Markdown();
            m_content.Text = m.Transform(citem.body);
            m_content.Text = Regex.Replace(m_content.Text, "\\$\\$(.*?)\\$\\$", CapText).Replace('“', '"').Replace('”', '"');

            m_imgtag.ImageUrl = citem.img;
            string virtualImage = "/images/auto/" + citem.name + ".jpg";
            if (System.IO.File.Exists(Server.MapPath(virtualImage)))
                m_imgtag.ImageUrl = virtualImage;
            else {
                virtualImage = "/images/auto/" + citem.name + ".png";
                if (System.IO.File.Exists(Server.MapPath(virtualImage)))
                    m_imgtag.ImageUrl = virtualImage;
            }
            string physicalImage = Server.MapPath(virtualImage);
            if (System.IO.File.Exists(physicalImage)) {
                using (var img = System.Drawing.Bitmap.FromFile(physicalImage)) {
                    m_imgtag.Height = new Unit(img.Height, UnitType.Pixel);
                    m_imgtag.Width = new Unit(img.Width, UnitType.Pixel);
                }
            }
            m_img.Visible = (!String.IsNullOrEmpty(m_imgtag.ImageUrl));
            seal.Visible = !citem.logo.HasValue || citem.logo.Value == true; 
              

            /** other items in category (L2 nav) **/
            var cl2 = from a in ci
                      where a.category == citem.category && a.l2order > 0
                      orderby a.l2order ascending
                      select a;

            foreach (var cl2item in cl2) {
                var li = new HtmlGenericControl("li");
                string url = Helpers.GetContentURL(cl2item.name);
                if (Request.RawUrl == url) {
                    li.Controls.Add(new LiteralControl() {
                        Text = cl2item.title
                    });
                    li.Attributes["class"] = "left-cur-item";
                }
                else {
                    li.Controls.Add(new HtmlAnchor() {
                        HRef = url,
                        InnerText = cl2item.title
                    });
                }
                m_navleft.Controls.Add(li);
            }
        }
    }
}