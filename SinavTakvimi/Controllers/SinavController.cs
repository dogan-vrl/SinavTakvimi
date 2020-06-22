using SinavTakvimi.Models;
using SinavTakvimi.VeriTabani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinavTakvimi.Controllers
{
    public class SinavController : Controller
    {
        VeriTabaniDataContext VeriTabani = new VeriTabaniDataContext();

        // GET: Sınav
        public ActionResult Index()
        {
            if (Session["KullaniciAdSoyad"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var srg = VeriTabani.Sinavlar.AsQueryable();

            if (int.Parse(Session["Yetki"].ToString()) == 0)
            {
                srg = srg.Where(x => x.BolumId == int.Parse(Session["KullaniciBolum"].ToString()));
            }

            var srg2 = VeriTabani.Sinavlar.Select(x => new SinavModel
            {
                Id = x.Id,
                Ders = VeriTabani.Dersler.Where(y => y.Id == x.DersId).FirstOrDefault().DersAdi,
                Derslik = VeriTabani.Derslikler.Where(y => y.Id == x.DerslikId).FirstOrDefault().DerslikAdi,
                BolumAdi = VeriTabani.Bolumler.Where(y => y.Id == x.BolumId).FirstOrDefault().BolumAdi,
                Asistanlar = x.AsistanId,
                Tarih = x.Tarih,
                BaslangicSaati = x.BaslangicSaati
            }).OrderBy(x=>x.Tarih).ToList();

            foreach (var item in srg2.ToList())
            {
                List<string> AsistanIdleri = new List<string>();

                foreach (var item2 in item.Asistanlar.Trim(','))
                {
                    if (item2.ToString() != ",")
                    {
                        AsistanIdleri.Add(item2.ToString());
                    }
                }
                string metin = "";
                foreach (var item2 in AsistanIdleri)
                {
                    if (!String.IsNullOrEmpty(metin))
                    {
                        metin += " - ";
                    }
                    metin += VeriTabani.Asistanlar.Where(x => x.Id == int.Parse(item2)).Select(x => x.Adi + " " + x.Soyadi).FirstOrDefault();
                }
                item.Asistanlar = metin;
            }

            return View(srg2);
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

            ViewBag.Bolumler = VeriTabani.Bolumler.ToList();
            ViewBag.Dersler = VeriTabani.Dersler.ToList();
            ViewBag.Derslikler = VeriTabani.Derslikler.ToList();
            ViewBag.Asistanlar = VeriTabani.Asistanlar.ToList();
            var srg = VeriTabani.Sinavlar.Where(x => x.Id == Id).FirstOrDefault();
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

            var srg = VeriTabani.Sinavlar.Where(x => x.Id == Id).FirstOrDefault();

            srg.DersId = int.Parse(frm["DersId"].ToString());
            srg.DerslikId = int.Parse(frm["DerslikId"].ToString());
            srg.BolumId = int.Parse(frm["BolumId"].ToString());
            srg.AsistanId = frm["AsistanId"].ToString();
            srg.Tarih = DateTime.Parse(frm["Tarih"].ToString());
            srg.BaslangicSaati = TimeSpan.Parse(frm["BaslangicSaati"].ToString());

            VeriTabani.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Ekle()
        {
            if (Session["KullaniciAdSoyad"] == null)
            {
                return RedirectToAction("Index", "Login");
            }


            ViewBag.Bolumler = VeriTabani.Bolumler.ToList();
            ViewBag.Dersler = VeriTabani.Dersler.ToList();
            ViewBag.Derslikler = VeriTabani.Derslikler.ToList();
            ViewBag.Asistanlar = VeriTabani.Asistanlar.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(FormCollection frm)
        {
            if (Session["KullaniciAdSoyad"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Sinavlar sinav = new Sinavlar();

            sinav.DersId = int.Parse(frm["DersId"].ToString());
            sinav.DerslikId = int.Parse(frm["DerslikId"].ToString());
            sinav.BolumId = int.Parse(frm["BolumId"].ToString());
            sinav.AsistanId = frm["AsistanId"].ToString();
            sinav.Tarih = DateTime.Parse(frm["Tarih"].ToString());
            sinav.BaslangicSaati = TimeSpan.Parse(frm["BaslangicSaati"].ToString());

            VeriTabani.Sinavlar.InsertOnSubmit(sinav);
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
            var srg = VeriTabani.Sinavlar.Where(x => x.Id == Id).FirstOrDefault();
            VeriTabani.Sinavlar.DeleteOnSubmit(srg);
            VeriTabani.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}