using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class Character : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? JapaneseName { get; set; }
    public string? RomajiName { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? Gender { get; set; }
    public DateTime? Birthday { get; set; }
    public string? BloodType { get; set; }
    public int? Age { get; set; }
    public string? Height { get; set; }
    public string? Weight { get; set; }
    public string? Occupation { get; set; }
    public string? CharacterType { get; set; } // Main, Supporting, Background
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public virtual ICollection<MovieCharacter> MovieCharacters { get; set; } = new List<MovieCharacter>();
    public virtual ICollection<CharacterTag> CharacterTags { get; set; } = new List<CharacterTag>();
    public virtual ICollection<CharacterVoiceActor> CharacterVoiceActors { get; set; } = new List<CharacterVoiceActor>();
}
