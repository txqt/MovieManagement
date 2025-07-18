using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class CharacterVoiceActor : BaseEntity
{
    public string CharacterId { get; set; } = string.Empty;
    public string ActorId { get; set; } = string.Empty;
    public string Language { get; set; } = "Japanese"; // Japanese, English, etc.
    public string? Role { get; set; } // Main, Supporting

    // Navigation properties
    public virtual Character Character { get; set; } = new Character();
    public virtual Actor Actor { get; set; } = new Actor();
}
