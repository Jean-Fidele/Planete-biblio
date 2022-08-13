using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planete_biblio.Entities
{
    [Table("Editeur")]
    public class Editeur
    {
        [Key]
        public String EditeurId { get; set; }

        public String Nom { get; set; }

        public String Prenom { get; set; }

        public DateTime Date_naissance { get; set; }

        public String Adresse { get; set; }

        public DateTime Date_dece { get; set; }
    }
}
