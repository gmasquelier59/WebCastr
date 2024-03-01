using WebCastr.Core.Models;
using WebCastr.Core.Requests;
using WebCastr.Core.Responses;

namespace WebCastr.API.Services;

public interface IStationService
{
    public Task<Station> CreateAsync(StationCreateRequest request);

    public Task<Station> GetById(Guid id);

    public Task<Station> GetByShortName(string shortName);

    public Task<List<Station>> GetAllAsync();

    public Task<bool> DeleteByIdAsync(Guid id);

    public Station MapFromCreateRequest(StationCreateRequest request);

    public StationResponse MapToResponse(Station station);
}
