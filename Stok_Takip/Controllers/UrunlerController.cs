using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Stok_Takip.Models.Entity;

namespace Stok_Takip.Controllers
{
    public class UrunlerController : Controller
        
    {
        stok_takipEntities db = new stok_takipEntities();
        // GET: Urunler
        public ActionResult Index()
        {
            var model = db.Urunler.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new Urunler();
            Yenile(model);


            return View(model);





        }

        private void Yenile(Urunler model)
        {
            List<Kategoriler> kategorilist = db.Kategoriler.OrderBy(x => x.Kategori).ToList();
            model.KategoriListesi = (from x in kategorilist
                                     select new SelectListItem
                                     {
                                         Text = x.Kategori,
                                         Value = x.ID.ToString()

                                     }
            ).ToList();

            List<Birimler> Birimlist = db.Birimler.OrderBy(x => x.Birimler1).ToList();
            model.BirimListesi = (from x in Birimlist
                                  select new SelectListItem
                                  {
                                      Text = x.Birimler1,
                                      Value = x.ID.ToString()

                                  }
            ).ToList();







        }
      
        [HttpPost]

        public ActionResult Ekle(Urunler p)
        {   if(!ModelState.IsValid)
            {
                var model = new Urunler();
                Yenile(model);
                return View(model);

            }
            db.Entry(p).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }






        [HttpPost]
        public JsonResult GetMarka(int id2)
        {
            var model = new Urunler();
            List<Markalar> markaliste = db.Markalar.Where(x => x.KategoriID== id2).OrderBy(x => x.Marka).ToList();
            model.MarkaListesi = (from x in markaliste
                                  select new SelectListItem
                                  {
                                      Text = x.Marka,
                                      Value = x.ID.ToString()
                                  }).ToList();
            model.MarkaListesi.Insert(0, new SelectListItem { Text = "Seçiniz", Value = "" });
            return Json(model.MarkaListesi, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GuncelleBilgi(int id)
        {
            var model = db.Urunler.Find(id);
            Yenile(model);
            List<Markalar> markalist = db.Markalar.Where(x => x.KategoriID == model.KategoriID).OrderBy(x => x.Marka).ToList();
            model.MarkaListesi = (from x in markalist
                                  select new SelectListItem
                                  {
                                      Text = x.Marka,
                                      Value = x.ID.ToString()
                                  }).ToList();
            return View(model);

        }
        [HttpPost]
        public ActionResult Guncelle(Urunler p)
        {
            if (!ModelState.IsValid)
            {
                var model = db.Urunler.Find(p);
                Yenile(model);
                List<Markalar> markalist = db.Markalar.Where(x => x.KategoriID == model.KategoriID).OrderBy(x => x.Marka).ToList();
                model.MarkaListesi = (from x in markalist
                                      select new SelectListItem
                                      {
                                          Text = x.Marka,
                                          Value = x.ID.ToString()
                                      }).ToList();
                return View(model);

            }
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        { var model = db.Urunler.FirstOrDefault(x => x.ID == id);
            db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}