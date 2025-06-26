using System;
using System.Collections.Generic;

namespace Cash.BE.Models;

public partial class Status
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<AttentionType> AttentionTypes { get; set; } = new List<AttentionType>();

    public virtual ICollection<Attention> Attentions { get; set; } = new List<Attention>();

    public virtual ICollection<Cash> Cashes { get; set; } = new List<Cash>();

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();

    public virtual ICollection<MenuRol> MenuRols { get; set; } = new List<MenuRol>();

    public virtual ICollection<MenuUser> MenuUsers { get; set; } = new List<MenuUser>();

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    public virtual ICollection<MethodPayment> MethodPayments { get; set; } = new List<MethodPayment>();

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Rol> Rols { get; set; } = new List<Rol>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<Turn> Turns { get; set; } = new List<Turn>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
