using AutoMapper;
using HackathonLime.DAL;
using HackathonLime.Domain.OnlineCinema;
using HackathonLime.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HackathonLime.Application.Controllers
{
    [Route("[controller]")]
    public class FilmController : Controller
    {
        private readonly HackathonLimeDbContext _dbContext;
        private readonly IMapper _mapper;
        public FilmController(HackathonLimeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public ApiResult<FilmDto> Post(FilmCreationOptionsDto creationOptions)
        {
            if(creationOptions == null)
                throw new ArgumentNullException(nameof(creationOptions));

            var film = FilmModel.Create(creationOptions);

            _dbContext.Add(film);
            _dbContext.SaveChangesAsync();

            return film
                .ToDto()
                .ToApiResult();
        }
    }
}
