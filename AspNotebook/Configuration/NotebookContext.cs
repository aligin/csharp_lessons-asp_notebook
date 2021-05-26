using AspNotebook.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AspNotebook.Configuration
{
    public class NotebookContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public NotebookContext(DbContextOptions<NotebookContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity
                    .Property(x => x.Name)
                    .HasMaxLength(100);

                entity
                    .Property(x => x.Telephone)
                    .HasMaxLength(20);

                entity.HasData(new List<Person>()
                {
                    new Person(){ Id = 1, Name = "Ляксандр", Telephone = "555-55-55" }
                });
            });
        }
    }
}
