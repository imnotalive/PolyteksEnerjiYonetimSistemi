using PolyteksEnerjiYonetimSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PolyteksEnerjiYonetimSistemi.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        POLY_ENERJI db = new POLY_ENERJI();
        public ActionResult Index()
        {
            return View();
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Giris", "Home");
        }


        [AllowAnonymous]
        public ActionResult Giris(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
  
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Giris(Kullanicilar kullanici, string returnUrl)
        {


            var teyit = db.Kullanicilar.FirstOrDefault(a => a.KullaniciKodu == kullanici.KullaniciKodu && a.Sifre == kullanici.Sifre);
            if (ModelState.IsValid && teyit != null)
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
        [HttpPost]
        public JsonResult KeepSessionAlive()
        {

            return new JsonResult
            {
                Data = "Beat Generated"
            };
        }

        [AllowAnonymous]
        public ActionResult Cikis()
        {

           
            FormsAuthentication.SignOut();
            HttpContext.Session.Clear();
            return RedirectToAction("Giris", "Home");

           
        }
        public ActionResult Create()
        {
            ViewBag.Makine = new SelectList(db.Makine, "ID", "MakineAdi");
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

            ViewBag.Makine = new SelectList(db.Makine, "id_model", "model", repuesto.MakineAdi);
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