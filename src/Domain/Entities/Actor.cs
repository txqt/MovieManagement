using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class Actor : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? JapaneseName { get; set; }
    public string? RomajiName { get; set; }
    public string? Biography { get; set; }
    public string? ProfileImageUrl { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
    public string? PlaceOfBirth { get; set; }
    public string? Nationality { get; set; }
    public string? Gender { get; set; }
    public double? Height { get; set; }
    public bool IsActive { get; set; } = true;
    public string Type { get; set; } = "Actor"; // Actor, Voice Actor, Both

    // Navigation properties
    public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    public virtual ICollection<CharacterVoiceActor> CharacterVoiceActors { get; set; } = new List<CharacterVoiceActor>();
}
