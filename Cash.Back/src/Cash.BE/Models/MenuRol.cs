using System;
using System.Collections.Generic;

namespace Cash.BE.Models;

public partial class MenuRol
{
    public int MenuId { get; set; }

    public int RolId { get; set; }

    public int StatusId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual Menu Menu { get; set; } = null!;

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual Rol Rol { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
