using System;
using System.Collections.Generic;

namespace SmartCertify.Domain.Entities;

public partial class ContactU
{
    public int ContactUsId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string MessageDetail { get; set; } = null!;
}
