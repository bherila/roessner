using System.Web.Mvc;
using N2.Web;
using N2.Web.Mvc;

namespace Dinamico.Controllers
{
	[Controls(typeof(Models.RedirectModel))]
    public class RedirectController : ContentController<Models.RedirectModel>
    {

        public override ActionResult Index()
        {
            if (CurrentItem.Enabled)
            {
                return Redirect(CurrentItem.Redirect);
            }
            else
            {
                return View();
            }
        }
    }
}
