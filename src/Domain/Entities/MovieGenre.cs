using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class MovieGenre : BaseEntity
{
    public string MovieId { get; set; } = string.Empty;
    public string GenreId { get; set; } = string.Empty;

    // Navigation properties
    public virtual Movie Movie { get; set; } = new Movie();
    public virtual Genre Genre { get; set; } = new Genre();
}
