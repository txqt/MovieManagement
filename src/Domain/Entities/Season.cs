using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class Season : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int SeasonNumber { get; set; }
    public string? Description { get; set; }
    public string? PosterUrl { get; set; }
    public DateTime? AirDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? TotalEpisodes { get; set; }
    public int? PlannedEpisodes { get; set; }
    public string? Status { get; set; } // Airing, Completed, Upcoming, Cancelled
    public string? AiringSeason { get; set; } // Winter, Spring, Summer, Fall
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;

    // Foreign Keys
    public string MovieId { get; set; } = string.Empty;

    // Navigation properties
    public virtual Movie Movie { get; set; } = new Movie();
    public virtual ICollection<Episode> Episodes { get; set; } = new List<Episode>();
}
