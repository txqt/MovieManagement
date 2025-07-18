using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class Tag : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Color { get; set; }
    public bool IsActive { get; set; } = true;
    public string Type { get; set; } = "General"; // General, Anime, Movie, Character

    // Navigation properties
    public virtual ICollection<MovieTag> MovieTags { get; set; } = new List<MovieTag>();
    public virtual ICollection<CharacterTag> CharacterTags { get; set; } = new List<CharacterTag>();
}
