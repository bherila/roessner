using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace roessner
{
    public partial class Content : System.Web.UI.Page
    {
        public string ImgSrc { get; set; }

        protected void Page_Load(object sender, EventArgs e) {
            List<ContentItem> ci = Helpers.GetContentItems();

            /** page content **/

            var cq = from a in ci
                     where a.name == Request["id"]
                     orderby a.l1order ascending, a.l2order ascending
                     select a;

            var citem = cq.First();

            Markdown m = new Markdown();
            m_content.Text = m.Transform(citem.body);
            Page.Title = citem.title;

            ImgSrc = citem.img;
            m_img.Visible = (!String.IsNullOrEmpty(ImgSrc));


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