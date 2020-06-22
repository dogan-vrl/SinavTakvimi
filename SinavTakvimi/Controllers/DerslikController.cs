using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinavTakvimi.VeriTabani;
using SinavTakvimi.Models;

namespace SinavTakvimi.Controllers
{
    public class DerslikController : Controller
    {
        VeriTabaniDataContext VeriTabani = new VeriTabaniDataContext();

        // GET: Ders
        public ActionResult Index()
        {
            if (Session["KullaniciAdSoyad"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var srg = VeriTabani.Derslikler.Select(x => new DerslikModel
            {
                Id = x.Id,
                Adi = x.DerslikAdi,
                Kodu = x.DerslikKod,
                Bolumu = VeriTabani.Bolumler.Where(y => y.Id == x.BolumId).FirstOrDefault().BolumAdi,
                Kapasitesi = (int)x.DerslikKapasitesi,
                BolumId = (int)x.BolumId,
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
            var srg = VeriTabani.Derslikler.Where(x => x.Id == Id).FirstOrDefault();
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

            var srg = VeriTabani.Derslikler.Where(x => x.Id == Id).FirstOrDefault();

            srg.DerslikAdi = frm["DerslikAdi"].ToString();
            srg.BolumId = int.Parse(frm["BolumId"].ToString());
            if (!String.IsNullOrEmpty(frm["DerslikKat"]))
            {
                srg.DerslikKat = byte.Parse(frm["DerslikKat"].ToString());
            }
            else
            {
                srg.DerslikKat = null;
            }
            srg.DerslikKapasitesi = int.Parse(frm["DerslikKapasitesi"].ToString());
            srg.DerslikKod = frm["DerslikKod"].ToString();
            srg.Aciklama = frm["Aciklama"].ToString() ?? "";

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

            Derslikler derslik = new Derslikler();

            derslik.DerslikAdi = frm["DerslikAdi"].ToString();
            derslik.BolumId = int.Parse(frm["BolumId"].ToString());
            if (!String.IsNullOrEmpty(frm["DerslikKat"]))
            {
                derslik.DerslikKat = byte.Parse(frm["DerslikKat"].ToString());
            }
            derslik.DerslikKapasitesi = int.Parse(frm["DerslikKapasitesi"].ToString());
            derslik.DerslikKod = frm["DerslikKod"].ToString();
            derslik.Aciklama = frm["Aciklama"].ToString() ?? "";

            VeriTabani.Derslikler.InsertOnSubmit(derslik);
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
            var srg = VeriTabani.Derslikler.Where(x => x.Id == Id).FirstOrDefault();
            VeriTabani.Derslikler.DeleteOnSubmit(srg);
            VeriTabani.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}