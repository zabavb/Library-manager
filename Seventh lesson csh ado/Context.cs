using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seventh_lesson_csh_ado
{
    public class Context : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Library;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>(item => item.HasNoKey());

            modelBuilder.Entity<Author>().HasData(new Author { ID = 1, Name = "Anton", Surname = "Some1" });
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher[]
                {
                    new Publisher{ ID = 1, Name = "First"},
                    new Publisher{ ID = 2, Name = "Second"}
                });
        }
    }
}