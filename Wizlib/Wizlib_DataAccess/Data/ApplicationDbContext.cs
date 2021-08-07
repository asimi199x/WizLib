using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Wizlib_Model.Models;
using Wizlib_DataAccess.FluentConfig;

namespace Wizlib_DataAccess.Data
{    
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Fluent_BookDetail> Fluent_BookDetails { get; set; }

        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // cấu hình Fluent API

            // tạo composite Key
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.Author_Id, ba.Book_Id });

            modelBuilder.ApplyConfiguration(new FluentBookConfig()); 
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig()); 
            modelBuilder.ApplyConfiguration(new FluentBookAuthorConfig()); 
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig()); 
            modelBuilder.ApplyConfiguration(new FluentAuthorConfig()); 
           

        }
    }
}
