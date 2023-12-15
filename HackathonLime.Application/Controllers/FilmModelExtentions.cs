using HackathonLime.Domain.OnlineCinema;
using HackathonLime.DTO;

namespace HackathonLime.Application.Controllers
{
    public static class FilmModelExtentions
    {
        public static FilmDto ToDto(this FilmModel filmModel)
        {
            return new FilmDto()
            {
                FilmId = filmModel.FilmId,
                Title = filmModel.Title,
                Description = filmModel.Description,
                ReleasedAt = filmModel.ReleasedAt,
                LanguageId = filmModel.LanguageId,
                RentalDuration = filmModel.RentalDuration,
                RentalRate = filmModel.RentalRate,
                FilmRaiting = filmModel.FilmRaiting,
            };
        }
    }
}
