using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class LivreMap : IEntityTypeConfiguration<Livre>
    {
        public void Configure(EntityTypeBuilder<Livre> builder)
        {
            builder.HasKey(x => x.Numero_identite);
            builder.Property(x => x.Date_edition);
            builder.Property(x => x.Titre);
            builder.Property(x => x.Langue);
            builder.Property(x => x.Description);
            builder.Property(x => x.Prix_achat);

            builder.HasOne(x => x.Categorie)
                   .WithMany(x => x.Livres)
                   .HasForeignKey(x => x.CategorieId);
        }
    }
}
