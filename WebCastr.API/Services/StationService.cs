using Slugify;
using System.Security.Cryptography.X509Certificates;
using System;
using WebCastr.Core.Models;
using WebCastr.Core.Requests;
using WebCastr.Core.Responses;
using WebCastr.API.Repositories;

namespace WebCastr.API.Services;

public class StationService(IStationRepository repository) : IStationService
{
    private readonly IStationRepository _repository = repository;

    public async Task<Station> CreateAsync(StationCreateRequest request)
    {
        Station station = MapFromCreateRequest(request);

        if (string.IsNullOrWhiteSpace(station.ShortName))
        {
            SlugHelper slugify = new SlugHelper();
            station.ShortName = slugify.GenerateSlug(station.Name);
        }

        station = await _repository.AddAsync(station);

        return station;
    }

    public async Task<Station?> GetById(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Station?> GetByShortName(string shortName)
    {
        return await _repository.GetAsync(s => s.ShortName == shortName);
    }

    public async Task<List<Station>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        Station? station = await _repository.GetByIdAsync(id);

        if (station == null)
            return false;

        await _repository.DeleteAsync(station);

        return true;
    }

    public Station MapFromCreateRequest(StationCreateRequest request)
    {
        Station station = new Station()
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Name = request.Name,
            ShortName = request.ShortName,
            Description = request.Description,
            TimeZone = request.TimeZone,
            Enabled = false
        };

        return station;
    }

    public StationResponse MapToResponse(Station station)
    {
        StationResponse response = new StationResponse()
        {
            Id = station.Id,
            CreatedAt = station.CreatedAt,
            UpdatedAt = station.UpdatedAt,
            Name = station.Name,
            Description = station.Description,
            ShortName = station.ShortName,
            Enabled = station.Enabled,
            TimeZone = station.TimeZone
        };

        return response;
    }
}
