
namespace MusicHub.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static EntityValidationConstrants.Song;
    using Models;

    public class SongEntityConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> entity)
        {
            entity.HasKey(s => s.Id);

            entity.Property(s => s.Name)
                .IsUnicode()
                .HasMaxLength(SongNameMaxLength);

            entity.Property(s => s.AlbumId)
                .IsRequired(false);

            //Relations
            entity.HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumId);

            entity.HasOne(s => s.Writer)
                .WithMany(w => w.Songs)
                .HasForeignKey(s => s.WriterId);

        }
    }
}
