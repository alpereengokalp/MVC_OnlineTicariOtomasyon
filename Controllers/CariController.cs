using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var musteriler = c.Carilers.Where(x => x.Durum == true).ToList();
            return View(musteriler);
        }

        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriEkle(Cariler m)
        {
            if (!ModelState.IsValid)
            {
                return View("MusteriGetir");
            }
            m.Durum = true;
            c.Carilers.Add(m);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSil(int id) 
        {
            var musteriSil = c.Carilers.Find(id);
            musteriSil.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var musteriGetir = c.Carilers.Find(id);
            return View("MusteriGetir",musteriGetir);
                   //MusteriGetir view adı, değişken
        }

        public ActionResult MusteriGuncelle(Cariler p)
        {
            if (!ModelState.IsValid)
            {
                return View("MusteriGetir");
            }
            var musteri = c.Carilers.Find(p);
            musteri.CariAdi = p.CariAdi;
            musteri.CariSoyadi = p.CariSoyadi;
            musteri.CariSehir = p.CariSehir;
            musteri.CariMail = p.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {
            var musteriSatis = c.SatisHarekets.Where(x=>x.CariId==id).ToList();
            var mSatis = c.Carilers.Where(x => x.CariID == id).Select(y => y.CariAdi + " " + y.CariSoyadi).FirstOrDefault();
            ViewBag.musteriView = mSatis;
            return View(musteriSatis);
        }
    }
}