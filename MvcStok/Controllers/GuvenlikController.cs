using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcStok.Models.Entity;


namespace MvcStok.Controllers
{
    public class GuvenlikController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();

        // GET: Guvenlik
        [AllowAnonymous]
        public ActionResult GirisYap()
        {
            ViewBag.Mesaj1 = "Bilgilerinizi giriniz.";
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult GirisYap(TBLADMIN t1)
        {
            var bilgiler = db.TBLADMIN.FirstOrDefault(x => x.AD == t1.AD && x.SİFRE == t1.SİFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.AD,false);
                return RedirectToAction("Index","Kategori");
            }
            else
            {
                ViewBag.Mesaj2 = "Geçersiz Kullanıcı Adı veya Şifre Girdiniz!";
                return View();
            }
                         
        }
        
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap");
        }
    }
}