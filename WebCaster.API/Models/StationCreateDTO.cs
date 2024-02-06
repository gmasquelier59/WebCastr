﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebCaster.API.Services.Liquidsoap.Enums;

namespace WebCaster.API.Models;

public class StationCreateDTO
{
    public string Name { get; set; } = "";
    public string ShortName { get; set; } = "";
    public string? Description { get; set; }
    public bool Enabled { get; set; } = false;
    public string TimeZone { get; set; } = "UTC";
    public AudioProcessingMethods AudioProcessingMethod { get; set; }
}
