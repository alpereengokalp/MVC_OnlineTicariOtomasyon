using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun

        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x=>x.Durum==true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1=(from x in c.Kategoris.ToList() 
                                         select new SelectListItem
                                         {
                                             Text = x.KategoriAdi, //Bize gözükecek kısım
                                             Value = x.KategoriID.ToString() //Arka planda çalışacak kısım
                                         }).ToList();
            //ViewBag -> Controller tarafından view tarafına veri-değer taşımada kullanılıyor.
            ViewBag.Deger1 = deger1; //Kullanımı --> ViewBag.değişkenAdi(istediğimizi verebiliriz)        
            return View();
        }
   
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var silenecekDeger = c.Uruns.Find(id);
            silenecekDeger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAdi, //Bize gözükecek kısım
                                               Value = x.KategoriID.ToString() //Arka planda çalışacak kısım
                                           }).ToList();
            ViewBag.Deger1 = deger1;

            var urunDeger = c.Uruns.Find(id);
            return View("UrunGetir", urunDeger);
        }

        public ActionResult UrunGuncelle(Urun p)
        {
            var urun = c.Uruns.Find(p.UrunID);

            urun.UrunAdi = p.UrunAdi;
            urun.Marka = p.Marka;
            urun.Stok = p.Stok;
            urun.AlisFiyati = p.AlisFiyati;
            urun.SatisFiyati = p.SatisFiyati;
            urun.Durum = p.Durum;
            urun.UrunGorsel = p.UrunGorsel;
            urun.KategoriId = p.KategoriId;

            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
    }
}