namespace MusicHub.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static EntityValidationConstrants.Writer;
    using Models;
    public class WriterEntityConfiguration : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsUnicode()
                .HasMaxLength(WriterNameMaxLength);

            entity.Property(e => e.Pseudonym)
                .IsRequired(false);
        }
    }
}
