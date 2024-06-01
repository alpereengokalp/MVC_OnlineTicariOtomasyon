using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisID { get; set; }
        //İlişkili tablo kullan!
        
        //ürün
        //cari (kime satıldı)
        //personel (kim sattı)        
        public DateTime Tarih { get; set; } //ne zaman satıldı
        public int Adet { get; set; } //kaç adet satıldı
        public decimal Fiyat { get; set; } //her biri kaç fiyata satıldı
        public decimal ToplamTutar { get; set; } //toplam tutar kasaya gidecek


        /* İlişkilerin Kurulması */
        public int UrunId { get; set; }
        public int CariId { get; set; }
        public int PersonelId { get; set; }

        public virtual Urun Urun { get; set; } //Bir satış hareketinde bir ürüne aittir
        public virtual Cariler Cariler { get; set; } //Bir satış hareketi bir cariye aittir
        public virtual Personel Personel { get; set; } //Bir satış hareketi bir personele aittir
    }
           
}