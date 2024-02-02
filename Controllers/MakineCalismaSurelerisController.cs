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
         POLY_ENERJI db = new POLY_ENERJI();
        #region list

        public ActionResult Index()
        {
            var makineCalismaSureleri = db.MakineCalismaSureleri.Include(m => m.Bolumler).Include(m => m.Makine);
            return View(makineCalismaSureleri.ToList());
        }
        public ActionResult TekstureIndex(MakineCalismaSureleri makineCalismaSureleris)
        {
            var mer = DateTime.Now.Month;
            var abc = mer - 1;

            if (abc == 0)
            {
                abc++;
            }
            int counter = 0;


            if (db.MakineCalismaSureleri.Any(a => a.MakineID != makineCalismaSureleris.MakineID && a.Ay != makineCalismaSureleris.Ay && a.Yil != makineCalismaSureleris.Yil))
            {
                counter++;

                ViewBag.counter = counter;


            }

            var yil = DateTime.Now.Year;
            ViewBag.ay = abc;
            ViewBag.yil = yil;


            var makineCalismaSureleri = db.Makine.OrderByDescending(m => m.MakineAdi).Include(m => m.Bolumler).Where(m => m.Bolum == 1);


            return View(makineCalismaSureleri.ToList());
        }
        public ActionResult BukumIndex(MakineCalismaSureleri makineCalismaSureleris)
        {
            var uretim = db.AylikUretimVerileri.AsNoTracking().ToList();
            ViewBag.uretim = uretim;
            var mer = DateTime.Now.Month;
            var abc = mer - 1;

            if (abc == 0)
            {
                abc++;
            }
            int counter = 0;


            if (db.MakineCalismaSureleri.Any(a => a.MakineID != makineCalismaSureleris.MakineID && a.Ay != makineCalismaSureleris.Ay && a.Yil != makineCalismaSureleris.Yil))
            {
                counter++;
                ViewBag.counter = counter;


            }

            var yil = DateTime.Now.Year;
            ViewBag.ay = abc;
            ViewBag.yil = yil;
            var makineCalismaSureleri = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 3).OrderBy(m => m.MakineAdi);
            return View(makineCalismaSureleri.ToList());
        }
        public ActionResult TeknikTekstilIndex(MakineCalismaSureleri makineCalismaSureleris)
        {
            var mer = DateTime.Now.Month;
            var abc = mer - 1;

            if (abc == 0)
            {
                abc++;
            }
            int counter = 0;


            if (db.MakineCalismaSureleri.Any(a => a.MakineID != makineCalismaSureleris.MakineID && a.Ay != makineCalismaSureleris.Ay && a.Yil != makineCalismaSureleris.Yil))
            {
                counter++;
       
                ViewBag.counter = counter;


            }

            var yil = DateTime.Now.Year;
            ViewBag.ay = abc;
            ViewBag.yil = yil;
            var makineCalismaSureleri = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 4).OrderBy(m => m.MakineAdi);
            return View(makineCalismaSureleri.ToList());
        }

        public ActionResult UretimIndex(MakineCalismaSureleri makineCalismaSureleris)
        {
            var mer = DateTime.Now.Month;
            var abc = mer - 1;

            if (abc == 0)
            {
                abc++;
            }
            int counter = 0;


            if (db.MakineCalismaSureleri.Any(a => a.MakineID != makineCalismaSureleris.MakineID && a.Ay != makineCalismaSureleris.Ay && a.Yil != makineCalismaSureleris.Yil))
            {
                counter++;
             
                ViewBag.counter = counter;


            }

            var yil = DateTime.Now.Year;
            ViewBag.ay = abc;
            ViewBag.yil = yil;
            var makineCalismaSureleri = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 2||m.Bolum==11).OrderBy(m => m.MakineAdi);
            return View(makineCalismaSureleri.ToList());
        }



   
        public ActionResult YardimciTesislerIndex(MakineCalismaSureleri makineCalismaSureleris)
        {
            var mer = DateTime.Now.Month;
            var abc = mer - 1;

            if (abc == 0)
            {
                abc++;
            }
            int counter = 0;


            if (db.MakineCalismaSureleri.Any(a => a.MakineID != makineCalismaSureleris.MakineID && a.Ay != makineCalismaSureleris.Ay && a.Yil != makineCalismaSureleris.Yil))
            {
                counter++;

                ViewBag.counter = counter;


            }

            var yil = DateTime.Now.Year;
            ViewBag.ay = abc;
            ViewBag.yil = yil;


            var makineCalismaSureleri = db.Makine.OrderByDescending(m=>m.MakineAdi).Include(m => m.Bolumler).Where(m => m.Bolum == 5 ||m.Bolum==12||m.Bolum==13);
            return View(makineCalismaSureleri.ToList());
        }
        public ActionResult DigerIndex(MakineCalismaSureleri makineCalismaSureleris)
        {
            var mer = DateTime.Now.Month;
            var abc = mer - 1;

            if (abc == 0)
            {
                abc++;
            }
            int counter = 0;


            if (db.MakineCalismaSureleri.Any(a => a.MakineID != makineCalismaSureleris.MakineID && a.Ay != makineCalismaSureleris.Ay && a.Yil != makineCalismaSureleris.Yil))
            {
                counter++;
          
                ViewBag.counter = counter;


            }

            var yil = DateTime.Now.Year;
            ViewBag.ay = abc;
            ViewBag.yil = yil;
            var makineCalismaSureleri = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 6).OrderBy(m => m.MakineAdi);
            return View(makineCalismaSureleri.ToList());
        }
        #endregion

        #region raporlar

        public ActionResult TekstureRapor()
        {
            var teksture = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 1);

            return View(teksture);

        }
        public ActionResult YardimciTesislerBarRapor()
        {
            var teksture = db.View_Bolum_Aylik_Calisma_Sureleri_Detay.AsNoTracking();

            return View(teksture);

        }
        public ActionResult BukumRapor()
        {
            var bukumrapor = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 3);

            return View(bukumrapor);

        }
        public ActionResult TeknikTekstilRapor()
        {
            var ttrapor = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 4);

            return View(ttrapor);

        }
        public ActionResult UretimRapor()
        {
            var uretimrapor = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 2);
            return View(uretimrapor.ToList());

        }
        public ActionResult YardimciTesislerRapor()
        {
            var makineCalismaSureleri = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 5|| m.Bolum == 12 || m.Bolum == 13);
            return View(makineCalismaSureleri.ToList());

        }
        public ActionResult DigerRapor()
        {
            var makineCalismaSureleri = db.Makine.Include(m => m.Bolumler).Where(m => m.Bolum == 6);
            return View(makineCalismaSureleri.ToList());

        }
        #endregion
        #region crud
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
            Makine stok = db.Makine.FirstOrDefault(x => x.ID == id1);
            ViewBag.data = stok;
            if (id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var deneme = db.MakineCalismaSureleri.FirstOrDefault(a=>a.MakineID!=makineCalismaSureleri.MakineID && a.Ay!=makineCalismaSureleri.Ay );
           
            int counter = 0;
            if (db.MakineCalismaSureleri.Any(a => a.MakineID == makineCalismaSureleri.MakineID && a.Ay == makineCalismaSureleri.Ay && a.Yil == makineCalismaSureleri.Yil))
            {
                counter++;
           
                ViewBag.counter = counter;
                return RedirectToAction("Index");

            }

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
        
          
        
            if (makineCalismaSureleri != null && makineCalismaSureleri.CalismaSuresi != null &&abc!=0)
            {
                int sayac = 0;
                MakineCalismaSureleri fis;
                fis = db.MakineCalismaSureleri.FirstOrDefault(x => x.BolumID == 1);

                fis = new MakineCalismaSureleri()
                {
                    KayitTarihi = DateTime.Now,
                    KayitEden = User.Identity.Name,
                    CalismaSuresi = makineCalismaSureleri.CalismaSuresi,
                    KayitliMi = true,
                    M3 = makineCalismaSureleri.M3,
                    BasincKWh = makineCalismaSureleri.BasincKWh,
                    MakineID = makine.ID,
                    ToplamTuketimKwh= makine.KWH * makineCalismaSureleri.CalismaSuresi,
                    Yil = DateTime.Now.Year,
                    Ay = abc
                };
                sayac++;
                db.MakineCalismaSureleri.Add(fis);
                db.SaveChanges();
      
                if (User.IsInRole("T"))
                {
                    return RedirectToAction(nameof(TekstureIndex));
                }
                if (User.IsInRole("U"))
                {
                    return RedirectToAction(nameof(UretimIndex));
                }
                if (User.IsInRole("BU"))
                {
                    return RedirectToAction(nameof(BukumIndex));
                }
                if (User.IsInRole("TT"))

                {
                    return RedirectToAction(nameof(TeknikTekstilIndex));
                }
                if (User.IsInRole("YT"))
    
                {
                    return RedirectToAction(nameof(YardimciTesislerIndex));
                }
            
            }

            else if (makineCalismaSureleri != null && makineCalismaSureleri.CalismaSuresi != null&&abc==0)
            {
                if (abc == 0)
                {
                    abc++;
                    var yil = DateTime.Now.AddYears(-1).Year;
                    var ay = DateTime.Now.AddMonths(-1).Month;
                }

                int sayac = 0;
                MakineCalismaSureleri fis;
                fis = db.MakineCalismaSureleri.FirstOrDefault(x => x.BolumID == 1);

                fis = new MakineCalismaSureleri()
                {
                    KayitTarihi = DateTime.Now,
                    KayitEden = User.Identity.Name,
                    CalismaSuresi = makineCalismaSureleri.CalismaSuresi,
                    KayitliMi = true,
                    M3=makineCalismaSureleri.M3,
                    BasincKWh = makineCalismaSureleri.BasincKWh,
                    ToplamTuketimKwh = makine.KWH * makineCalismaSureleri.CalismaSuresi,
                    MakineID = makine.ID,
                    Yil = DateTime.Now.AddYears(-1).Year,
                    Ay = DateTime.Now.AddMonths(-1).Month
            };
                sayac++;
                db.MakineCalismaSureleri.Add(fis);
                db.SaveChanges();

                if (User.IsInRole("T"))
                {
                    return RedirectToAction(nameof(TekstureIndex));
                }
                if (User.IsInRole("U"))
                {
                    return RedirectToAction(nameof(UretimIndex));
                }
                if (User.IsInRole("BU"))
                {
                    return RedirectToAction(nameof(BukumIndex));
                }
                if (User.IsInRole("TT"))

                {
                    return RedirectToAction(nameof(TeknikTekstilIndex));
                }
                if (User.IsInRole("YT"))

                {
                    return RedirectToAction(nameof(YardimciTesislerIndex));
                }
                if (User.IsInRole("YT"))
                {
                    return RedirectToAction(nameof(DigerIndex));
                }
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
        public ActionResult DetayDuzenle(int? id)
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
            ViewBag.BolumID = new SelectList(db.Bolumler, "ID", "Bolum", makineCalismaSureleri.BolumID);
            ViewBag.MakineID = new SelectList(db.Makine, "ID", "MakineNo", makineCalismaSureleri.MakineID);
            return View(makineCalismaSureleri);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DetayDuzenle(MakineCalismaSureleri makineCalismaSureleri,int? id)
        {
            MakineCalismaSureleri calismaSuresi = db.MakineCalismaSureleri.Find(id);
            if (ModelState.IsValid)
            {
                calismaSuresi.CalismaSuresi = makineCalismaSureleri.CalismaSuresi;
                calismaSuresi.BasincKWh = makineCalismaSureleri.BasincKWh;
                calismaSuresi.M3 = makineCalismaSureleri.M3;
                db.SaveChanges();
                if (User.IsInRole("T"))
                {
                    return RedirectToAction(nameof(TekstureIndex));
                }
                if (User.IsInRole("U"))
                {
                    return RedirectToAction(nameof(UretimIndex));
                }
                if (User.IsInRole("BU"))
                {
                    return RedirectToAction(nameof(BukumIndex));
                }
                if (User.IsInRole("TT"))

                {
                    return RedirectToAction(nameof(TeknikTekstilIndex));
                }
                if (User.IsInRole("YT"))

                {
                    return RedirectToAction(nameof(YardimciTesislerIndex));
                }
                if (User.IsInRole("YT"))
                {
                    return RedirectToAction(nameof(DigerIndex));
                }
            }
            ViewBag.BolumID = new SelectList(db.Bolumler, "ID", "Bolum", makineCalismaSureleri.BolumID);
            ViewBag.MakineID = new SelectList(db.Makine, "ID", "MakineNo", makineCalismaSureleri.MakineID);
            return View(makineCalismaSureleri);
        }
        #endregion


        public ActionResult AylikRapor()
        {
            var teksture = db.View_Bolum_Aylik_Calisma_Sureleris.AsNoTracking().Distinct().ToList();
            ViewBag.Bolum = db.Bolumler.OrderBy(a=>a.Bolum).ToList();
            var aylik = db.View_Bolum_Aylik_Calisma_Sureleri_Detay.AsNoTracking();
            ViewBag.aylik = aylik;
            var hedef = db.Hedefler.ToList();
            ViewBag.hedef = hedef;
            var uretim = db.AylikUretimVerileri.AsNoTracking().ToList();
            ViewBag.uretim = uretim;
            var basinc = db.View_Bolum_Aylik_Calisma_Suresi_Basinc.AsNoTracking().ToList();
            ViewBag.basinc = basinc;

      //      AylikUretimVerileri asd= new AylikUretimVerileri();
      //      var movies =
      //(from items in db.AylikUretimVerileri
      // select new View_Bolum_Aylik_Calisma_Sureleris()
      // {
      //     Ay = items.Ay,
      //     Yil=items.Yil,
      //     Toplam=items.AylikMiktar/asd.AylikMiktar
      // })
      //   .ToList();
            return View(teksture);
        }
        public ActionResult EnerjiGozdenGecirme()
        {
            var teksture = db.Makine.AsNoTracking().Distinct().ToList();
            var hedef = db.Hedefler.ToList();
            ViewBag.hedef = hedef;
            return View(teksture);
        }
    }
}
