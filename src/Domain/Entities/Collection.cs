using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class Collection : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string Type { get; set; } = string.Empty; // Featured, New, Popular, Trending, Seasonal, Studio
    public int SortOrder { get; set; } = 0;
    public bool IsActive { get; set; } = true;
    public string? ContentType { get; set; } // Movie, Anime, Both

    // Navigation properties
    public virtual ICollection<CollectionMovie> CollectionMovies { get; set; } = new List<CollectionMovie>();
}
