using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Departman //Perosnel Departmanları
    {
        [Key]
        public int DepartmanID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmanAdi { get; set; }


        /* İlişkilerin Kurulması */
        public bool Durum {  get; set; }   
        public ICollection<Personel> Personels { get; set; } //Bir departmanda birden fazla personel bulunabilir.
    }
}