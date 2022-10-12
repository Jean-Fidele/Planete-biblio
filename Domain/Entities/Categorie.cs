using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Categorie
    {
        public int CategorieId { get; set; }
        public String Libelle { get; set; }
        public virtual ICollection<Livre> Livres { get; set; }
    }
}
