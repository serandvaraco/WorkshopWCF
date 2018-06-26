

namespace CookieCompany.Portal.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using unespacioparanet.com.services.datacontrac.products;

    public class ProductsController : BaseController
    {
        // GET: Products
        public async Task<ActionResult> Index()
        {
            var products = await this.serviceClient.GetProductsAsync();
            return View(products);
        }

        public ActionResult Create() => View();

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await serviceClient.AddProductAsyncAsync(product);
                    return View("Index");
                }

                return View();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Name", ex.Message);
                return View();
            }

        }

    }
}