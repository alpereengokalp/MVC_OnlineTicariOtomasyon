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
        public ICollection<Urun> Uruns { get; set; } //Bir satış hareketinde birden fazla ürün olabilir
        public ICollection<Cariler> Carilers { get; set; } //Bir satış hareketinde birden fazla cari olabilir
        public ICollection<Personel> Personels { get; set; } //Bir satış hareketinde birden fazla personel olabilir
    }
           
}