using System;
using System.Collections.Generic;

namespace Cash.BE.Models;

public partial class Contract
{
    public int Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int ServiceId { get; set; }

    public int StatusId { get; set; }

    public int ClientId { get; set; }

    public int MethodPaymentId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual MethodPayment MethodPayment { get; set; } = null!;

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual Service Service { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
