using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace roessner.admin
{
    public partial class page_edit : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e) {
            base.OnInit(e);
            if (!DesignMode) {
                m_save.Click += new EventHandler(m_save_Click);
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack && !DesignMode) {
                var items = Helpers.GetContentItems();
                var itemq = ( from x in items
                            where x.name == Request["id"]
                            select x ).First();

                this.wmdinput.Value = itemq.body ?? string.Empty;
                this.m_description.Text = itemq.MetaDescription ?? string.Empty;
                this.m_keywords.Text = itemq.MetaKeywords ?? string.Empty;
                this.m_title.Text = itemq.HtmlTitle ?? string.Empty;
                if (itemq.logo.HasValue) {
                    m_showlogo.SelectedIndex = (itemq.logo.Value ? 1 : 2);
                }
                else
                    m_showlogo.SelectedIndex = 0;
            }
        }

        void m_save_Click(object sender, EventArgs e) {
            Application.Lock();
            var items = Helpers.GetContentItems();
            var itemq = (from x in items
                         where x.name == Request["id"]
                         select x).First();
            itemq.body = this.wmdinput.Value;
            itemq.MetaKeywords = this.m_keywords.Text;
            itemq.MetaDescription = this.m_description.Text;
            itemq.HtmlTitle = this.m_title.Text;
            if (m_showlogo.SelectedIndex == 0)
                itemq.logo = null;
            else if (m_showlogo.SelectedIndex == 1)
                itemq.logo = true;
            else
                itemq.logo = false;
            Helpers.SaveContentItems(items);
            Application.UnLock();
        }
    }
}