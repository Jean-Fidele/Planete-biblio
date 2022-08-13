using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planete_biblio.Entities
{
    [Table("Auteur")]
    public class Auteur
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String AuteurId { get; set; }

        public String Nom { get; set; }

        public String Prenom { get; set; }

        public DateTime Date_naissance { get; set; }

        public String Adresse { get; set; }

        public DateTime Date_deces { get; set; }
    }
}
