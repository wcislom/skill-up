namespace Forecaster.Core.Entities.VideoGames
{
    internal class VideoGameDetails
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int VideoGameId { get; set; }
    }
}
