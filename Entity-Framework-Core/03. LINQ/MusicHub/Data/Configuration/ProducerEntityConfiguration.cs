namespace MusicHub.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static MusicHub.Data.EntityValidationConstrants.Producer;
    using Models;
    public class ProducerEntityConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> entity)
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name)
                .IsUnicode()
                .HasMaxLength(ProducerNameMaxLength);

            entity.Property(e => e.Pseudonym)
                .IsUnicode()
                .IsRequired(false);

            entity.Property(e => e.PhoneNumber)
                .IsRequired(false);

        }
    }
}
