using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinavTakvimi.Models
{
    public class SekreterModel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Bolumu { get; set; }
        public int? BolumId { get; set; }
    }
}