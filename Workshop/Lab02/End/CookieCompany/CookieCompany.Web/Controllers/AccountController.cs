namespace CookieCompany.Web.Controllers
{
    using CookieCompany.Model.Fluent;
    using System.Web.Mvc;

    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult LogIn()
        {
            return View(new SignOn());
        }
    }
}