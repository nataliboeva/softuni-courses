namespace MusicHub.Data
{
    public static class EntityValidationConstrants
    {
        public static class Song
        {
            public const int SongNameMaxLength = 20;
        }

        public static class Album
        {
            public const int AlbumNameMaxLength = 20;
        }
        public static class Performer
        {
            public const int PerformerNameMaxLength = 20;
        }

        public static class Producer
        {
            public const int ProducerNameMaxLength = 30;
        }

        public static class Writer
        {
            public const int WriterNameMaxLength = 20;
        }
    }
}
