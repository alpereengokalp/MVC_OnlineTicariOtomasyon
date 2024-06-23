using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var degerler = c.Carilers.FirstOrDefault(x => x.CariMail == musteriMail);
            ViewBag.m = musteriMail;
            return View(degerler);
        }

        public ActionResult Siparislerim()
        {
            var musteriMail = (string)Session["CariMail"]; //sisteme giriş yapan mail adresi sessiona atadım
            var id = c.Carilers.Where(x => x.CariMail == musteriMail.ToString()).Select(y => y.CariID).FirstOrDefault(); //sisteme giriş yapan mail adresinin veritabanında id değerini bulduk
            var degerler = c.SatisHarekets.Where(x => x.CariId == id).ToList(); //Satış harekette müşterinin id değerine eşit olanı getirdim
            return View(degerler); 
        }
    }
}