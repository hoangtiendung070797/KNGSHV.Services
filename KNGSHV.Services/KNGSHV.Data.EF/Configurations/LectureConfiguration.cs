using System;
using System.Collections.Generic;
using System.Text;
using KNGSHV.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KNGSHV.Data.EF.Configurations
{
    public class LectureConfiguration : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            builder.ToTable("Lectures");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Sex).IsRequired();
            builder.Property(x => x.Birthday).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.Level).IsRequired();
            builder.Property(x => x.Image).IsRequired();

            builder.HasOne(x => x.Account).WithMany(x => x.Lectures).HasForeignKey(x => x.CreatedUserId);
            builder.HasOne(x => x.Account).WithMany(x => x.Lectures).HasForeignKey(x => x.AccountId);


        }
    }
}
