using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace roessner
{
    public partial class Template : System.Web.UI.MasterPage
    {

        class ItemClass
        {
            public string FullCategory { get { return BaseItem.category; } }
            public string LastCategory { get { return FullCategory.Split('|').Last(); } }
            public string ParentCategory {
                get {
                    var i = FullCategory.LastIndexOf('|');
                    if (i >= 0)
                        return FullCategory.Substring(0, i);
                    else
                        return string.Empty;
                }
            }
            public int Level { get { return FullCategory.Count(a => a == '|'); } }

            public ContentItem BaseItem;
        }

        HtmlGenericControl BuildUL(List<ContentItem> items) {

            var itemQuery = from x in items
                            where x.l1order > 0
                            group x by x.category into y
                            select y.OrderBy(a => a.l1order); // first item in each category

            var firstItems = itemQuery.ToList().ConvertAll(a => a.First());
            var itemQueryList = firstItems.ToList().ConvertAll(a => new ItemClass() { BaseItem = a });

            List<KeyValuePair<string, HtmlGenericControl>> liList = new List<KeyValuePair<string, HtmlGenericControl>>();
            Dictionary<string, HtmlGenericControl> ulMap = new Dictionary<string, HtmlGenericControl>();

            // for each distinct "parent category" make a UL
            foreach (var parentCategory in itemQueryList.Select(a=> a.ParentCategory).Distinct()) {
                //Response.Write(parentCategory + "<br/>\n");
                HtmlGenericControl ul = new HtmlGenericControl("ul");
                
                // for each item DIRECTLY in the parent category make a LI and add the LI to the hashtable
                foreach (var item in itemQueryList.Where(a=> a.ParentCategory == parentCategory)) {
                    var li = new HtmlGenericControl("li");
                    var j = item.BaseItem;
                    var a1 = new HtmlAnchor() {
                        HRef = Helpers.GetContentURL(j.name),
                        InnerText = item.LastCategory //categoryname
                    };
                    //Response.Write("+ " + item.FullCategory + "<br />\n");
                    li.Controls.Add(a1);
                    liList.Add(new KeyValuePair<string, HtmlGenericControl>(item.FullCategory, li));
                    ul.Controls.Add(li);
                }

                ulMap.Add(parentCategory, ul);
            }

            // for each LI look for a matching UL, and add the LI to that UL.
            foreach (var li in liList) {
                if (ulMap.ContainsKey(li.Key)) {
                    li.Value.Controls.Add(ulMap[li.Key]);
                    ((HtmlAnchor)li.Value.Controls[0]).Attributes["class"] = "dir";
                    ulMap.Remove(li.Key);
                }
            }

            return ulMap[""];
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!DesignMode) {
                List<ContentItem> ci = Helpers.GetContentItems();
                HtmlGenericControl ctl = BuildUL(ci);
                ctl.Attributes["class"] = "dropdown dropdown-horizontal";
                topnav.Controls.Add(ctl);
            }
        }

        protected override void OnPreRender(EventArgs e) {
            base.OnPreRender(e);
            if (!DesignMode) {
                if (String.IsNullOrEmpty(Page.Title))
                    Page.Title = "Roessner & Co.";
            }
        }

    }
}