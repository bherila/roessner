using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using N2;
using N2.Definitions;
using N2.Details;
using N2.Web.UI.WebControls;

namespace Dinamico.Models
{
    [PageDefinition(Title = "Redirect")]
    public class RedirectModel : PageModelBase, IStructuralPage
    {
        [EditableUrl("Redirect to", 40, Required = true, RelativeTo = UrlRelativityMode.Application)]
        public string Redirect
        {
            get { return GetDetail<string>("Redirect", "/"); }
            set { SetDetail<string>("Redirect", value, "/"); }
        }

        [EditableCheckBox("Enabled", 100)]
        public virtual bool Enabled
        {
            get { return GetDetail<bool>("Enabled", true); }
            set { SetDetail<bool>("Enabled", value); }
        }

    }
}