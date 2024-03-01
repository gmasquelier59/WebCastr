﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCastr.Core.Models;

// ===================================================
// Don't forget to update related Requests & Responses
// ===================================================

[Table(name: "mount_point")]
public class MountPoint
{
    /// <summary>
    /// Identifier of the mount point
    /// </summary>
    [Required, Column(name: "guid")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, Column(name: "created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column(name: "updated_at")]
    public DateTime? UpdatedAt { get; set; } = null;

    [Required]
    public Station Station { get; set; }
}
