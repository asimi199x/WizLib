using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wizlib_Model.Models;

namespace Wizlib_DataAccess.FluentConfig
{
    public class FluentBookDetailConfig : IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
        {
            modelBuilder.HasKey(bd => bd.BookDetail_Id);
            modelBuilder.Property(bd => bd.NumberOfChapters).IsRequired();
        }
    }
}
