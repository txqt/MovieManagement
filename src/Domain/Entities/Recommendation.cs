using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class Recommendation : BaseEntity
{
    public string Type { get; set; } = string.Empty; // Trending, Popular, Recommended, New, Seasonal
    public int Score { get; set; }
    public string? Reason { get; set; } // Why this is recommended
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ExpiresAt { get; set; }
    public bool IsActive { get; set; } = true;

    // Foreign Keys
    public string? UserId { get; set; }
    public string MovieId { get; set; } = string.Empty;

    // Navigation properties
    public virtual Movie Movie { get; set; } = new Movie();
}
