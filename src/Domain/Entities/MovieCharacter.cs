using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class MovieCharacter : BaseEntity
{
    public string MovieId { get; set; } = string.Empty;
    public string CharacterId { get; set; } = string.Empty;
    public string? Role { get; set; } // Main, Supporting, Background
    public int? Order { get; set; }

    // Navigation properties
    public virtual Movie Movie { get; set; } = new Movie();
    public virtual Character Character { get; set; } = new Character();
}
