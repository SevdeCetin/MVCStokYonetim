using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {       
            var degerler = db.TBLSATISLAR.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {

            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR p)
        {
            //var satis = db.TBLSATISLAR.Find(p.ADET);
            var satis = db.TBLURUNLER.Find(p.URUN);
            for (int i = 0; i > p.ADET; i++)
            {
                satis.STOK--;
            }

            satis.STOK--;
            db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var satis = db.TBLSATISLAR.Find(id);
            db.TBLSATISLAR.Remove(satis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            var sat = db.TBLSATISLAR.Find(id);
            return View("SatisGetir", sat);
        }
        public ActionResult Guncelle(TBLSATISLAR p1)
        {
            var sat = db.TBLSATISLAR.Find(p1.SATISID);
            //sat.URUN = p1.URUN;
            //sat.MUSTERI = p1.MUSTERI;
            sat.FIYAT = p1.FIYAT;
            sat.ADET = p1.ADET;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}