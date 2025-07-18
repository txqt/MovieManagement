using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class Episode : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? JapaneseTitle { get; set; }
    public string? Description { get; set; }
    public int EpisodeNumber { get; set; }
    public int? Duration { get; set; }
    public DateTime? AirDate { get; set; }
    public string? ThumbnailUrl { get; set; }
    public long ViewCount { get; set; } = 0;
    public double AverageRating { get; set; } = 0;
    public int RatingCount { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
    public bool IsFillerEpisode { get; set; } = false; // Common for anime
    public bool IsRecapEpisode { get; set; } = false;
    public bool IsSpecialEpisode { get; set; } = false;
    public string? EpisodeType { get; set; } // Regular, Filler, Recap, Special, OVA

    // Foreign Keys
    public string MovieId { get; set; } = string.Empty;
    public string? SeasonId { get; set; }

    // Navigation properties
    public virtual Movie Movie { get; set; } = new Movie();
    public virtual Season? Season { get; set; }
    public virtual ICollection<VideoFile> VideoFiles { get; set; } = new List<VideoFile>();
    public virtual ICollection<Subtitle> Subtitles { get; set; } = new List<Subtitle>();
    public virtual ICollection<WatchHistory> WatchHistories { get; set; } = new List<WatchHistory>();
}
