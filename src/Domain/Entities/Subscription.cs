using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class Subscription : BaseEntity
{
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime EndDate { get; set; }
    public decimal AmountPaid { get; set; }
    public string Currency { get; set; } = "USD";
    public string Status { get; set; } = "Active";
    public string? PaymentMethod { get; set; }
    public string? TransactionId { get; set; }
    public bool IsAutoRenew { get; set; } = true;

    // Foreign Keys
    public string UserId { get; set; } = string.Empty;
    public string SubscriptionPlanId { get; set; } = string.Empty;

    // Navigation properties
    public virtual SubscriptionPlan SubscriptionPlan { get; set; } = new SubscriptionPlan();
}
