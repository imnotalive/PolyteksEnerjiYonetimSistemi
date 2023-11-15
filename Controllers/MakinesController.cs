using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PolyteksEnerjiYonetimSistemi.Models;

namespace PolyteksEnerjiYonetimSistemi.Controllers
{
    public class MakinesController : Controller
    {
        POLY_ENERJIEntities db = new POLY_ENERJIEntities();


        public ActionResult Index()
        {
            var makine = db.Makine.Include(m => m.Bolumler);
            return View(makine.ToList());
        }

 

        // GET: Makines/Create
        public ActionResult Create()
        {
            ViewBag.Bolum = new SelectList(db.Bolumler, "ID", "Bolum");
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Makine makine)
        {
            if (ModelState.IsValid)
            {
                db.Makine.Add(makine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bolum = new SelectList(db.Bolumler, "ID", "Bolum", makine.Bolum);
            return View(makine);
        }


    }
}
