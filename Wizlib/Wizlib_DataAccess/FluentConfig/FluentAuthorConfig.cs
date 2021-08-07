using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wizlib_Model.Models;

namespace Wizlib_DataAccess.FluentConfig
{
    public class FluentAuthorConfig : IEntityTypeConfiguration<Fluent_Author>
    {
        public void Configure(EntityTypeBuilder<Fluent_Author> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Author_Id);
            modelBuilder.Property(a => a.FirstName).IsRequired();
            modelBuilder.Property(a => a.LastName).IsRequired();
            modelBuilder.Ignore(a => a.FullName);
        }
    }
}
