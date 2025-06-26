using System;
using System.Collections.Generic;

namespace Cash.BE.Models;

public partial class Attention
{
    public int Id { get; set; }

    public int TurnId { get; set; }

    public int ClientId { get; set; }

    public int TypeId { get; set; }

    public int StatusId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual Status Status { get; set; } = null!;

    public virtual Turn Turn { get; set; } = null!;

    public virtual AttentionType Type { get; set; } = null!;
}
