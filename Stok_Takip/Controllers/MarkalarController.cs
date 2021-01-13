using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Stok_Takip.Models.Entity;

namespace Stok_Takip.Controllers
{
    public class MarkalarController : Controller
    {
        // GET: Markalar
        stok_takipEntities db = new stok_takipEntities();
        public ActionResult Index()
        {    
            var model = db.Markalar.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new Markalar();
            List<SelectListItem> liste = new List<SelectListItem>(from x in db.Kategoriler
                                                                  select new SelectListItem
                                                                  {
                                                                      Value = x.ID.ToString(),
                                                                      Text = x.Kategori
                                                                  }


                                                                ).ToList();
            
            ViewBag.l = liste;
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Markalar m)
        {
            if (ModelState.IsValid)
            {
                ViewBag.KategoriID = new SelectList(db.Kategoriler, "ID", "Kategori", m.KategoriID);
                return View();
            }
            db.Entry(m).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Guncelle(Markalar p)
        {
            var model = db.Markalar.Find(p.ID);
            if (model == null) return HttpNotFound();

            return View(model);

        }


        public ActionResult Guncelleme(Markalar p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");


        }




        public ActionResult Sil(Markalar p)
        {
            var model = db.Kategoriler.Find(p.ID);
            if (model == null) return HttpNotFound();

            return View(model);
        }

        public ActionResult Silme(Markalar p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}