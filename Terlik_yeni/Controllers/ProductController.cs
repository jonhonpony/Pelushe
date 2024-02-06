using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TerlikDAL;
using TerlikEntities;

namespace Terlik_yeni.Controllers
{
    public class ProductController : Controller
    {
       public ActionResult Index()
        {
            DatabaseContext db = new DatabaseContext();
            var model = db.Products.ToList();
            return View(model);
        }

        public ActionResult womenHome()
        {
            DatabaseContext db = new DatabaseContext();
            var model = db.Products.Where(x => x.CategoryId == 1).ToList();
            return View(model);
        }
        public ActionResult womenSummer()
        {
            DatabaseContext db = new DatabaseContext();
            var model = db.Products.Where(x => x.CategoryId == 2).ToList();
            return View(model);
        }
        public ActionResult menSummer()
        {
            DatabaseContext db = new DatabaseContext();
            var model = db.Products.Where(x => x.CategoryId == 3).ToList();
            return View(model);
        }
        public ActionResult menHome()
        {
            DatabaseContext db = new DatabaseContext();
            var model = db.Products.Where(x => x.CategoryId == 4).ToList();
            return View(model);
        }
        public ActionResult childrenSummer()
        {
            DatabaseContext db = new DatabaseContext();
            var model = db.Products.Where(x => x.CategoryId == 5).ToList();
            return View(model);
        }
        public ActionResult childrenHome()
        {
            DatabaseContext db = new DatabaseContext();
            var model = db.Products.Where(x => x.CategoryId == 6).ToList();
            return View(model);
        }



        public ActionResult Create()
        {
            DatabaseContext db = new DatabaseContext();
            var model = db.Categories.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            DatabaseContext db = new DatabaseContext();
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            DatabaseContext db = new DatabaseContext();
            var model = db.Products.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            DatabaseContext db = new DatabaseContext();
            var model = db.Products.Find(product.ProductId);
            model.Name = product.Name;
         
          
            model.CategoryId = product.CategoryId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            DatabaseContext db = new DatabaseContext();
            var model = db.Products.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            DatabaseContext db = new DatabaseContext();
            var model = db.Products.Find(product.ProductId);
            db.Products.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            DatabaseContext db = new DatabaseContext();
            var model = db.Products.Find(id);
            return View(model);
        }   






    }
}