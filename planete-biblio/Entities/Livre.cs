using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planete_biblio.Entities
{
    [Table("Livre")]
    public class Livre
    {
        public Livre() { 
            this.Auteurs = new List<Auteur>();
            this.Editeurs = new List<Editeur>();
            this.Categories = new List<Categorie>();
        }

        [Key]
        public String Numero_identite { get; set; }

        public String Titre { get; set; }

        public String Langue { get; set; }

        public DateTime Date_edition { get; set; }

        public String Description { get; set; }

        public Double Prix_achat { get; set; }

        public ICollection<Auteur> Auteurs { get; set; }

        public ICollection<Editeur> Editeurs { get; set; }

        public ICollection<Categorie> Categories { get; set; }

    }

}
