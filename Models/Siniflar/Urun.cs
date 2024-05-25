using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }

        /* Kısıtlama Yapılması */
        [Column(TypeName ="Varchar")] //Veritabanına update edilince string --> nvarchar olarak tutulur ve bellekte çok fazla yer ayırmış olur
        [StringLength(30)]            //Bu yüzden kısıtlama getiririz
        public string UrunAdi { get; set; }               

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; } //2 byte --> -32768 ile 32767
        public decimal AlisFiyati { get; set; }
        public decimal SatisFiyati { get; set; }
        public bool Durum { get; set; } //Ürünler için kritik seviye (stok sayısı 20 altı) durumu

        [Column(TypeName = "Varchar")] //Dosyalı tutulacak 250 karakter olmalı uzun link olma ihtimali olabilir.
        [StringLength(250)]
        public string UrunGorsel { get; set; }



        /* İlişkilerin Kurulması */
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }  //Bir ürünün sadece bir kategorisi olabilir.
        //Kategori sınıfına bağlı olan Kategori isminde property oluşturmuş olduk.
        //public SınıfAdı PropertyAdı

        public ICollection<SatisHareket> SatisHarekets { get; set; } //Her ürünün birden çok satışı olabilir.
    }
    
}