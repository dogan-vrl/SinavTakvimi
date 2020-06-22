using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinavTakvimi.Models
{
    public class SinavModel
    {
        public int Id { get; set; }
        public string BolumAdi { get; set; }
        public string Ders { get; set; }
        public string Derslik { get; set; }
        public string Asistanlar { get; set; }
        public DateTime? Tarih { get; set; }
        public TimeSpan? BaslangicSaati { get; set; }
    }
}