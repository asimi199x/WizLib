using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wizlib_Model.Models;

namespace Wizlib_DataAccess.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            modelBuilder.HasKey(b => b.Book_Id);
            modelBuilder.Property(b => b.Price).IsRequired();
            modelBuilder.Property(b => b.Title).IsRequired();
            modelBuilder.Property(b => b.ISBN).IsRequired().HasMaxLength(15);

            // one to one relation between book and book detail
            modelBuilder.HasOne(z => z.Fluent_BookDetail).WithOne(z => z.Fluent_Book).HasForeignKey<Fluent_Book>(z => z.BookDetail_Id);

            // one to one relation between book and publisher 
            modelBuilder.HasOne(z => z.Fluent_Publisher).WithMany(z => z.Fluent_Books).HasForeignKey(z => z.Publisher_Id);
        }
    }
}
