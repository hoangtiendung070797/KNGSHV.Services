using System;
using System.Collections.Generic;
using System.Text;
using KNGSHV.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KNGSHV.Data.EF.Configurations
{
    public class ClassRoomConfiguration : IEntityTypeConfiguration<ClassRoom>
    {
        public void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            builder.ToTable("ClassRooms");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired();

            builder.HasOne(x => x.Account).WithMany(x => x.ClassRooms).HasForeignKey(x => x.CreatedUserId);


        }
    }
}
