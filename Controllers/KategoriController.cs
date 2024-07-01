using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index(int sayfa = 1) //Sayfa - form yüklenince çalışır. // int sayfa = 1 sayfalama işlemi için başlangıç değeri
        {
            var kategoriler = c.Kategoris.ToList().ToPagedList(sayfa, 10); //Kategori tablosundaki değerler listelendi.
            return View(kategoriler); //Geriye bu listelenen değerler döndürüldü.
        }


        //Neden iki tane KategoriEkle() tanımladık?
        //Form yüklendiğinde çalıştığı zaman, her iki metot da çalışacağı için ne yapar?
        //Başlangıçta boş bir şey ekler yani ekleme işlemi gerçekleşir ama boş olarak içerisinde herhanhi bir veri olmadan ekleyecek 

        [HttpGet] //View-form yüklendiğinde burayı çalıştır.
        public ActionResult KategoriEkle() //Normalde değerler form yüklendiği zaman çalışacak.
        {  
            return View(); //Burası çalışınca boş bir sayfa gelecek başka bir şey olmayacak.
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
                                //Ancak bir butona tıkladığımızda burası çalışır.
            c.Kategoris.Add(k); //Contextte bulunan kategoris'e k'dan gelen değeri ekle
                                //k ismindeki nesne -> view tarafında göndereceğimiz parametreleri tutacaktı.
                                //Tek bir parametremiz var -> KategoriAdi
            c.SaveChanges();    //k'dan gelen değerleri ekledikten sonra veritabanına kaydet
            return RedirectToAction("Index"); //Bu işlem bittikten sonra index aksiyonuna yönlendir.
        }

        public ActionResult KategoriSil(int id) 
        {
            var kategoriSil = c.Kategoris.Find(id);
            c.Kategoris.Remove(kategoriSil); //kategoriSil satır bilgisini tutmuş olur ve Remove ile komple kaldırır
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori=c.Kategoris.Find(id); 
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle(Kategori k)
        {
            var kategori = c.Kategoris.Find(k.KategoriID);
            kategori.KategoriAdi = k.KategoriAdi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Deneme()
        {
            Class1 cs = new Class1();
            cs.Kategoriler = new SelectList(c.Kategoris, "KategoriID", "KategoriAdi");
            cs.Urunler = new SelectList(c.Uruns, "UrunID", "UrunAdi");
            return View(cs);
        }

        public JsonResult UrunGetir(int p)
        {
            var urunler = (from x in c.Uruns
                           join y in c.Kategoris
                           on x.Kategori.KategoriID equals y.KategoriID
                           where x.Kategori.KategoriID == p
                           select new
                           {
                               Text = x.UrunAdi,
                               Value = x.UrunID.ToString()
                           }).ToList();
            return Json(urunler,JsonRequestBehavior.AllowGet);
        }
        
    }
}