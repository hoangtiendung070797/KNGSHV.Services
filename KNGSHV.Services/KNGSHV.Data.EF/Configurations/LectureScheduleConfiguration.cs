using System;
using System.Collections.Generic;
using System.Text;
using KNGSHV.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KNGSHV.Data.EF.Configurations
{
    public class LectureScheduleConfiguration : IEntityTypeConfiguration<LectureSchedule>
    {
        public void Configure(EntityTypeBuilder<LectureSchedule> builder)
        {
            builder.ToTable("LectureSchedules");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.FromDate).IsRequired();
            builder.Property(x => x.ToDate).IsRequired();
            builder.Property(x => x.FromTime).IsRequired();
            builder.Property(x => x.ToTime).IsRequired();

            builder.HasOne(x => x.Lecture).WithMany(x => x.LectureSchedules).HasForeignKey(x => x.LectureId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Learner).WithMany(x => x.LectureSchedules).HasForeignKey(x => x.LeanerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Subject).WithMany(x => x.LectureSchedules).HasForeignKey(x => x.SubjectId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
