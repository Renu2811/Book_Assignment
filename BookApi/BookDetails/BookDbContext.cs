using BookDetails.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookDetails
{
   
        public class BookDbContext : DbContext
        {
            public BookDbContext()
            {

            }
            public BookDbContext(DbContextOptions options) : base(options) { }
            public DbSet<Book> Books { get; set; }
            public DbSet<AddCart> Cart { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
            {
                OptionsBuilder.UseSqlServer(@"Server=DESKTOP-2PKBUH0\SQLEXPRESS;Database=BooksDb;Trusted_Connection=True;");
            }
        }
    }




