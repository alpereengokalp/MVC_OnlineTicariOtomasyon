using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class MusteriPanelController : Controller
    {
        // GET: MusteriPanel
        Context c = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var musteriMail = (string)Session["CariMail"]; //Sisteme yeni müşteri kayıt olurken mail kontrolü yapsın eğer kayıtlı ise uyarı versin
            var degerler = c.Mesajlars.Where(x => x.Alici == musteriMail).ToList();
            ViewBag.m = musteriMail;

            var mailid = c.Carilers.Where(x => x.CariMail == musteriMail).Select(y => y.CariID).FirstOrDefault();
            ViewBag.mid = mailid;

            var toplamSatis = c.SatisHarekets.Where(x => x.CariId == mailid).Count();
            ViewBag.toplamSatis = toplamSatis;

            var toplamTutar = c.SatisHarekets.Where(x => x.CariId == mailid).Sum(y => y.ToplamTutar);
            ViewBag.toplamTutar = toplamTutar;

            var toplamUrun = c.SatisHarekets.Where(x => x.CariId == mailid).Sum(y => y.Adet);
            ViewBag.toplamUrun = toplamUrun;

            var adSoyad = c.Carilers.Where(x => x.CariMail == musteriMail).Select(y => y.CariAdi + " " + y.CariSoyadi).FirstOrDefault();
            ViewBag.adSoyad = adSoyad;

            var musteriId = c.Carilers.Where(x => x.CariMail == musteriMail).Select(y => y.CariID).FirstOrDefault();
            ViewBag.musteriId = musteriId;

            var musteriSehir = c.Carilers.Where(x => x.CariMail == musteriMail).Select(y => y.CariSehir).FirstOrDefault();
            ViewBag.musteriSehir = musteriSehir;

            return View(degerler);
        }

        public ActionResult Siparislerim()
        {
            var musteriMail = (string)Session["CariMail"]; //sisteme giriş yapan mail adresi sessiona atadım
            var id = c.Carilers.Where(x => x.CariMail == musteriMail.ToString()).Select(y => y.CariID).FirstOrDefault(); //sisteme giriş yapan mail adresinin veritabanında id değerini bulduk
            var degerler = c.SatisHarekets.Where(x => x.CariId == id).ToList(); //Satış harekette müşterinin id değerine eşit olanı getirdim
            return View(degerler);
        }

        public ActionResult GelenMesajlar()
        {
            var musteriMail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Alici == musteriMail).OrderByDescending(x => x.MesajID).ToList();
            var gelenSayisi = c.Mesajlars.Count(x => x.Alici == musteriMail).ToString();
            ViewBag.d1 = gelenSayisi;
            var gidenSayisi = c.Mesajlars.Count(x => x.Gonderen == musteriMail).ToString();
            ViewBag.d2 = gidenSayisi;
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var musteriMail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gonderen == musteriMail).OrderByDescending(x => x.MesajID).ToList();
            var gelenSayisi = c.Mesajlars.Count(x => x.Alici == musteriMail).ToString();
            ViewBag.d1 = gelenSayisi;
            var gidenSayisi = c.Mesajlars.Count(x => x.Gonderen == musteriMail).ToString();
            ViewBag.d2 = gidenSayisi;
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.MesajID == id).ToList();
            var musteriMail = (string)Session["CariMail"];
            var gelenSayisi = c.Mesajlars.Count(x => x.Alici == musteriMail).ToString();
            ViewBag.d1 = gelenSayisi;
            var gidenSayisi = c.Mesajlars.Count(x => x.Gonderen == musteriMail).ToString();
            ViewBag.d2 = gidenSayisi;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var musteriMail = (string)Session["CariMail"];
            var gelenSayisi = c.Mesajlars.Count(x => x.Alici == musteriMail).ToString();
            ViewBag.d1 = gelenSayisi;
            var gidenSayisi = c.Mesajlars.Count(x => x.Gonderen == musteriMail).ToString();
            ViewBag.d2 = gidenSayisi;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var musteriMail = (string)Session["CariMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderen = musteriMail;
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }

        public ActionResult KargoTakip(string p)
        {
            var kargo = from x in c.KargoDetays select x;
            kargo = kargo.Where(y => y.TakipKodu.Contains(p));
            return View(kargo.ToList());
        }

        public ActionResult MusteriKargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }

        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult Partial1()
        {
            var musteriMail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == musteriMail).Select(y => y.CariID).FirstOrDefault();
            var musteriBul = c.Carilers.Find(id);
            return PartialView("Partial1", musteriBul);
        }

        public ActionResult MusteriBilgiGuncelle(Cariler cr)
        {
            var musteri = c.Carilers.Find(cr.CariID);
            musteri.CariAdi = cr.CariAdi;
            musteri.CariSoyadi = cr.CariSoyadi;
            musteri.CariSifre = cr.CariSifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RastgeleUrun()
        {
            var randomProducts = c.Uruns
                          .Where(x => x.Durum == true) // Durumu true olan ürünleri filtrele
                          .OrderBy(x => Guid.NewGuid()) // Rastgele sırala
                          .Take(3) // İlk 3 ürünü al
                          .ToList(); // Sonucu bir liste olarak döndür
            return View(randomProducts);
        }
    }
}