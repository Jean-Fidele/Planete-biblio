using Data.Mapping;
using Domain.Entities;
using EntityFrameworkCore.SqlServer.JsonExtention;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuteurMap());
            builder.ApplyConfiguration(new CategorieMap());
            builder.ApplyConfiguration(new EditeurMap());
            builder.ApplyConfiguration(new LivreMap());
            base.OnModelCreating(builder);
        }
    }
}