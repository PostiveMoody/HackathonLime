using Newtonsoft.Json;

namespace HackathonLime.DTO
{
    public class FilmCreationOptionsDto
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("releasedAt")]
        public DateTimeOffset ReleasedAt { get; set; }
        [JsonProperty("languageId")]
        public int LanguageId { get; set; }
        [JsonProperty("rentalDuration")]
        public int RentalDuration { get; set; }
        [JsonProperty("rentalRate")]
        public double RentalRate { get; set; }
        [JsonProperty("filmRaiting")]
        public double FilmRaiting { get; set; }
    }
}
