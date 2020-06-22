using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinavTakvimi.VeriTabani;

namespace SinavTakvimi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string KullaniciAdi, string Sifre)
        {
            VeriTabaniDataContext VeriTabani = new VeriTabaniDataContext();
            var kontrol = VeriTabani.Admin.Where(x => x.KullaniciAdi == KullaniciAdi && x.Sifre == Sifre).FirstOrDefault();

            if (kontrol != null)
            {
                Session["KullaniciAdSoyad"] = kontrol.Adi + " " + kontrol.Soyad;
                Session["KullaniciId"] = kontrol.Id;
                Session["Yetki"] = 1;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                var kontrol2 = VeriTabani.Sekreterler.Where(x => x.KullaniciAdi == KullaniciAdi && x.Sifre == Sifre).FirstOrDefault();
                if (kontrol2 != null)
                {
                    Session["KullaniciAdSoyad"] = kontrol2.Adi + " " + kontrol2.Soyadi;
                    Session["KullaniciId"] = kontrol2.Id;
                    Session["Yetki"] = 0;
                    Session["KullaniciBolum"] = kontrol2.BolumId;

                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        public ActionResult Cikis()
        {
            Session["KullaniciAdSoyad"] = null;
            Session["KullaniciId"] = null;
            Session["Yetki"] = null;
            return RedirectToAction("Index");
        }
    }
}