using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SqlLiteWithDotNetCore.Domain.Entities;

namespace SqlLiteWithDotNetCore.Infrastructure
{
    public class SqlLiteWithDotNetCoreDbContext: DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }

        public SqlLiteWithDotNetCoreDbContext(DbContextOptions<SqlLiteWithDotNetCoreDbContext> options): base(options){

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //do configurations in program.cs
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //searches project for any implementers of IEntityTypeConfiguration<T> and applies their configs
            builder.ApplyConfigurationsFromAssembly(typeof(SqlLiteWithDotNetCoreDbContext).Assembly);
        }
    }
}
