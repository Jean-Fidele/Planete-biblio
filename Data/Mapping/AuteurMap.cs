using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Data.Mapping
{
    public class AuteurMap : IEntityTypeConfiguration<Auteur>
    {
        public void Configure(EntityTypeBuilder<Auteur> builder)
        {
            builder.ToTable("Auteur");
            builder.HasKey(x => x.AuteurId);
            builder.Property(x => x.AuteurId).ValueGeneratedNever();

            builder.Property(x => x.Prenom).IsRequired();
            builder.Property(x => x.Adresse).IsRequired();
            builder.Property(x => x.Date_naissance).IsRequired();
            builder.Property(x => x.Nom).IsRequired();
            builder.Property(x => x.Date_deces).IsRequired();
        }
    }
}
