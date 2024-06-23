using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index()
        {
            UrunDetayBaglanti ud = new UrunDetayBaglanti();

            //var degerler = c.Uruns.Where(x=>x.UrunID == 1).ToList();

            ud.Deger1=c.Uruns.Where(x => x.UrunID == 1).ToList();
            ud.Deger2 = c.Detays.Where(y => y.DetayID == 1).ToList();

            return View(ud);
        }
    }
}