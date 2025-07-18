using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class UserGenrePreference : BaseEntity
{
    public int Score { get; set; } // 1-10, how much user likes this genre
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Foreign Keys
    public string UserId { get; set; } = string.Empty;
    public string GenreId { get; set; } = string.Empty;

    // Navigation properties
    public virtual Genre Genre { get; set; } = new Genre();
}
