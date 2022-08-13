
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using planete_biblio.Entities;
using planete_biblio.Models;

namespace planete_biblio.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Livre> Livre { get; set; }

        public DbSet<Editeur> Editeur { get; set; }

        public DbSet<Auteur> Auteur { get; set; }

        public DbSet<Categorie> Categorie { get; set; }
    }
}