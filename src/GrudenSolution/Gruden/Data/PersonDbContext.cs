using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using System;
using Gruden.Data.Models;

namespace Gruden.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "PersonDb");
        }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>(person =>
            //{
            //    var personNumber = person.Property(p => p.Id);
            //    personNumber.ValueGeneratedOnAdd();
            //    // only for in-memory
            //    if (Database.IsInMemory())
            //        personNumber.HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            //});
        }
    }
}
