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
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsiniz")]
        public string CariAdi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz")]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz")]
        public string CariSoyadi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13, ErrorMessage = "En fazla 13 karakter yazabilirsiniz")]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter yazabilirsiniz")]
        public string CariMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CariSifre { get; set; }

        public bool Durum {  get; set; }
        /* İlişkilerin Kurulması */
        public ICollection<SatisHareket> SatisHarekets { get; set; } //Bir carinin birden fazla ürün alabilir.
    }
}