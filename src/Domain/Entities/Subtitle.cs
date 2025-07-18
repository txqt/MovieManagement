using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class Subtitle : BaseAuditableEntity
{
    public string Language { get; set; } = string.Empty;
    public string LanguageCode { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string Format { get; set; } = string.Empty; // srt, vtt, ass
    public bool IsDefault { get; set; } = false;
    public bool IsForced { get; set; } = false; // For signs/songs
    public string? SubtitleType { get; set; } // Full, Signs, Songs, Commentary
    public string? TranslatorGroup { get; set; } // Fansub groups
    public bool IsActive { get; set; } = true;

    // Foreign Keys
    public string? MovieId { get; set; }
    public string? EpisodeId { get; set; }

    // Navigation properties
    public virtual Movie? Movie { get; set; }
    public virtual Episode? Episode { get; set; }
}
