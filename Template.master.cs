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

        protected override void OnPreRender(EventArgs e) {
            base.OnPreRender(e);
            if (!DesignMode) {
                if (String.IsNullOrEmpty(Page.Title))
                    Page.Title = "Roessner & Co.";
            }
        }

    }
}