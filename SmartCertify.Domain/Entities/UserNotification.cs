using System;
using System.Collections.Generic;

namespace SmartCertify.Domain.Entities;

public partial class UserNotification
{
    public int UserNotificationId { get; set; }

    public int NotificationId { get; set; }

    public int UserId { get; set; }

    public string EmailSubject { get; set; } = null!;

    public string EmailContent { get; set; } = null!;

    public bool NotificationSent { get; set; }

    public DateTime? SentOn { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual Notification Notification { get; set; } = null!;

    public virtual UserProfile User { get; set; } = null!;
}
