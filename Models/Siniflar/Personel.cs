using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAdi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSoyadi { get; set; }

        [Column(TypeName = "Varchar")] //Dosyalı tutulacak 250 karakter olmalı uzun link olma ihtimali olabilir.
        [StringLength(250)]
        public string PersonelGorsel { get; set; } //Görseller neden string olarak tutulur? 
                                                   //Veritabanını ve programı çok şişereceği için kendisini değil sadece yolunu tutarız.


        /* İlişkilerin Kurulması */
        public SatisHareket SatisHareket { get; set; } //Bir personelin bir satış hareketi vardır

        public Departman Departman { get; set; }//Bir personel bir departmanda çalışır.
    }
}