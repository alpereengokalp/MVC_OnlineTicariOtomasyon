using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var departmanlar = c.Departmans.Where(x => x.Durum == true).ToList();
            return View(departmanlar);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var departman = c.Departmans.Find(id);
            departman.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departmans.Find(id);
            return View("DepartmanGetir",dpt);
        }

        public ActionResult DepartmanGuncelle(Departman p)
        {
            var departmann = c.Departmans.Find(p.DepartmanID);
            departmann.DepartmanAdi = p.DepartmanAdi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.DepartmanId == id).ToList();
            var dpt = c.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAdi).FirstOrDefault();
            ViewBag.dDetay = dpt; //viewbag -> controller tarafından view'a veri taşıyordu.
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var perAdi = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAdi + " " + y.PersonelSoyadi).FirstOrDefault();
            ViewBag.dPersonel = perAdi;
            return View(degerler);
        }
    }
}