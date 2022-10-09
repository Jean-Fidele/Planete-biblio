using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auteur>().HasData(
                new Auteur { AuteurId = "101", Nom = "Jean 1", Prenom = "Fidele 1", Adresse = "Anjanahary 1"},
                new Auteur { AuteurId = "102", Nom = "Jean 2", Prenom = "Fidele 2", Adresse = "Anjanahary 2"},
                new Auteur { AuteurId = "103", Nom = "Jean 3", Prenom = "Fidele 3", Adresse = "Anjanahary 3"}
            );
        }
    }
}
