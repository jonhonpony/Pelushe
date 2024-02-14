using TerlikCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Terlik_yeni.Models;
using Microsoft.Ajax.Utilities;
using TerlikEntities;
using TerlikDAL;
using System.Resources;
using System.Reflection;



namespace Terlik_yeni.Controllers
{
  
    public class HomeController : Controller
    { 
      

        public ActionResult index()
        {
        
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hakkımızda";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create an instance of the EmailSender class
                var emailSender = new EmailSender();

                // Call the SendEmailAsync method to send the email
                await emailSender.SendEmailAsync(model.Email, model.Subject, model.Body);

                // Other code for your contact view action

                return RedirectToAction("Contact");
            }

            return View(model);
        }

        public ActionResult Product()
        {
            List<Category> categories = CacheHelper.KategoriCache();
            ViewBag.Categories = categories;

            return View();
        }

        [HttpGet]
        public ActionResult GetProductsByCategory(int categoryId)
        {
            // categoryId parametresini kullanarak ilgili kategorinin ürünlerini ve alt kategorilerini getirin.
            // Bu verileri JSON formatında döndürün.
            var db = new DatabaseContext();
            // Örnek:
            // Kategoriye göre ürünleri getir...
             var products = db.Products.Where(p => p.CategoryId == categoryId).ToList();

       

            var result = new
            {
                Products = products,
             
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Change(string LanguageAbbrevation)
        {
            if (LanguageAbbrevation != null)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(LanguageAbbrevation);
            }

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = LanguageAbbrevation;
            Response.Cookies.Add(cookie);

            return RedirectToAction("index");
        }



    }
}

