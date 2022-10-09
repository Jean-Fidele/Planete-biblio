using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Categorie")]
    public class Categorie
    {
        [Key]
        public String CategorieId { get; set; }

        public String Libelle { get; set; }
    }
}
