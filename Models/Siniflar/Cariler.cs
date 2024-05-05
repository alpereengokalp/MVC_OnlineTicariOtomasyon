using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Cariler //Müşteriler
    {
        [Key]
        public int CariID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariAdi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariSoyadi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }


        /* İlişkilerin Kurulması */
        public SatisHareket SatisHareket { get; set; } //Bir carinin bir satış hareketi vardır
    }
}