using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace roessner.admin
{
    public partial class pages : System.Web.UI.Page
    {
        const string CHECKMARK = @"<img src=""Ok.png"" alt=""Yes"" />";

        protected override void OnInit(EventArgs e) {
            base.OnInit(e);
            if (!DesignMode) {
                m_create.Click += new EventHandler(m_create_Click);
            }
        }

        void m_create_Click(object sender, EventArgs e) {
            Application.Lock();
            var items = Helpers.GetContentItems();
            items.Add(new ContentItem() {
                name = m_name.Text,
                category = m_category.SelectedValue,
                l1order = 0,
                l2order = 0
            });
            Helpers.SaveContentItems(items);
            Application.UnLock();
            Response.Redirect("page-edit.aspx?id=" + Server.UrlEncode(m_name.Text));
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!DesignMode) {
                Helpers.AuthenticateAdmin(Context);

                var items = Helpers.GetContentItems();
                var itemq = from x in items
                            orderby x.category ascending
                            select new {
                                Name = x.name,
                                Category = x.category,
                                L1Nav = (x.l1order <= 0 ? "" : CHECKMARK),
                                L2Nav = (x.l2order <= 0 ? "" : CHECKMARK)
                            };

                grid.DataSource = itemq;
                grid.DataBind();

                m_category.DataSource = itemq.Select(a => a.Category).Distinct().OrderBy(a => a);
                m_category.DataBind();
            }
        }
    }
}