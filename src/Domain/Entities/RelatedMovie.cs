using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class RelatedMovie: BaseEntity
{
    public string SourceMovieId { get; set; } = string.Empty;
    public string RelatedMovieId { get; set; } = string.Empty;
    public string RelationType { get; set; } = string.Empty; // Sequel, Prequel, Spin-off, Side Story, Alternative Version, etc.
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual Movie SourceMovie { get; set; } = new Movie();
    public virtual Movie RelatedMovieNavigation { get; set; } = new Movie();
}
