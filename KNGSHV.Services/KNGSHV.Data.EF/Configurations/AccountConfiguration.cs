using KNGSHV.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KNGSHV.Data.EF.Configurations
{
    public class AccountConfiguration: IEntityTypeConfiguration<Account>
    {
        public void Configure( EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.ToTable("Accounts"); // rename table
            builder.HasKey(x => x.Id); //set primary key
            builder.Property(x => x.FullName).HasMaxLength(500); // set max length
        }
    }
}
