using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlLiteWithDotNetCore.Domain.Entities;

namespace SqlLiteWithDotNetCore.Data.Configurations
{
    internal class SqlLiteWithDotNetCoreEntityConfiguration: IEntityTypeConfiguration<Contact>
    {
        /*  Configurations here will modify the dbschema
            this code isn't for validation purposes             */ 
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Forename)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x=> x.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Telno)
                .IsRequired()
                .HasMaxLength(50);
        }

    }
}
