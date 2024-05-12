using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    //DB firstte hazır bir veritabanını model olarak projenin içerisine dahil ettiğimizde  bu veritabanı üzerinde bulunan tabloları ve sütunları,
    //sınıflar ve sınıfların içerisinde değişken olarak (sınıfların içerisinde direkt erişim sağlanamıyor) property şeklinde atama yapıyor.
    
    //Burada kategori diyerek veritabanında bir tablo oluşturacağımızı bildirmiş olduk.Kategori isimli bir tablo ve içerisinde sütunlar olacak demektir.
    //Kategori tablomuzun içerisinde normalde olması gereken iki sütun var:
	//KategoriID
	//KategoriAdi
    //Bunlar üzerinden işlemlerimizi gerçekleştireceğiz.
    //Burada değişken değil property denilen yapılar üzerinden işlemleri sürdüreceğiz.

    public class Kategori
    {
        //prop nasıl tanımlanır? prop yaz --> iki kere tab tuşuna bas

        //Geliştirme yaklaşımı olarak entity framework kullanılacak, temel crud (listeleme, ekleme, güncelleme, silme) işlemlerini gerçekleştirirken
        //mutlaka bir "primary keye" ihityacımız vardır.

        [Key] //[Key] yazınca üzerinde bulunduğu değişkeni primary key yapar.
        public int KategoriID { get; set; } //public, propert'in erişim belirleyici türü herkese açık olacak

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KategoriAdi { get; set; }




        /* İlişkilerin Kurulması */
        public ICollection<Urun> Uruns { get; set; } //Her kategoride birden fazla ürün yer alabilir.
                                                     //ICollection<Sınıf Adı> SınıfAdıs --> Veritabanında sınıf adına s takısı alarak oluşmuş olur

        //ICollection<Türü> birden fazla ürünü bir arada tutabilecek olan "koleksiyon" a ihtiyacımız var.
        //ICollection -> Interface'dir mutlaka bak!!

        //ÜRÜN-KATEGORİ İLİŞKİSİ
        //One to Many İlişki
        //Her ürün bir kategoride yer alır, bir kategori ise birden fazla ürün içerebilir.
        //Beyaz eşya kategorisi  çamaşır makinesi, bulaşık makinesi, buzdolabı, ocak
    }
}