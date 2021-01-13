using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stok_Takip.Models.Entity;
using System.Web.Security;
using System.Runtime.Remoting.Messaging;

namespace Stok_Takip.Controllers
{
    public class LoginController : Controller
    {
        stok_takipEntities db = new stok_takipEntities();      
        // GET: Login
        [HttpGet]    
        public ActionResult Login()
        {   

            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanicilar k)
        {
            var kullanici = db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == k.KullaniciAdi && x.Sifre == k.Sifre);
                if(kullanici!=null)
            {
                FormsAuthentication.SetAuthCookie(k.KullaniciAdi,false);
                return RedirectToAction("Index","Urunler");
            }
            ViewBag.hata = "Kullanıcı adı veya şifre yanlış";
            return View();
            }
            
           public ActionResult Logout()
          {
            FormsAuthentication.SignOut();
            return View("Login");
            

          }
    }
}