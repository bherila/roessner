using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace roessner
{
    public class NavBar : CompositeControl
    {
        HtmlGenericControl BuildUL(List<Navigation> items) {
            HtmlGenericControl ul = new HtmlGenericControl("ul");
            foreach (var item in items) {
                HtmlGenericControl li = new HtmlGenericControl("li");
                HtmlAnchor a = new HtmlAnchor();
                a.InnerText = item.text;
                if (!String.IsNullOrEmpty(item.contentid))
                    a.HRef = Helpers.GetContentURL(item.contentid);
                else
                    a.HRef = "javascript:void(0);";
                li.Controls.Add(a);
                ul.Controls.Add(li);

                // recursively add subitems
                if (item.subitems != null && item.subitems.Count > 0)
                    li.Controls.Add(BuildUL(item.subitems));
            }
            return ul;
        }

        protected override void  CreateChildControls() {
            if (!DesignMode) {
                HtmlGenericControl ctl = BuildUL(DefaultNavigation.topnav);
                ctl.Attributes["class"] = "dropdown dropdown-horizontal";
                this.Controls.Add(ctl);
            }
        }
    }
}