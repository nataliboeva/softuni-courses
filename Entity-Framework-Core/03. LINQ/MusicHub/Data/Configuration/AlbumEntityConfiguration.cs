namespace MusicHub.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static EntityValidationConstrants.Album;
    using Models;
    public class AlbumEntityConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> entity)
        {
            entity.HasKey(a => a.Id);

            entity.Property(a => a.Name)
                .IsUnicode()
                .HasMaxLength(AlbumNameMaxLength);

            entity.Property(a => a.ProducerId)
                .IsRequired(false);

            //Relations

            entity
                .HasOne(a => a.Producer)
                .WithMany(p => p.Albums)
                .HasForeignKey(a => a.ProducerId);

        }
    }
}
