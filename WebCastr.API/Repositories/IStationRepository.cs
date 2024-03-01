using System.Linq.Expressions;
using WebCastr.Core.Models;

namespace WebCastr.API.Repositories;

public interface IStationRepository
{
    public Task<Station?> AddAsync(Station station);

    public Task<Station?> GetByIdAsync(Guid id);

    public Task<Station?> GetAsync(Expression<Func<Station, bool>> predicate);

    public Task<List<Station>> GetAllAsync();

    public Task<List<Station>> GetAllAsync(Expression<Func<Station, bool>> predicate);

    public Task<bool> DeleteAsync(Station station);
}
