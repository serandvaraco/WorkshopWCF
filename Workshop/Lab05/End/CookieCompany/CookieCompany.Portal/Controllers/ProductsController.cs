

namespace CookieCompany.Portal.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Transactions;
    using System.Web.Mvc;
    using unespacioparanet.com.services.datacontract.products;

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
                    using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        await serviceClient.AddProductAsyncAsync(product);
                        scope.Complete();
                        return RedirectToAction("Index");
                    }
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