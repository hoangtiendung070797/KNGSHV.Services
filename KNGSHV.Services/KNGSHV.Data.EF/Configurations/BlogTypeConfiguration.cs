using KNGSHV.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace KNGSHV.Data.EF.Configurations
{
    public class BlogTypeConfiguration : IEntityTypeConfiguration<BlogType>
    {
        public void Configure(EntityTypeBuilder<BlogType> builder)
        {
            builder.ToTable("BlogTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
        }
    }
}
