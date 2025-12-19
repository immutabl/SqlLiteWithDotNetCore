using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlLiteWithDotNetCore.Domain.Entities;

namespace SqlLiteWithDotNetCore.Data.Configurations;

public sealed class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    /*  Configurations here will modify the dbschema
       this code isn't for validation purposes             */ 
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contact");
        builder.HasKey(x => x.Id);
        
        //One-to-many relationship between Contact and Country
        builder.HasOne(c => c.Country)
            .WithMany(cn => cn.Contacts)
            .HasForeignKey(c => c.CountryId);

        builder.Property(x => x.Forename).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Surname).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Telno).IsRequired().HasMaxLength(50);

        // Optional hardening:
        // builder.HasIndex(x => x.Email).IsUnique();
    }
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Country");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Capital).IsRequired().HasMaxLength(50);
        builder.Property(x => x.DialingCode).IsRequired().HasMaxLength(50);
        builder.Property(x => x.CountryCode).IsRequired().HasMaxLength(3);

        // Optional hardening:
        // builder.HasIndex(x => x.Email).IsUnique();
    }
}