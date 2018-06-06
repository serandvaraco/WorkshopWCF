using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using CookieCompany.Model.Context;

namespace CookieCompany.Web.Controllers
{
    public class ProductsController : Controller
    {
        private CookieCompanyModel db = new CookieCompanyModel();


        public PartialViewResult GetInvents(int id)
        {
            var invents =
                db.Invent.Where(x => x.ProductId == id);

            return PartialView(invents);
        }

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Product.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        public PartialViewResult GetImage(int id) {
            return PartialView("GetImage", db.Product
                        .FirstOrDefault(x => x.Id == id)
                        ?.Image);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Image")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    var fileInfo = new System.IO.FileInfo(file.FileName);
                    file.SaveAs(Server.MapPath("~/images/") + fileInfo.Name);
                    product.Image = fileInfo.Name;
                }


                //[0-9]2[A|B|C]1
                Regex regex = new Regex(@"^\d+");
                if (regex.Match(product.Name).Success)
                {
                    ModelState.AddModelError("Name", "No puede ser númerico");
                    return View(product);
                }
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Image")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    var fileInfo = new System.IO.FileInfo(file.FileName);
                    file.SaveAs(Server.MapPath("~/images/") + fileInfo.Name);
                    product.Image = fileInfo.Name;
                }

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
