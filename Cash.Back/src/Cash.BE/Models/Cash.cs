using System;
using System.Collections.Generic;

namespace Cash.BE.Models;

public partial class Cash
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int StatusId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<Turn> Turns { get; set; } = new List<Turn>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
