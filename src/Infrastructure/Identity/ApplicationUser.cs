using MovieManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace MovieManagementSystem.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
    public string? DisplayName { get; set; }
    public string? Avatar { get; set; }
    public string? Gender { get; set; }
    public string? Country { get; set; }
    public string? PreferredLanguage { get; set; }
    public string? PreferredSubtitleLanguage { get; set; }
    public bool PreferSubtitles { get; set; } = true;
    public bool PreferDubbed { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
    public bool IsPremium { get; set; } = false;
    public DateTime? PremiumExpiryDate { get; set; }

    // Navigation properties
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    public virtual ICollection<WatchHistory> WatchHistories { get; set; } = new List<WatchHistory>();
    public virtual ICollection<Watchlist> Watchlists { get; set; } = new List<Watchlist>();
    public virtual ICollection<UserFavorite> UserFavorites { get; set; } = new List<UserFavorite>();
    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    public virtual ICollection<UserGenrePreference> UserGenrePreferences { get; set; } = new List<UserGenrePreference>();
}
