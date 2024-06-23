using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    //Tabloları context sınıfında kullanacağız.
    //Tabloları SQL'e yansıtmadan önce oluşturduğumuz son sınıf burasıdır.
    //Buranın üzerinden tabloları SQL'e yansıtacağız.
    //Backend tarafında tablolara buranın üzerinden ulaşıyoruz.
    public class Context: DbContext //Inheritance(miras) aldık -> db set gibi komutları kullanabilmek için aldık.
    {
        //Property türü DbSet oldu çünkü artık değişken ya da sütun adı bazlı yerine tablo bazlı çalışacağız ve
        //bu tablo da veritabanına yansıtılacak
        public DbSet<Admin> Admins { get; set; } //public DbSet<HangiTablo> HangiTablos -> Admin tablosu sql'de admins olarak s takısı ile gözükür 
        public DbSet<Cariler> Carilers { get; set; }
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Faturalar> Faturalars { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<SatisHareket> SatisHarekets { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Detay> Detays { get; set; }

        //Kısaca; s'leri koyma sebebimiz tablo isimlerimizin sınıf isimlerimize karışmaması için
    }
}