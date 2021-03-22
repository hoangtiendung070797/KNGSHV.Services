using System;
using System.Collections.Generic;
using System.Text;
using KNGSHV.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KNGSHV.Data.EF.Configurations
{
    public class LearnerConfiguration : IEntityTypeConfiguration<Learner>
    {
        public void Configure(EntityTypeBuilder<Learner> builder)
        {
            builder.ToTable("Learners");
            builder.HasKey(x => x.Id);
            /*builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Sex).IsRequired();
            builder.Property(x => x.Birthday).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.ParentFullName).IsRequired();
            builder.Property(x => x.ParentPhone).IsRequired();*/


            builder.HasOne(x => x.Account).WithMany(x => x.Learners).HasForeignKey(x => x.CreatedUserId);

        }
    }
}
