using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinavTakvimi.Models;
using SinavTakvimi.VeriTabani;

namespace SinavTakvimi.Controllers
{
    public class SekreterController : Controller
    {
        VeriTabaniDataContext VeriTabani = new VeriTabaniDataContext();

        // GET: Ders
        public ActionResult Index()
        {
            if (Session["KullaniciAdSoyad"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var srg = VeriTabani.Sekreterler.Select(x => new SekreterModel
            {
                Id = x.Id,
                Adi = x.Adi,
                Soyadi = x.Soyadi,
                Bolumu = VeriTabani.Bolumler.Where(y => y.Id == x.BolumId).FirstOrDefault().BolumAdi,
                KullaniciAdi = x.KullaniciAdi,
                BolumId = x.BolumId,
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
            var srg = VeriTabani.Sekreterler.Where(x => x.Id == Id).FirstOrDefault();
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

            var srg = VeriTabani.Sekreterler.Where(x => x.Id == Id).FirstOrDefault();

            srg.Adi = frm["Adi"].ToString();
            srg.Soyadi = frm["Soyadi"].ToString();
            srg.BolumId = int.Parse(frm["BolumId"].ToString());
            srg.KullaniciAdi = frm["KullaniciAdi"].ToString();
            srg.Sifre = frm["Sifre"].ToString();

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

            Sekreterler sekreter = new Sekreterler();

            sekreter.Adi = frm["Adi"].ToString();
            sekreter.Soyadi = frm["Soyadi"].ToString();
            sekreter.BolumId = int.Parse(frm["BolumId"].ToString());
            sekreter.KullaniciAdi = frm["KullaniciAdi"].ToString();
            sekreter.Sifre = frm["Sifre"].ToString();

            VeriTabani.Sekreterler.InsertOnSubmit(sekreter);
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
            var srg = VeriTabani.Sekreterler.Where(x => x.Id == Id).FirstOrDefault();
            VeriTabani.Sekreterler.DeleteOnSubmit(srg);
            VeriTabani.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}