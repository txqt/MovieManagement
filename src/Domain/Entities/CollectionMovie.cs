using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class CollectionMovie : BaseEntity
{
    public int Order { get; set; }
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;

    // Foreign Keys
    public string CollectionId { get; set; } = string.Empty;
    public string MovieId { get; set; } = string.Empty;

    // Navigation properties
    public virtual Collection Collection { get; set; } = new Collection();
    public virtual Movie Movie { get; set; } = new Movie();
}
