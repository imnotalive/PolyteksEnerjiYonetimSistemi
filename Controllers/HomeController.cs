using PolyteksEnerjiYonetimSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PolyteksEnerjiYonetimSistemi.Controllers
{
    public class HomeController : Controller
    {
        POLY_ENERJIEntities db = new POLY_ENERJIEntities();
        public ActionResult Index()
        {
            return View();
        }
     
  
        [AllowAnonymous]
        public ActionResult Giris()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost]

        public ActionResult Giris(Kullanicilar kullanici)
        {


            var teyit = db.Kullanicilar.FirstOrDefault(a => a.KullaniciKodu == kullanici.KullaniciKodu && a.Sifre == kullanici.Sifre);
            if (teyit != null)
            {
                FormsAuthentication.SetAuthCookie(teyit.AdiSoyadi, false);
                return RedirectToAction("Index", "Home");
            }

            else
            {
                ViewBag.mesaj = "GEÇERSİZ KULLANICI ADI VEYA ŞİFRE !";
                return View("Giris");
            }


        }
        [AllowAnonymous]
        public ActionResult Cikis()
        {

           
            FormsAuthentication.SignOut();

            return View("Giris");
        }
        public ActionResult Create()
        {
            ViewBag.id_modelos = new SelectList(db.Makine, "ID", "MakineAdi");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Makine repuesto)
        {
            if (ModelState.IsValid)
            {
                db.Makine.Add(repuesto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_modelos = new SelectList(db.Makine, "id_modelos", "modelo1", repuesto.MakineAdi);
            return View(repuesto);
        }
        public JsonResult GetResults(int? id)
        {
            // example query from table
            var list = db.Makine.Where(x => x.Bolum == id).Select(x => new {
                MakineAdi = x.MakineAdi,
                KWH = x.KWH,
              
                // other properties here
            }).ToList();

            // return JSON data
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
  
}