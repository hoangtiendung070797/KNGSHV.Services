using System;
using System.Collections.Generic;
using System.Text;
using KNGSHV.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KNGSHV.Data.EF.Configurations
{
    public class RegistrationFormConfiguration : IEntityTypeConfiguration<RegistrationForm>
    {
        public void Configure(EntityTypeBuilder<RegistrationForm> builder)
        {
            builder.ToTable("RegistrationForms");
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.Address).IsRequired();
        }
    }
}
