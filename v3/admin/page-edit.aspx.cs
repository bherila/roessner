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
            }
        }

        void m_save_Click(object sender, EventArgs e) {
            Application.Lock();
            var items = Helpers.GetContentItems();
            var itemq = (from x in items
                         where x.name == Request["id"]
                         select x).First();
            itemq.body = this.wmdinput.Value;
            Helpers.SaveContentItems(items);
            Application.UnLock();
        }
    }
}