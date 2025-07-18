using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class Watchlist : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsPublic { get; set; } = false;
    public bool IsDefault { get; set; } = false;

    // Foreign Keys
    public string UserId { get; set; } = string.Empty;

    // Navigation properties
    public virtual ICollection<UserFavorite> UserFavorites { get; set; } = new List<UserFavorite>();
}
