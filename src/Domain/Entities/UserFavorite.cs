using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class UserFavorite : BaseEntity
{
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    public int? Order { get; set; }

    // Foreign Keys
    public string UserId { get; set; } = string.Empty;
    public string MovieId { get; set; } = string.Empty;
    public string? WatchlistId { get; set; }

    // Navigation properties
    public virtual Movie Movie { get; set; } = new Movie();
    public virtual Watchlist? Watchlist { get; set; }
}
