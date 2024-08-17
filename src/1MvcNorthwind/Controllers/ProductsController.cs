using _1MvcNorthwind.Models.Data;
using _1MvcNorthwind.Models.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1MvcNorthwind.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        NorthwindEntities db = new NorthwindEntities();
        ProductsModel model = new ProductsModel(); //
        public ActionResult Liste()
        {
            model.plist = db.Products.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Detay(int id)
        {
            model.SecProducts = db.Products.Find(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult Guncel(int id)
        {
            model.SecProducts = db.Products.Find(id);
            DoldurDropDown();
           
            return View(model);
        }

        private void DoldurDropDown()
        {
            model.CatDropDown = db.Categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            }).ToList();

            model.SupDropDown = db.Suppliers.Select(x => new SelectListItem
            {
                Text = x.CompanyName,
                Value = x.SupplierID.ToString()
            }).ToList();
        }

        [HttpPost]
        public ActionResult Guncel(int id, ProductsModel productModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productModel.SecProducts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Liste");
            }
            else
            {
                DoldurDropDown();
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult Sil(int id)
        {
            model.SecProducts = db.Products.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Sil(int id, bool d = true)
        {
            db.Entry(model.SecProducts).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

    
    }

}