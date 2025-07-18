using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class Genre : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Color { get; set; }
    public bool IsActive { get; set; } = true;
    public string Type { get; set; } = "General"; // General, Movie, Anime, Cartoon
    public bool IsAdultGenre { get; set; } = false; // For 18+ genres

    // Navigation properties
    public virtual ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    public virtual ICollection<UserGenrePreference> UserGenrePreferences { get; set; } = new List<UserGenrePreference>();
}
