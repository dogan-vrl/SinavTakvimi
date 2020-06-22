using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinavTakvimi.Models
{
    public class SinavTakvimiModel
    {
        public DateTime? Tarih { get; set; }
        public string ilksaat { get; set; }
        public string ikincisaat { get; set; }
        public string ucuncusaat { get; set; }
        public string dorduncusaat { get; set; }
        public string besincisaat { get; set; }
    }
}