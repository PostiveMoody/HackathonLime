using Microsoft.OData.Edm;

namespace HackathonLime.DAL
{
    public interface IConventionModelFactory
    {
        IEdmModel CreateOrGet();
    }
}
