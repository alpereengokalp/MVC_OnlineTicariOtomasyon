using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Aciklama { get; set; } //Ütü
        public int Miktar { get; set; } //2 ütü aldık
        public decimal BirimFiyat { get; set; } //Her ütü 400 TL
        public decimal Tutar { get; set; } //İki ütü -> 800 TL


        /* İlişkilerin Kurulması */
        public int FaturaId { get; set; }

        public virtual Faturalar Faturalar { get; set; } //Bir fatura kaleminde sadece bir tane faturası olabilir.
    }
    
}