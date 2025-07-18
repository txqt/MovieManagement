using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class MovieActor : BaseEntity
{
    public string MovieId { get; set; } = string.Empty;
    public string ActorId { get; set; } = string.Empty;
    public string? CharacterName { get; set; }
    public string? Role { get; set; } // Lead, Supporting, Cameo, Voice Actor
    public int? Order { get; set; }
    public string? VoiceType { get; set; } // Sub, Dub (for voice actors)

    // Navigation properties
    public virtual Movie Movie { get; set; } = new Movie();
    public virtual Actor Actor { get; set; } = new Actor();
}
