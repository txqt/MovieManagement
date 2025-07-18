using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class Movie : BaseAuditableEntity
{
    public string Title { get; set; } = string.Empty;
    public string? OriginalTitle { get; set; }
    public string? JapaneseTitle { get; set; } // For anime
    public string? RomajiTitle { get; set; } // For anime
    public string? Description { get; set; }
    public string? Plot { get; set; }
    public string? PosterUrl { get; set; }
    public string? BackdropUrl { get; set; }
    public string? TrailerUrl { get; set; }
    public int? Duration { get; set; } // in minutes
    public DateTime? ReleaseDate { get; set; }
    public DateTime? AirDate { get; set; } // For anime series
    public string? Country { get; set; }
    public string? Language { get; set; }
    public string? Director { get; set; }
    public string? Producer { get; set; }
    public string? Studio { get; set; }
    public string? Distributor { get; set; }
    public string? AnimeStudio { get; set; } // Animation studio for anime
    public string? OriginalSource { get; set; } // Manga, Light Novel, Original, etc.
    public decimal? Budget { get; set; }
    public decimal? Revenue { get; set; }
    public string? AgeRating { get; set; } // G, PG, PG-13, R, NC-17
    public string? AnimeRating { get; set; } // G, PG, PG-13, R, R+, Rx (anime specific)
    public double? ImdbRating { get; set; }
    public double? TmdbRating { get; set; }
    public double? MalScore { get; set; } // MyAnimeList score
    public double? AniListScore { get; set; } // AniList score
    public double AverageRating { get; set; } = 0;
    public int RatingCount { get; set; } = 0;
    public long ViewCount { get; set; } = 0;
    public bool IsActive { get; set; } = true;
    public bool IsPublic { get; set; } = true;
    public bool IsFeatured { get; set; } = false;
    public bool IsComingSoon { get; set; } = false;
    public string Status { get; set; } = "Released"; // Released, Airing, Completed, Cancelled
    public string ContentType { get; set; } = "Movie"; // Movie, Series, Documentary, Anime, Cartoon
    public string? AnimeType { get; set; } // TV, Movie, OVA, ONA, Special, Music Video
    public int? TotalEpisodes { get; set; } // For anime series
    public int? CurrentEpisode { get; set; } // For ongoing anime
    public string? AiringStatus { get; set; } // Airing, Completed, Upcoming, Cancelled
    public string? AiringSeason { get; set; } // Winter, Spring, Summer, Fall
    public int? AiringYear { get; set; }
    public string? AiringDay { get; set; } // Monday, Tuesday, etc.
    public TimeSpan? AiringTime { get; set; } // Airing time
    public bool HasDub { get; set; } = false; // Has dubbed version
    public bool HasSub { get; set; } = true; // Has subtitles
    public bool IsAdultContent { get; set; } = false; // 18+ content

    // Foreign Keys
    public string? CategoryId { get; set; }

    // Navigation properties
    public virtual Category? Category { get; set; }
    public virtual ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    public virtual ICollection<MovieCharacter> MovieCharacters { get; set; } = new List<MovieCharacter>();
    public virtual ICollection<Episode> Episodes { get; set; } = new List<Episode>();
    public virtual ICollection<Season> Seasons { get; set; } = new List<Season>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    public virtual ICollection<WatchHistory> WatchHistories { get; set; } = new List<WatchHistory>();
    public virtual ICollection<UserFavorite> UserFavorites { get; set; } = new List<UserFavorite>();
    public virtual ICollection<VideoFile> VideoFiles { get; set; } = new List<VideoFile>();
    public virtual ICollection<Subtitle> Subtitles { get; set; } = new List<Subtitle>();
    public virtual ICollection<MovieTag> MovieTags { get; set; } = new List<MovieTag>();
    public virtual ICollection<RelatedMovie> RelatedMoviesAsSource { get; set; } = new List<RelatedMovie>();
    public virtual ICollection<RelatedMovie> RelatedMoviesAsRelated { get; set; } = new List<RelatedMovie>();
}
