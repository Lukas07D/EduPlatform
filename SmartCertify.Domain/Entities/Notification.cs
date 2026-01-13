using System;
using System.Collections.Generic;
namespace SmartCertify.Domain.Entities;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string Subject { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime ScheduledSendTime { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<UserNotification> UserNotifications { get; set; } = new List<UserNotification>();
}
