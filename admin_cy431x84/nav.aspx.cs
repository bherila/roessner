using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace roessner.admin
{
    public partial class nav : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (Request["GenerateDeafult"] == "true") {
                Helpers.SaveNavigation(DefaultNavigation.topnav);
            }

            mt.Text = JsonConvert.SerializeObject(DefaultNavigation.topnav, Formatting.Indented);
        }
    }
}