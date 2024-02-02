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
    public class MakinesController : Controller
    {
        POLY_ENERJI db = new POLY_ENERJI();


        public ActionResult Index()
        {
            var makine = db.Makine.Include(m => m.Bolumler);
            return View(makine.ToList());
        }
        public ActionResult Liste()
        {
            var liste = db.MakineCalismaSureleri.OrderByDescending(a=>a.Ay).ThenByDescending(a=>a.Yil).ThenByDescending(a=>a.KayitTarihi).ToList();
            return View(liste);
        }

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

            ViewBag.Bolum = new SelectList(db.Bolumler, "ID", "Bolum", makine.Bolumler.ID);
            return View(makine);
        }
      
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makine makine = db.Makine.Find(id);
            if (makine == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bolum = new SelectList(db.Bolumler, "ID", "Bolum", makine.Bolum);
            return View(makine);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Makine makine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(makine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bolum = new SelectList(db.Bolumler, "ID", "Bolum", makine.Bolum);
            return View(makine);
        }

      
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makine makine = db.Makine.Find(id);
            if (makine == null)
            {
                return HttpNotFound();
            }
            return View(makine);
        }

 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Makine makine = db.Makine.Find(id);
            db.Makine.Remove(makine);
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

        [AllowAnonymous]
        [HttpPost]
        public FileResult Makineler(Makine makine)
        {

            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[]{
               


                            new DataColumn("MAKİNE ADI"),
                                new DataColumn("KWH"),
                                    new DataColumn("BÖLÜM"),
                                 new DataColumn("YARDIMCI TESİSLER MAKİNE TİPİ"),
                               

                                     





            });
            var liste = from list in db.Makine.OrderBy(m => m.MakineAdi).ToList() select list;

            foreach (var list in liste)
            {

                dt.Rows.Add(
                 
                    list.MakineAdi,

                 list.KWH,
                 list.Bolumler.Bolum,
                    list.YrdTesisMakTipi
                  );
                

               

            }

     


            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(dt, "ISO-50001_Makineler");
                ws.Row(1).InsertRowsAbove(1);
                ws.Cell("A1").Value = "ISO-50001 MAKİNELER";
                ws.Cell("A1").Style.Font.Bold = true;
                ws.Cell("A1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                ws.Columns().AdjustToContents(); // Sütunların içerigine göre sütünları genişletir
                ws.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
         

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);


                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", DateTime.Now.ToString("dd MMMM yyyy") + "-" + "ISO-50001 MAKINELER" + ".xlsx");
                }


            }





        }

    }
}
