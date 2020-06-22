using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using SinavTakvimi.Models;
using SinavTakvimi.VeriTabani;

namespace SinavTakvimi.Controllers
{
    public class HomeController : Controller
    {
        VeriTabaniDataContext VeriTabani = new VeriTabaniDataContext();


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

            List<SinavTakvimiModel> sinavTakvimi = new List<SinavTakvimiModel>();

            var Tarihler = srg.OrderBy(x => x.Tarih).Select(x => x.Tarih).Distinct().ToList();


            foreach (DateTime item in Tarihler)
            {
                SinavTakvimiModel s = new SinavTakvimiModel();
                s.Tarih = item;
                foreach (var item2 in srg.Where(x => x.Tarih == item && x.BaslangicSaati == TimeSpan.Parse("08:30")).ToList())
                {
                    if (!String.IsNullOrEmpty(s.ilksaat))
                    {
                        s.ilksaat += " - ";
                    }
                    s.ilksaat += VeriTabani.Dersler.Where(x => x.Id == item2.DersId).Select(x => x.DersKodu + " " + x.DersAdi).FirstOrDefault();
                }
                foreach (var item2 in srg.Where(x => x.Tarih == item && x.BaslangicSaati == TimeSpan.Parse("10:30")).ToList())
                {
                    if (!String.IsNullOrEmpty(s.ikincisaat))
                    {
                        s.ikincisaat += " - ";
                    }
                    s.ikincisaat += VeriTabani.Dersler.Where(x => x.Id == item2.DersId).Select(x => x.DersKodu + " " + x.DersAdi).FirstOrDefault();
                }
                foreach (var item2 in srg.Where(x => x.Tarih == item && x.BaslangicSaati == TimeSpan.Parse("13:00")).ToList())
                {
                    if (!String.IsNullOrEmpty(s.ucuncusaat))
                    {
                        s.ucuncusaat += " - ";
                    }
                    s.ucuncusaat += VeriTabani.Dersler.Where(x => x.Id == item2.DersId).Select(x => x.DersKodu + " " + x.DersAdi).FirstOrDefault();
                }
                foreach (var item2 in srg.Where(x => x.Tarih == item && x.BaslangicSaati == TimeSpan.Parse("15:00")).ToList())
                {
                    if (!String.IsNullOrEmpty(s.dorduncusaat))
                    {
                        s.dorduncusaat += " - ";
                    }
                    s.dorduncusaat += VeriTabani.Dersler.Where(x => x.Id == item2.DersId).Select(x => x.DersKodu + " " + x.DersAdi).FirstOrDefault();
                }
                foreach (var item2 in srg.Where(x => x.Tarih == item && x.BaslangicSaati == TimeSpan.Parse("17:00")).ToList())
                {
                    if (!String.IsNullOrEmpty(s.besincisaat))
                    {
                        s.besincisaat += " - ";
                    }
                    s.besincisaat += VeriTabani.Dersler.Where(x => x.Id == item2.DersId).Select(x => x.DersKodu + " " + x.DersAdi).FirstOrDefault();
                }
                sinavTakvimi.Add(s);
            }

            ViewBag.Tablo = sinavTakvimi;
            return View(srg.ToList());
        }

        public void GridExportToExcel()
        {
            var srg = VeriTabani.Sinavlar.AsQueryable();

            if (int.Parse(Session["Yetki"].ToString()) == 0)
            {
                srg = srg.Where(x => x.BolumId == int.Parse(Session["KullaniciBolum"].ToString()));
            }

            List<SinavTakvimiModel> sinavTakvimi = new List<SinavTakvimiModel>();

            var Tarihler = srg.OrderBy(x => x.Tarih).Select(x => x.Tarih).Distinct().ToList();


            foreach (DateTime item in Tarihler)
            {
                SinavTakvimiModel s = new SinavTakvimiModel();
                s.Tarih = item;
                foreach (var item2 in srg.Where(x => x.Tarih == item && x.BaslangicSaati == TimeSpan.Parse("08:30")).ToList())
                {
                    if (!String.IsNullOrEmpty(s.ilksaat))
                    {
                        s.ilksaat += " - ";
                    }
                    s.ilksaat += VeriTabani.Dersler.Where(x => x.Id == item2.DersId).Select(x => x.DersKodu + " " + x.DersAdi).FirstOrDefault();
                }
                foreach (var item2 in srg.Where(x => x.Tarih == item && x.BaslangicSaati == TimeSpan.Parse("10:30")).ToList())
                {
                    if (!String.IsNullOrEmpty(s.ikincisaat))
                    {
                        s.ikincisaat += " - ";
                    }
                    s.ikincisaat += VeriTabani.Dersler.Where(x => x.Id == item2.DersId).Select(x => x.DersKodu + " " + x.DersAdi).FirstOrDefault();
                }
                foreach (var item2 in srg.Where(x => x.Tarih == item && x.BaslangicSaati == TimeSpan.Parse("13:00")).ToList())
                {
                    if (!String.IsNullOrEmpty(s.ucuncusaat))
                    {
                        s.ucuncusaat += " - ";
                    }
                    s.ucuncusaat += VeriTabani.Dersler.Where(x => x.Id == item2.DersId).Select(x => x.DersKodu + " " + x.DersAdi).FirstOrDefault();
                }
                foreach (var item2 in srg.Where(x => x.Tarih == item && x.BaslangicSaati == TimeSpan.Parse("15:00")).ToList())
                {
                    if (!String.IsNullOrEmpty(s.dorduncusaat))
                    {
                        s.dorduncusaat += " - ";
                    }
                    s.dorduncusaat += VeriTabani.Dersler.Where(x => x.Id == item2.DersId).Select(x => x.DersKodu + " " + x.DersAdi).FirstOrDefault();
                }
                foreach (var item2 in srg.Where(x => x.Tarih == item && x.BaslangicSaati == TimeSpan.Parse("17:00")).ToList())
                {
                    if (!String.IsNullOrEmpty(s.besincisaat))
                    {
                        s.besincisaat += " - ";
                    }
                    s.besincisaat += VeriTabani.Dersler.Where(x => x.Id == item2.DersId).Select(x => x.DersKodu + " " + x.DersAdi).FirstOrDefault();
                }
                sinavTakvimi.Add(s);
            }


            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] {
                        new DataColumn("Günler/Saatler"),
                        new DataColumn("08:30-10:00"),
                        new DataColumn("10:30-12:00"),
                        new DataColumn("13:00-14:30"),
                        new DataColumn("15:00-16:30"),
                        new DataColumn("17:00-18:30")
            
            });
            foreach (var item in sinavTakvimi)
            {
                dt.Rows.Add(item.Tarih.Value.ToString("dd MMMM yyyy"), item.ilksaat, item.ikincisaat, item.ucuncusaat, item.dorduncusaat, item.besincisaat);
            }

            var grid = new GridView();
            grid.DataSource = dt;
            grid.DataBind();

            Response.ClearContent();
            Response.Charset = "ISO-8859-9";
            Response.AddHeader("content-disposition", "attachment; filename=Sınav Takvimi.xls");

            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Write(sw.ToString());
            Response.End();
        }
    }
}