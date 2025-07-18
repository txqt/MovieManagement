using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class WatchHistory : BaseEntity
{
    public DateTime WatchedAt { get; set; } = DateTime.UtcNow;
    public int WatchDuration { get; set; }
    public int? CurrentPosition { get; set; }
    public bool IsCompleted { get; set; } = false;
    public string? DeviceType { get; set; }
    public string? UserAgent { get; set; }
    public string? IpAddress { get; set; }
    public string? AudioType { get; set; } // Sub, Dub
    public string? SubtitleLanguage { get; set; }
    public string? Quality { get; set; } // 480p, 720p, etc.

    // Foreign Keys
    public string UserId { get; set; } = string.Empty;
    public string MovieId { get; set; } = string.Empty;
    public string EpisodeId { get; set; } = string.Empty;

    // Navigation properties
    public virtual Movie? Movie { get; set; }
    public virtual Episode? Episode { get; set; }
}
