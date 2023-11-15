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
    [Authorize]
    public class MakineCalismaSurelerisController : Controller
    {
         POLY_ENERJIEntities db = new POLY_ENERJIEntities();

       
        public ActionResult Index()
        {
            var makineCalismaSureleri = db.MakineCalismaSureleri.Include(m => m.Bolumler).Include(m => m.Makine);
            return View(makineCalismaSureleri.ToList());
        }
        public ActionResult TekstureIndex()
        {
            var makine = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 1);
            MakineCalismaSureleri calismaSureleri = new MakineCalismaSureleri();
            Makine mak = new Makine();
        


            return View(makine.ToList());
        }
    
        #region tekstüre aylar

        public ActionResult _TekstureOcak()
        {
            var makine = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 1);
            return View(makine);

        }
        public ActionResult _TekstureSubat()
        {
            var makine = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 1);
            return View(makine);

        }
        public ActionResult _TekstureMart()
        {
            var makine = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 1);
            return View(makine);

        }
        public ActionResult _TekstureNisan()
        {
            var makine = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 1);
            return View(makine);

        }
        public ActionResult _TekstureMayıs()
        {
            var makine = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 1);
            return View(makine);

        }
        public ActionResult _TekstureHaziran()
        {
            var makine = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 1);
            return View(makine);

        }
        public ActionResult _TekstureTemmuz()
        {
            var makine = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 1);
            return View(makine);

        }
        public ActionResult _TekstureAgustos()
        {
            var makine = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 1);
            return View(makine);

        }
        public ActionResult _TekstureEylul()
        {
            var makine = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 1);
            return View(makine);

        }
        public ActionResult _TekstureEkim()
        {
            var makine = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 1);
            return View(makine);

        }
        public ActionResult _TekstureKasim()
        {
            var makine = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 1);
            return View(makine);

        }
        public ActionResult _TekstureAralik()
        {
            var makine = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 1);
            return View(makine);

        }
        #endregion
        public ActionResult BukumIndex()
        {
            var makineCalismaSureleri = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 3);
            return View(makineCalismaSureleri.ToList());
        }
        public ActionResult TeknikTekstilIndex()
        {
            var makineCalismaSureleri = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 4);
            return View(makineCalismaSureleri.ToList());
        }

        public ActionResult UretimIndex()
        {
            var makineCalismaSureleri = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 2);
            return View(makineCalismaSureleri.ToList());
        }

        public ActionResult YardimciTesislerIndex()
        {
            var makineCalismaSureleri = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 5);
            return View(makineCalismaSureleri.ToList());
        }
        public ActionResult DigerIndex()
        {
            var makineCalismaSureleri = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 6);
            return View(makineCalismaSureleri.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.BolumID = new SelectList(db.Bolumler, "ID", "Bolum");
            ViewBag.MakineID = new SelectList(db.Makine, "ID", "MakineNo");
            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( MakineCalismaSureleri makineCalismaSureleri)
        {
            if (ModelState.IsValid)
            {
                db.MakineCalismaSureleri.Add(makineCalismaSureleri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BolumID = new SelectList(db.Bolumler, "ID", "Bolum", makineCalismaSureleri.BolumID);
            ViewBag.MakineID = new SelectList(db.Makine, "ID", "MakineNo", makineCalismaSureleri.MakineID);
            return View(makineCalismaSureleri);
        }

     
        public ActionResult Edit( int? id1, MakineCalismaSureleri makineCalismaSureleri)
        {
            if (id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makine stok = db.Makine.FirstOrDefault(x => x.ID == id1);
            ViewBag.data = stok;
         
            ViewBag.BolumID = new SelectList(db.Bolumler, "ID", "Bolum", makineCalismaSureleri.BolumID);
            ViewBag.MakineID = new SelectList(db.Makine, "ID", "MakineNo", makineCalismaSureleri.MakineID);
            return View();
        }
        
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id1,string id2, MakineCalismaSureleri makineCalismaSureleri)
        {
          
            Makine makine = db.Makine.FirstOrDefault(a => a.ID == id1);
            ViewBag.data = makine;
            var mer = DateTime.Now.Month;
            var abc = mer - 1;
        
            if (abc == 0)
            {
                abc++;
            }

            if (makineCalismaSureleri != null && makineCalismaSureleri.CalismaSuresi != null)
            {
                int sayac = 0;
                MakineCalismaSureleri fis;
                fis = db.MakineCalismaSureleri.FirstOrDefault(x => x.BolumID == 1);

                fis = new MakineCalismaSureleri()
                {
                    KayitTarihi = DateTime.Now,
                    KayitEden = User.Identity.Name,
                    CalismaSuresi = makineCalismaSureleri.CalismaSuresi,
                    MakineID = makine.ID,
                    Yil = DateTime.Now.Year,
                    Ay = abc








                };
                sayac++;
                db.MakineCalismaSureleri.Add(fis);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));

            }


            ViewBag.BolumID = new SelectList(db.Bolumler, "ID", "Bolum", makineCalismaSureleri.BolumID);
            ViewBag.MakineID = new SelectList(db.Makine, "ID", "MakineNo", makineCalismaSureleri.MakineID);

            return View(makineCalismaSureleri);
       
        }

   
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MakineCalismaSureleri makineCalismaSureleri = db.MakineCalismaSureleri.Find(id);
            if (makineCalismaSureleri == null)
            {
                return HttpNotFound();
            }
            return View(makineCalismaSureleri);
        }

    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MakineCalismaSureleri makineCalismaSureleri = db.MakineCalismaSureleri.Find(id);
            db.MakineCalismaSureleri.Remove(makineCalismaSureleri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
