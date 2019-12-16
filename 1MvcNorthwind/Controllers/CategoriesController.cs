using _1MvcNorthwind.Models.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1MvcNorthwind.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Liste(string ad)
        {
            if (ad == null)
            {
                ad = "";
            }
            ICollection<Categories> clist = db.Categories.Where(x=> x.CategoryName.Contains(ad)).ToList();
            return View(clist);/*olduğu gibi kat listesi cliste gisiyor */
        }
        [HttpGet]
        public ActionResult Detay(int id) {
            Categories secCat = db.Categories.Find(id);
            return View(secCat);

        }
        [HttpGet]
        public ActionResult Guncel(int id)
        {
            Categories secCat = db.Categories.Find(id);
            return View(secCat);

        }
        [HttpPost]
        public ActionResult Guncel(int id,Categories catmodel)//burdaki id yi kaldırırsak modelden de id geliyor zaten
        {
            Categories secCat = db.Categories.Find(id);
            secCat.CategoryName = catmodel.CategoryName;
            secCat.Description = catmodel.Description;
            db.SaveChanges();
            return RedirectToAction("Liste");//return view dersem aynı komuta gider bunu istemiyorum.Guncelleme wievine
        }
        [HttpGet]
        public ActionResult Sil(int id)
        {
            Categories secCat = db.Categories.Find(id);
            return View(secCat);


        }
        [HttpPost]
        public ActionResult Sil(int id,bool d = true)
        {
            Categories secCat = db.Categories.Find(id);
            //db.Categories.Remove(secCat);
            db.Entry(secCat).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Liste");


        }
        [HttpGet]
        public ActionResult Ekle()
        {
            Categories yeniCat = new Categories();
            return View(yeniCat);
        }
        [HttpPost]
        public ActionResult Ekle(Categories catmodel)
        {
            db.Categories.Add(catmodel);
            db.SaveChanges();
            return RedirectToAction("Liste");
        }


    }
}