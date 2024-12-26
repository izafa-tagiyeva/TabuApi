using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabu.Entities;

namespace Tabu.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Code);
            builder.HasIndex(x => x.Name)
            .IsUnique();
            builder.Property(x => x.Code)
            .IsFixedLength(true)
            .HasMaxLength(2);
            builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(32);
            builder.HasData(new Language
            {
                Code = "az",
                Name = "Azərbaycan",
                Icon = "https://cdn-icons-png.flaticon.com/512/330/33054.png"
            });
        }
    }
}
