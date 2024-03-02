using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using WebCastr.Core.Requests;
using WebCastr.Core.Models;
using WebCastr.Core.Responses;
using WebCastr.API.Services;

namespace WebCastr.API.Controllers
{
    [ApiController]
    [Tags("Stations")]
    public class StationController(IStationService stationService) : ControllerBase
    {
        private readonly IStationService _stationService = stationService;

        /// <summary>
        /// Create a new radio station
        /// </summary>
        [HttpPost("/station")]
        public async Task<ActionResult<StationResponse>> CreateAsync([FromBody] StationCreateRequest request)
        {
            Station? station;

            try
            {
                station = await _stationService.CreateAsync(request);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

            if (station == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetByIdAsync), new { id = station.Id }, _stationService.MapToResponse(station));
        }

        /// <summary>
        /// Returns a list of stations
        /// </summary>
        [HttpGet("/stations")]
        public async Task<ActionResult<List<StationResponse>>> GetAllAsync()
        {
            List<Station> stations = await _stationService.GetAllAsync();
            List<StationResponse> stationsResponses = new List<StationResponse>();
            
            foreach(Station station in stations)
                stationsResponses.Add(_stationService.MapToResponse(station));

            return Ok(stationsResponses);
        }

        /// <summary>
        /// Returns informations about a station by its id
        /// </summary>
        [HttpGet("/station/{id:guid}")]
        public async Task<ActionResult<StationResponse>> GetByIdAsync(Guid id)
        {
            Station? station = await _stationService.GetById(id);

            return station == null ? NotFound() : Ok(_stationService.MapToResponse(station));
        }

        /// <summary>
        /// Returns informations about a station by its short name
        /// </summary>
        [HttpGet("/station/{shortName}")]
        public async Task<ActionResult<StationResponse>> GetByShortNameAsync(string shortName)
        {
            Station? station = await _stationService.GetByShortName(shortName);

            return station == null ? NotFound() : Ok(_stationService.MapToResponse(station));
        }

        /// <summary>
        /// Returns the current track of a station by its short name
        /// </summary>
        [HttpGet("/station/{shortName}/now-playing")]
        public async Task<ActionResult> GetNowPlayingByShortNameAsync(string shortName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the current track of a station by its short name
        /// </summary>
        [HttpGet("/station/{id:guid}/now-playing")]
        public async Task<ActionResult> GetNowPlayingByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Update informations about a station
        /// </summary>
        [HttpPut("/station/{id:guid}")]
        public async Task<ActionResult<StationResponse>> UpdateById(Guid id, [FromBody] StationUpdateRequest station)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permanently delete a station
        /// </summary>
        [HttpDelete("/station/{id:guid}")]
        public async Task<ActionResult> DeleteByIdAsync(Guid id)
        {
            bool deleted = await _stationService.DeleteByIdAsync(id);

            return deleted ? Ok() : NotFound();
        }

        /// <summary>
        /// [NIY] Start a station
        /// </summary>
        [HttpPost("/station/{id:guid}/start")]
        public async Task<ActionResult> StartAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Stop a station
        /// </summary>
        [HttpPost("/station/{id:guid}/stop")]
        public async Task<ActionResult> StopAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Restart a station
        /// </summary>
        [HttpPost("/station/{id:guid}/restart")]
        public async Task<ActionResult> RestartAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
