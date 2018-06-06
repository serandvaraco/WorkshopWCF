using CookieCompany.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CookieCompany.Web.Controllers
{
    public class UtilsController : Controller
    {
        private CookieCompanyModel db = new CookieCompanyModel();
        // GET: Utils
        public ActionResult GetProductsById(int id)
            => Json(db.Product.Find(id), JsonRequestBehavior.AllowGet);

        public JsonResult GetProducts() => Json(db.Product,
                                JsonRequestBehavior.AllowGet);

        public async Task<JsonResult> GetProductAsync(int id)
            => Json(await db.Product.FindAsync(id));
        // TPL 
        // Action 
        // Invoke 
        // anonymous Invoke
        // Func => Linq



        /*
        void a()
        {
            JsonResult result; 
            ///Usando Objeto Task con delegado / action
            Task.Run(async () => {
                        result = await GetProductAsync(1);}
                    ).Wait();

            //Invoca por defecto objeto Task 
            JsonResult _result = GetProductAsync(1).Result; 

            
        }

        async void TestAsync()
        {

            IList<Product> p = new List<Product>();
            Action obtener = () =>
            {
                p = db.Product.ToList();
            };

            Action<Task> escribirLog = (x) =>
            {
                System.Diagnostics.Debug.Write("Finalizado");
            };

            await Task.Run(obtener)
                .ContinueWith(escribirLog)
                .ContinueWith((x) => { Debug.Write("Ejecutando.."); });

            await Task.Run(obtener);
            await Task.Run(() => { });
            await Task.Run(() => { Debug.Write("Ejecutando.."); });

            Task.WaitAll();
        }
        */

    }
}