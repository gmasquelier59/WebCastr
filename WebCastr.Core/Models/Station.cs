using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCastr.Core.Models;

// ===================================================
// Don't forget to update related Requests & Responses
// ===================================================

[Table(name: "station"), Index(nameof(ShortName), IsUnique = true)]
public class Station
{
    /// <summary>
    /// Identifier of the station
    /// </summary>
    [Required, Column(name: "guid")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, Column(name: "created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column(name: "updated_at")]
    public DateTime? UpdatedAt { get; set; } = null;

    /// <summary>
    /// Display name of the station
    /// </summary>
    [MaxLength(100), Required, Column(name: "name")]
    public string Name { get; set; } = "";

    /// <summary>
    /// Short name of the station (URL-friendly)
    /// </summary>
    [MaxLength(100), Required, Column(name: "short_name")]
    public string ShortName { get; set; } = "";

    /// <summary>
    /// Description of the station
    /// </summary>
    [MaxLength(250), Column(name: "description")]
    public string? Description { get; set; }

    [Column(name: "enabled")]
    public bool Enabled { get; set; } = true;

    /// <summary>
    /// Time zone of the station (default is UTC)
    /// </summary>
    [MaxLength(100), Required, Column(name: "timezone")]
    public string TimeZone { get; set; } = "UTC";
}
