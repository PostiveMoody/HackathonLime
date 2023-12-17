using Community.OData.Linq;
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
        private readonly IConventionModelFactory _modelFactory;

        public FilmController(HackathonLimeDbContext dbContext, IConventionModelFactory modelFactory)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _modelFactory = modelFactory ?? throw new ArgumentNullException(nameof(modelFactory));
        }

        /// <summary>
        /// Создать фильм
        /// </summary>
        /// <param name="creationOptions"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        public ApiResult<FilmDto> Post([FromBody]FilmCreationOptionsDto creationOptions)
        {
            if(creationOptions == null)
                throw new ArgumentNullException(nameof(creationOptions));

            var film = FilmModel.Create(creationOptions);

            _dbContext.Add(film);
            _dbContext.SaveChanges();

            return film
                .ToDto()
                .ToApiResult();
        }

        [HttpGet]
        [Route("")]
        public ApiResult<PageDto<FilmDto>> Get(string filter
            , string top
            , string skip
            , string orderby)
        {
            var qData = _dbContext.Films.Select(it => new FilmDto()
            {
                FilmId = it.FilmId,
                Title = it.Title,
                Description = it.Description,
                ReleasedAt = it.ReleasedAt,
                LanguageId = it.LanguageId,
                RentalDuration = it.RentalDuration,
                RentalRate = it.RentalRate,
                FilmRaiting = it.FilmRaiting,
            }).OData(edmModel: _modelFactory.CreateOrGet());

            if (!string.IsNullOrEmpty(filter))
            {
                qData = qData.Filter(filter);
            }

            var totalCount = qData.Count();

            if (!string.IsNullOrEmpty(orderby))
            {
                qData = qData.OrderBy(orderby);
            }

            if (!string.IsNullOrEmpty(top) && !string.IsNullOrEmpty(skip))
            {
                qData = qData.TopSkip(top, skip);
            }

            var result = qData.ToArray();

            return new PageDto<FilmDto>()
            {
                Items = result,
                TotalCount = totalCount,
            }.ToApiResult();       
        }
    }
}
