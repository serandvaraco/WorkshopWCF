
namespace CookieCompany.Portal.Controllers
{
    using System.Web.Mvc;


    public class BaseController : Controller
    {
        internal readonly ProductContractServiceClient serviceClient;
        public BaseController()
        {
            serviceClient = new ProductContractServiceClient();
        }
    }
}