using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stok_Takip.Models.Entity;

namespace Stok_Takip.Controllers
{
    public class KategorilerController : Controller
    {
        // GET: Kategoriler
        stok_takipEntities db = new stok_takipEntities();
        public ActionResult Index()
        {
            return View(db.Kategoriler.ToList());
        }

        public ActionResult Ekle()
        {
            return View();

        }

        public ActionResult Ekle2(Kategoriler p)
        {
            db.Kategoriler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Guncelle(Kategoriler p)
        {
            var model = db.Kategoriler.Find(p.ID);
            if (model == null) return HttpNotFound();

            return View(model);

        }

        public ActionResult Guncelleme(Kategoriler p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult Sil(Kategoriler p)
        {
            var model = db.Kategoriler.Find(p.ID);
            if (model == null) return HttpNotFound();

            return View(model);
        }

        public ActionResult Silme(Kategoriler p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}