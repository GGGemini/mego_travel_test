using MegoTravelTest.Models.Entities;
using MegoTravelTest.Repositories.Base.AppDbContext;
using MegoTravelTest.Repositories.Base;
using MegoTravelTest.Repositories.Interfaces;

namespace MegoTravelTest.Repositories;

public class ExternalSearchRepository : BaseRepository<ExternalSearch>, IExternalSearchRepository
{
    public ExternalSearchRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    public IEnumerable<ExternalSearch> GetByDates(DateTime startDate, DateTime endDate)
    {
        return base.Find(x => startDate <= x.CreateDate && x.CreateDate < endDate.AddDays(1));
    }
}