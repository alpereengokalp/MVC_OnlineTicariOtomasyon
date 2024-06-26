﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAdi, //Bize gözükecek kısım
                                               Value = x.DepartmanID.ToString() //Arka planda çalışacak kısım
                                           }).ToList();
            //ViewBag -> Controller tarafından view tarafına veri-değer taşımada kullanılıyor.
            ViewBag.Deger1 = deger1; //Kullanımı --> ViewBag.değişkenAdi(istediğimizi verebiliriz)        
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count>0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName); //dosya adini alır
                string uzanti = Path.GetExtension(Request.Files[0].FileName); //dosya uzantisini alir
                string yol = "~/Images_Personel/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Images_Personel/" + dosyaAdi + uzanti;
            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAdi,
                                               Value = x.DepartmanID.ToString() 
                                           }).ToList();
            ViewBag.Deger1 = deger1;
            var personel = c.Personels.Find(id);
            return View("PersonelGetir",personel);
        }

        public ActionResult PersonelGuncelle(Personel p)
        {
            
            var pGuncelle = c.Personels.Find(p.PersonelID);
            pGuncelle.PersonelAdi = p.PersonelAdi;
            pGuncelle.PersonelSoyadi = p.PersonelSoyadi;
            //pGuncelle.PersonelGorsel = p.PersonelGorsel;
            pGuncelle.DepartmanId = p.DepartmanId;

            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName); //dosya adini alır
                string uzanti = Path.GetExtension(Request.Files[0].FileName); //dosya uzantisini alir
                string yol = "~/Images_Personel/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Images_Personel/" + dosyaAdi + uzanti;
                pGuncelle.PersonelGorsel = p.PersonelGorsel;
            }

            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelListe() 
        { 
            var sorgular = c.Personels.ToList();
            return View(sorgular); 
        }
    }
}