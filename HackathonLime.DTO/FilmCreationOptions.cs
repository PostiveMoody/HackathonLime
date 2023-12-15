namespace HackathonLime.DTO
{
    public class FilmCreationOptions
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset ReleasedAt { get; set; }
        public int LanguageId { get; set; }
        public int RentalDuration { get; set; }
        public double RentalRate { get; set; }
        public double FilmRaiting { get; set; }
    }
}
