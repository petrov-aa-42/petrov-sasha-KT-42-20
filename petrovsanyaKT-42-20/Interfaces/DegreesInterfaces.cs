using petrovsanyaKT_42_20.Database;
using petrovsanyaKT_42_20.Models;
using petrovsanyaKT_42_20.Filters.PrepodDegreeFilters;
using Microsoft.EntityFrameworkCore;


namespace petrovsanyaKT_42_20.Interfaces
{
    public interface IDegreesService
    {
        public Task<Prepod[]> GetPrepodsByDegreeAsync(PrepodDegreeFilter filter, CancellationToken cancellationToken);
    }

    public class DegreeService : IDegreesService
    {
        private readonly PrepodDbContext _dbContext;
        public DegreeService(PrepodDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Prepod[]> GetPrepodsByDegreeAsync(PrepodDegreeFilter filter, CancellationToken cancellationToken = default)
        {
            var degrees = _dbContext.Set<Prepod>().Where(w => w.Degree.DegreeName == filter.DegreeName).ToArrayAsync(cancellationToken);

            return degrees;
        }
    }
}
