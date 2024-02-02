using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using PolyteksEnerjiYonetimSistemi.Models;

namespace PolyteksEnerjiYonetimSistemi.Controllers
{
    public class AdminController : Controller
    {
         POLY_ENERJI db = new POLY_ENERJI();

        #region MAKİNE
        public ActionResult Index()
        {
            var makineCalismaSureleri = db.MakineCalismaSureleri.Include(m => m.Bolumler).Include(m => m.Makine);
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
        public ActionResult Create(MakineCalismaSureleri makineCalismaSureleri)
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


        public ActionResult Edit(int? id)
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
        public ActionResult Edit(MakineCalismaSureleri makineCalismaSureleri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(makineCalismaSureleri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
        #endregion

        #region FATURAYERİ

        public ActionResult FaturaYeriIndex()
        {
            return View(db.FaturaYeri.ToList());
        }

      

       
        public ActionResult FaturaYeriCreate()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FaturaYeriCreate( FaturaYeri faturaYeri)
        {
            if (ModelState.IsValid)
            {
                db.FaturaYeri.Add(faturaYeri);
                db.SaveChanges();
                return RedirectToAction("FaturaYeriIndex");
            }

            return View(faturaYeri);
        }

       
        public ActionResult FaturaYeriEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FaturaYeri faturaYeri = db.FaturaYeri.Find(id);
            if (faturaYeri == null)
            {
                return HttpNotFound();
            }
            return View(faturaYeri);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FaturaYeriEdit( FaturaYeri faturaYeri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faturaYeri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("FaturaYeriIndex");
            }
            return View(faturaYeri);
        }

    
        public ActionResult FaturaYeriDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FaturaYeri faturaYeri = db.FaturaYeri.Find(id);
            if (faturaYeri == null)
            {
                return HttpNotFound();
            }
            return View(faturaYeri);
        }

        [HttpPost, ActionName("FaturaYeriDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult FaturaYeriDeleteConfirmed(int id)
        {
            FaturaYeri faturayeri = db.FaturaYeri.Find(id);
            db.FaturaYeri.Remove(faturayeri);
            db.SaveChanges();
            return RedirectToAction("FaturaYeriIndex");
        }

        #endregion
        #region FATURA
        public ActionResult FaturaIndex()
        {
            var faturaBilgileri = db.FaturaBilgileri.Include(f => f.FaturaYeri).OrderByDescending(f=>f.YIL).ThenByDescending(f=>f.AY);
            return View(faturaBilgileri.ToList());
        }


        public ActionResult FaturaCreate()
        {
            ViewBag.FaturaYeriID = new SelectList(db.FaturaYeri.OrderBy(a=>a.FaturaYeri1), "ID", "FaturaYeri1");
            return View();
        }

        [HttpPost]
     
        public ActionResult FaturaCreate( FaturaBilgileri faturaBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.FaturaBilgileri.Add(faturaBilgileri);
                db.SaveChanges();
                return RedirectToAction("FaturaIndex");
            }

            ViewBag.FaturaYeriID = new SelectList(db.FaturaYeri, "ID", "FaturaYeri1", faturaBilgileri.FaturaYeriID);
            return View(faturaBilgileri);
        }

       
        public ActionResult FaturaEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FaturaBilgileri faturaBilgileri = db.FaturaBilgileri.Find(id);
            if (faturaBilgileri == null)
            {
                return HttpNotFound();
            }
            ViewBag.FaturaYeriID = new SelectList(db.FaturaYeri.OrderBy(a => a.FaturaYeri1), "ID", "FaturaYeri1");
            return View(faturaBilgileri);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FaturaEdit( FaturaBilgileri faturaBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faturaBilgileri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("FaturaIndex");
            }
            ViewBag.FaturaYeriID = new SelectList(db.FaturaYeri, "ID", "FaturaYeri1", faturaBilgileri.FaturaYeriID);
            return View(faturaBilgileri);
        }

      
        public ActionResult FaturaDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FaturaBilgileri faturaBilgileri = db.FaturaBilgileri.Find(id);
            if (faturaBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(faturaBilgileri);
        }


        [HttpPost, ActionName("FaturaDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult FaturaDeleteConfirmed(int id)
        {
            FaturaBilgileri faturaBilgileri = db.FaturaBilgileri.Find(id);
            db.FaturaBilgileri.Remove(faturaBilgileri);
            db.SaveChanges();
            return RedirectToAction("FaturaIndex");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [AllowAnonymous]
        [HttpPost]
        public FileResult FaturaExcel(FaturaBilgileri gelenModels)
        {

            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[]{



                            new DataColumn("YIL"),
                                new DataColumn("AY"),
                                    new DataColumn("MİKTAR"),
                                 new DataColumn("FATURA YERİ"),
                                   







            });
            var liste = from list in db.FaturaBilgileri.OrderBy(m => m.YIL).ThenByDescending(m => m.AY).ToList() select list;

            foreach (var list in liste)
            {

                dt.Rows.Add(

                

                 list.YIL.ToString(),
                 list.AY.ToString(),
                    list.Miktar.Value.ToString("N2"),
                    list.FaturaYeri.FaturaYeri1.ToString()
                    



                );




            }




            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(dt, "ISO-50001_Fatura");
                ws.Row(1).InsertRowsAbove(1);
                ws.Cell("A1").Value = "ISO-50001 FATURALAR";
                ws.Cell("A1").Style.Font.Bold = true;
                ws.Cell("A1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                ws.Columns().AdjustToContents(); // Sütunların içerigine göre sütünları genişletir
                ws.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);


                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", DateTime.Now.ToString("dd MMMM yyyy") + "-" + "ISO-50001 FATURA VERILERI" + ".xlsx");
                }


            }





        }
        #endregion

        #region HEDEF
        public ActionResult HedefIndex()
        {
            var hedefler = db.Hedefler.Include(h => h.Bolumler);
            return View(hedefler.ToList());
        }


    
        public ActionResult HedefCreate()
        {
            ViewBag.BolumId = new SelectList(db.Bolumler.OrderBy(a => a.Bolum), "ID", "Bolum");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HedefCreate(Hedefler hedefler)
        {
            if (ModelState.IsValid)
            {
                db.Hedefler.Add(hedefler);
                db.SaveChanges();
                return RedirectToAction("HedefIndex");
            }
            ViewBag.BolumId = new SelectList(db.Bolumler.OrderBy(a => a.Bolum), "ID", "Bolum", hedefler.BolumId);
            return View(hedefler);
        }

       
        public ActionResult HedefEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hedefler hedefler = db.Hedefler.Find(id);
            if (hedefler == null)
            {
                return HttpNotFound();
            }
            ViewBag.BolumId = new SelectList(db.Bolumler, "ID", "Bolum", hedefler.BolumId);
            return View(hedefler);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HedefEdit( Hedefler hedefler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hedefler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("HedefIndex");
            }
            ViewBag.BolumId = new SelectList(db.Bolumler, "ID", "Bolum", hedefler.BolumId);
            return View(hedefler);
        }

     
        public ActionResult HedefDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hedefler hedefler = db.Hedefler.Find(id);
            if (hedefler == null)
            {
                return HttpNotFound();
            }
            return View(hedefler);
        }

     
        [HttpPost, ActionName("HedefDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult HedefDeleteConfirmed(int id)
        {
            Hedefler hedefler = db.Hedefler.Find(id);
            db.Hedefler.Remove(hedefler);
            db.SaveChanges();
            return RedirectToAction("HedefIndex");
        }








        #endregion

        #region AYLIK ÜRETİM VERİLERİ
        public ActionResult AylikUretimIndex()
        {
            var aylikUretimVerileri = db.AylikUretimVerileri.Include(a => a.Bolumler);
            return View(aylikUretimVerileri.ToList());
        }

   
      
        public ActionResult AylikUretimCreate()
        {
            ViewBag.BolumID = new SelectList(db.Bolumler.OrderBy(a=>a.Bolum), "ID", "Bolum");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AylikUretimCreate(AylikUretimVerileri aylikUretimVerileri)
        {
            if (ModelState.IsValid)
            {
                aylikUretimVerileri.KayitEden = User.Identity.Name;
                aylikUretimVerileri.KayitTarihi = DateTime.Now;
                db.AylikUretimVerileri.Add(aylikUretimVerileri);
                db.SaveChanges();
                return RedirectToAction("AylikUretimIndex");
            }

            ViewBag.BolumID = new SelectList(db.Bolumler, "ID", "Bolum", aylikUretimVerileri.BolumID);
            return View(aylikUretimVerileri);
        }


        public ActionResult AylikUretimEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AylikUretimVerileri aylikUretimVerileri = db.AylikUretimVerileri.Find(id);
            if (aylikUretimVerileri == null)
            {
                return HttpNotFound();
            }
            ViewBag.BolumID = new SelectList(db.Bolumler.OrderBy(a => a.Bolum), "ID", "Bolum", aylikUretimVerileri.BolumID);
            return View(aylikUretimVerileri);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AylikUretimEdit( AylikUretimVerileri aylikUretimVerileri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aylikUretimVerileri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AylikUretimIndex");
            }
            ViewBag.BolumID = new SelectList(db.Bolumler, "ID", "Bolum", aylikUretimVerileri.BolumID);
            return View(aylikUretimVerileri);
        }

      
        public ActionResult AylikUretimDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AylikUretimVerileri aylikUretimVerileri = db.AylikUretimVerileri.Find(id);
            if (aylikUretimVerileri == null)
            {
                return HttpNotFound();
            }
            return View(aylikUretimVerileri);
        }

        [HttpPost, ActionName("AylikUretimDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult AylikUretimDeleteConfirmed(int id)
        {
            AylikUretimVerileri aylikUretimVerileri = db.AylikUretimVerileri.Find(id);
            db.AylikUretimVerileri.Remove(aylikUretimVerileri);
            db.SaveChanges();
            return RedirectToAction("AylikUretimIndex");
        }


        #endregion
    }
}
