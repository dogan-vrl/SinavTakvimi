using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinavTakvimi.Models;
using SinavTakvimi.VeriTabani;

namespace SinavTakvimi.Controllers
{
    public class DersController : Controller
    {
        VeriTabaniDataContext VeriTabani = new VeriTabaniDataContext();

        // GET: Ders
        public ActionResult Index()
        {
            if (Session["KullaniciAdSoyad"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var srg = VeriTabani.Dersler.Select(x => new DersModel
            {
                Id = x.Id,
                Adi = x.DersAdi,
                Kodu = x.DersKodu,
                Bolumu = VeriTabani.Bolumler.Where(y => y.Id == x.BolumId).FirstOrDefault().BolumAdi,
                OgreniSayisi = (int)x.DersiAlanOgrenciSayisi,
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
            var srg = VeriTabani.Dersler.Where(x => x.Id == Id).FirstOrDefault();
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

            var srg = VeriTabani.Dersler.Where(x => x.Id == Id).FirstOrDefault();

            srg.DersAdi = frm["DersAdi"].ToString();
            srg.BolumId = int.Parse(frm["BolumId"].ToString());
            srg.DersinHocasi = frm["DersinHocasi"].ToString();
            srg.DersiAlanOgrenciSayisi = int.Parse(frm["DersiAlanOgrenciSayisi"].ToString());
            srg.DersKodu = frm["DersKodu"].ToString();
            srg.EngelliDurumu = frm["EngelliDurumu"].ToString() == "1" ? true : false;

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

            Dersler ders = new Dersler();

            ders.DersAdi = frm["DersAdi"].ToString();
            ders.BolumId = int.Parse(frm["BolumId"].ToString());
            ders.DersinHocasi = frm["DersinHocasi"].ToString();
            ders.DersiAlanOgrenciSayisi = int.Parse(frm["DersiAlanOgrenciSayisi"].ToString());
            ders.DersKodu = frm["DersKodu"].ToString();
            ders.EngelliDurumu = frm["EngelliDurumu"].ToString() == "1" ? true : false;

            VeriTabani.Dersler.InsertOnSubmit(ders);
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
            var srg = VeriTabani.Dersler.Where(x => x.Id == Id).FirstOrDefault();
            VeriTabani.Dersler.DeleteOnSubmit(srg);
            VeriTabani.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}