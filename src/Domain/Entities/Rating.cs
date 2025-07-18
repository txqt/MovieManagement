using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class Rating : BaseAuditableEntity
{
    public int Score { get; set; } // 1-10 or 1-5

    // Foreign Keys
    public string MovieId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;

    // Navigation properties
    public virtual Movie Movie { get; set; } = new Movie();
}
