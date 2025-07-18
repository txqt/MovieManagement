using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class VideoFile : BaseEntity
{
    public string FilePath { get; set; } = string.Empty;
    public string Quality { get; set; } = string.Empty; // 480p, 720p, 1080p, 4K
    public long FileSize { get; set; }
    public string Format { get; set; } = string.Empty; // mp4, mkv, avi
    public int? Bitrate { get; set; }
    public string? AudioCodec { get; set; }
    public string? VideoCodec { get; set; }
    public string? Resolution { get; set; }
    public double? FrameRate { get; set; }
    public string? AudioType { get; set; } // Sub, Dub
    public string? AudioLanguage { get; set; } // Japanese, English, etc.
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;

    // Foreign Keys
    public string? MovieId { get; set; }
    public string? EpisodeId { get; set; }

    // Navigation properties
    public virtual Movie? Movie { get; set; }
    public virtual Episode? Episode { get; set; }
}
