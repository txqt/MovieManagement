using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class MovieTag : BaseEntity
{
    public string MovieId { get; set; } = string.Empty;
    public string TagId { get; set; } = string.Empty;

    // Navigation properties
    public virtual Movie Movie { get; set; } = new Movie();
    public virtual Tag Tag { get; set; } = new Tag();
}
