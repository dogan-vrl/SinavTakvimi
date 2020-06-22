using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinavTakvimi.Models
{
    public class DersModel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Kodu { get; set; }
        public string Bolumu { get; set; }
        public int BolumId { get; set; }
        public int OgreniSayisi { get; set; }
    }
}