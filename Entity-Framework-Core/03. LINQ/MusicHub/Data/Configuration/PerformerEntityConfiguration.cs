namespace MusicHub.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static EntityValidationConstrants.Performer;
    using Models;
    public class PerformerEntityConfiguration : IEntityTypeConfiguration<Performer>
    {
        public void Configure(EntityTypeBuilder<Performer> entity)
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.FirstName)
                .IsUnicode()
                .HasMaxLength(PerformerNameMaxLength);

            entity.Property(p => p.LastName)
                .IsUnicode()
                .HasMaxLength(PerformerNameMaxLength);

        }
    }
}
