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
    public class EditeurMap : IEntityTypeConfiguration<Editeur>
    {
        public void Configure(EntityTypeBuilder<Editeur> builder)
        {
            builder.ToTable("Editeur");
            builder.HasKey(x => x.EditeurId);
            builder.Property(x => x.EditeurId).ValueGeneratedNever();

            builder.Property(x => x.Nom);
            builder.Property(x => x.Prenom);
            builder.Property(x => x.Adresse);
            builder.Property(x => x.Date_naissance);
            builder.Property(x => x.Date_dece);
        }
    }
}
