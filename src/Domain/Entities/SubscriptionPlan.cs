using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class SubscriptionPlan : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; } = "USD";
    public int DurationInDays { get; set; }
    public int? MaxDevices { get; set; }
    public bool CanDownload { get; set; } = false;
    public bool CanWatch4K { get; set; } = false;
    public bool HasAds { get; set; } = true;
    public bool CanAccessAdultContent { get; set; } = false; // For 18+ anime
    public bool CanAccessSimulcast { get; set; } = false; // For latest anime episodes
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
