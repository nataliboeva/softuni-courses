namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        public int SongId { get; set; }
        public Song Song { get; set; } = null!;
        public int PerformerId { get; set; }
        public virtual Performer Performer { get; set; } = null!;

    }
}
