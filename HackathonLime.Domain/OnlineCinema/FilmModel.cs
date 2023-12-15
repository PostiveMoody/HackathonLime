using HackathonLime.Domain.Exceptions;
using HackathonLime.DTO;

namespace HackathonLime.Domain.OnlineCinema
{
    public class FilmModel
    {
        public int FilmId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTimeOffset ReleasedAt { get; private set; }

        /// <summary>
        ///          just for EF mapping
        /// </summary>
        public int LanguageId { get; private set; }
        public int RentalDuration { get; private set; }
        public double RentalRate { get; private set;}
        public double FilmRaiting { get; private set; }

        public static FilmModel Create(FilmCreationOptionsDto options)
        { 
            if(string.IsNullOrWhiteSpace(options.Title))
                throw new DomainException(nameof(options.Title));
            if (string.IsNullOrWhiteSpace(options.Description))
                throw new DomainException(nameof(options.Description));
            if (options.ReleasedAt == default)
                throw new DomainException(nameof(options.ReleasedAt) + "is not set");


            return new FilmModel
            {
               Title = options.Title,
               Description = options.Description,
               ReleasedAt = options.ReleasedAt,
               LanguageId = options.LanguageId,
               RentalDuration = options.RentalDuration,
               RentalRate = options.RentalRate,
               FilmRaiting = options.FilmRaiting,
            };
        }
    }
}
