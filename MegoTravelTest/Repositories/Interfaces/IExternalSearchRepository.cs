using MegoTravelTest.Models.Entities;
using MegoTravelTest.Repositories.Base;

namespace MegoTravelTest.Repositories.Interfaces;

public interface IExternalSearchRepository : IBaseRepository<ExternalSearch>
{
    IEnumerable<ExternalSearch> GetByDates(DateTime startDate, DateTime endDate);
}