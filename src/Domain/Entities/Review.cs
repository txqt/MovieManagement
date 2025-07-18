using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class Review : BaseAuditableEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsRecommended { get; set; } = true;
    public int HelpfulCount { get; set; } = 0;
    public bool IsEdited { get; set; } = false;
    public bool IsActive { get; set; } = true;
    public bool IsApproved { get; set; } = false;

    // Foreign Keys
    public string MovieId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;

    // Navigation properties
    public virtual Movie Movie { get; set; } = new Movie();
}
