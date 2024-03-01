using System.ComponentModel.DataAnnotations;

namespace WebCastr.Core.Requests;

public class StationCreateRequest
{
    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(100), RegularExpression(@"^[a-z0-9\-_]+$")]
    public string ShortName { get; set; } = "";

    [MaxLength(250)]
    public string Description { get; set; } = "";

    [MaxLength(100)]
    public string TimeZone { get; set; } = "UTC";

}
