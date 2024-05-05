using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Gider
    {
        [Key]
        public int GiderID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Aciklama { get; set; } //Netin gideri --> Elektrik Faturası
        public DateTime Tarih { get; set; } //Bu gider ne zaman oluştu?
        public decimal Tutar { get; set; } //Bu gider ne kadar?
    }
}