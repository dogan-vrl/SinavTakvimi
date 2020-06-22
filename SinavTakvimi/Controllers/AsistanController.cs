using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinavTakvimi.VeriTabani;
using SinavTakvimi.Models;
namespace SinavTakvimi.Controllers
{
    public class AsistanController : Controller
    {
        VeriTabaniDataContext VeriTabani = new VeriTabaniDataContext();

        // GET: Asistan
        public ActionResult Index()
        {
            if (Session["KullaniciAdSoyad"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var srg = VeriTabani.Asistanlar.Select(x=> new AsistanModel
            {
                Id = x.Id,
                Adi = x.Adi,
                Soyadi = x.Soyadi,
                Bolumu = VeriTabani.Bolumler.Where(y=>y.Id == x.BolumId).FirstOrDefault().BolumAdi,
                Cinsiyet = x.Cinsiyeti == true ? "Erkek" : "Kadın"
            }).ToList();
            return View(srg);
        }

        public ActionResult Duzenle(int? Id)
        {
            if (Session["KullaniciAdSoyad"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (Id == null)
            {
                return RedirectToAction("Index");
            }
            var bolumler = VeriTabani.Bolumler.ToList();
            ViewBag.Bolumler = bolumler;
            var srg = VeriTabani.Asistanlar.Where(x=>x.Id == Id).FirstOrDefault();
            return View(srg);
        }

        [HttpPost]
        public ActionResult Duzenle(FormCollection frm)
        {
            if (Session["KullaniciAdSoyad"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            int Id = int.Parse(frm["Id"].ToString());

            var srg = VeriTabani.Asistanlar.Where(x => x.Id == Id).FirstOrDefault();

            srg.Adi = frm["Adi"].ToString();
            srg.Soyadi = frm["Soyadi"].ToString();
            srg.Cinsiyeti = frm["Cinsiyeti"].ToString() == "1" ? true : false;
            srg.BolumId = int.Parse(frm["Bolumu"].ToString());

            VeriTabani.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Ekle()
        {
            if (Session["KullaniciAdSoyad"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var bolumler = VeriTabani.Bolumler.ToList();
            ViewBag.Bolumler = bolumler;
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(FormCollection frm)
        {
            if (Session["KullaniciAdSoyad"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Asistanlar asistan = new Asistanlar();

            asistan.Adi = frm["Adi"].ToString();
            asistan.Soyadi = frm["Soyadi"].ToString();
            asistan.Cinsiyeti = frm["Cinsiyeti"].ToString() == "1" ? true : false;
            asistan.BolumId = int.Parse(frm["Bolumu"].ToString());

            VeriTabani.Asistanlar.InsertOnSubmit(asistan);
            VeriTabani.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int? Id)
        {
            if (Session["KullaniciAdSoyad"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (Id == null)
            {
                return RedirectToAction("Index");
            }
            var srg = VeriTabani.Asistanlar.Where(x => x.Id == Id).FirstOrDefault();
            VeriTabani.Asistanlar.DeleteOnSubmit(srg);
            VeriTabani.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}