using System;
using System.Collections.Generic;

namespace SmartCertify.Domain.Entities;

public partial class BannerInfo
{
    public int BannerId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public bool IsActive { get; set; }

    public DateTime DisplayFrom { get; set; }

    public DateTime DisplayTo { get; set; }

    public DateTime CreatedOn { get; set; }
}
