using Community.OData.Linq;
using HackathonLime.DTO;
using Microsoft.OData.Edm;

namespace HackathonLime.DAL
{
    public class EdmModelFactory : IConventionModelFactory
    {
        private readonly object _lockObject = new object();
        private IEdmModel _model;

        public IEdmModel CreateOrGet()
        {
            if (_model != null)
                return _model;

            lock (_lockObject)
            {
                if (_model != null)
                    return _model;

                var builder = new ODataConventionModelBuilder();

                {
                    var entityType = builder.EntityType<FilmDto>();
                    entityType.HasKey(x => x.FilmId);
                    entityType.Property(x => x.Title);
                    entityType.Property(x => x.ReleasedAt);
                    entityType.Property(x => x.RentalRate);
                    entityType.Property(x => x.FilmRaiting);
                    
                    builder.EntitySet<FilmDto>(nameof(FilmDto));
                }

                
                _model = builder.GetEdmModel();
                return _model;
            }
        }
    }
}
