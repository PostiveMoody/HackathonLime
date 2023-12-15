using Newtonsoft.Json;

namespace HackathonLime.DTO
{
    public class FilmDto: FilmCreationOptionsDto
    {
        [JsonProperty("filmId")]
        public int FilmId { get; set; }
    }
}
