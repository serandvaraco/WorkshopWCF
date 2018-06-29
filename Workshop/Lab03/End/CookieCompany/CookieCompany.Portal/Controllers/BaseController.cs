
namespace CookieCompany.Portal.Controllers
{
    using System.Web.Mvc;
    using unespacioparanet.com.services;

    public class BaseController : Controller
    {
        internal readonly ProductContractServiceClient serviceClient;
        public BaseController()
        {
            serviceClient = new ProductContractServiceClient();
        }
    }
}