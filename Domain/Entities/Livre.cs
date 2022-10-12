namespace Domain.Entities
{
    public class Livre
    {
        public string Numero_identite { get; set; }
        public string Titre { get; set; }
        public string Langue { get; set; }
        public DateTime Date_edition { get; set; }
        public string Description { get; set; }
        public Double Prix_achat { get; set; }

        /*
        // Foreign keys
        public int AuteurId { get; set; }
        public virtual Auteur Auteur { get; set; }

        // Foreign keys
        public int EditeurId { get; set; }
        public Editeur Editeur { get; set; }
          */

        // Foreign keys
        public int CategorieId { get; set; }
        public virtual Categorie Categorie { get; set; }
    }

}
