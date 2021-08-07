using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wizlib_Model.Models;

namespace Wizlib_DataAccess.FluentConfig
{
    public class FluentBookAuthorConfig : IEntityTypeConfiguration<Fluent_BookAuthor>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthor> modelBuilder)
        {
            modelBuilder.HasKey(ba => new { ba.Author_Id, ba.Book_Id });
            modelBuilder.HasOne(z => z.Fluent_Book).WithMany(z => z.Fluent_BookAuthors).HasForeignKey(z => z.Book_Id);
            modelBuilder.HasOne(z => z.Fluent_Author).WithMany(z => z.Fluent_BookAuthors).HasForeignKey(z => z.Author_Id);
        }
    }
}
