using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using WebCastr.API.Data;
using WebCastr.Core.Models;

namespace WebCastr.API.Repositories;

public class StationRepository : IStationRepository
{
    private readonly AppDbContext _db;
    private readonly DbSet<Station> _stations;

    public StationRepository(AppDbContext db)
    {
        _db = db;
        _stations = _db.Set<Station>();
    }

    public async Task<Station?> AddAsync(Station station)
    {
        EntityEntry<Station> newEntry = await _stations.AddAsync(station);

        if (await _db.SaveChangesAsync() > 0)
            return newEntry.Entity;

        return null;
    }

    public async Task<Station?> GetByIdAsync(Guid id)
    {
        return await _stations.FirstOrDefaultAsync<Station>(s => s.Id == id);
    }

    public async Task<Station?> GetAsync(Expression<Func<Station, bool>> predicate)
    {
        return await _stations.FirstOrDefaultAsync<Station>(predicate);
    }

    public async Task<List<Station>> GetAllAsync()
    {
        return await _stations.ToListAsync<Station>();
    }

    public async Task<bool> DeleteAsync(Station station)
    {
        Station? stationToDelete = await _stations.FirstOrDefaultAsync<Station>(s => s.Id == station.Id);

        if (stationToDelete == null)
            return false;

        _stations.Remove(stationToDelete);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<List<Station>> GetAllAsync(Expression<Func<Station, bool>> predicate)
    {
        return await _stations.Where(predicate).ToListAsync<Station>();
    }
}
