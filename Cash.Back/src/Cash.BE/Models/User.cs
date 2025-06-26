using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Cash.BE.Attributes;

namespace Cash.BE.Models;

public partial class User
{
    public int Id { get; set; }
    [AllowedFilter]
    public string? UserName { get; set; } = null!;
    [AllowedFilter]
    public string? Email { get; set; } = null!;

    public string? Password { get; set; } = null!;

    public int RolId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int CreatedBy { get; set; }
    [AllowedFilter]
    public int? UserApproval { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public int StatusId { get; set; }

    public virtual ICollection<Attention> AttentionCreatedByNavigations { get; set; } = new List<Attention>();

    public virtual ICollection<Attention> AttentionModifiedByNavigations { get; set; } = new List<Attention>();

    public virtual ICollection<AttentionType> AttentionTypeCreatedByNavigations { get; set; } = new List<AttentionType>();

    public virtual ICollection<AttentionType> AttentionTypeModifiedByNavigations { get; set; } = new List<AttentionType>();

    public virtual ICollection<Cash> CashCreatedByNavigations { get; set; } = new List<Cash>();

    public virtual ICollection<Cash> CashModifiedByNavigations { get; set; } = new List<Cash>();

    public virtual ICollection<Client> ClientCreatedByNavigations { get; set; } = new List<Client>();

    public virtual ICollection<Client> ClientModifiedByNavigations { get; set; } = new List<Client>();

    public virtual ICollection<Contract> ContractCreatedByNavigations { get; set; } = new List<Contract>();

    public virtual ICollection<Contract> ContractModifiedByNavigations { get; set; } = new List<Contract>();

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Device> DeviceCreatedByNavigations { get; set; } = new List<Device>();

    public virtual ICollection<Device> DeviceModifiedByNavigations { get; set; } = new List<Device>();

    public virtual ICollection<User> InverseCreatedByNavigation { get; set; } = new List<User>();

    public virtual ICollection<User> InverseUserApprovalNavigation { get; set; } = new List<User>();

    public virtual ICollection<Menu> MenuCreatedByNavigations { get; set; } = new List<Menu>();

    public virtual ICollection<Menu> MenuModifiedByNavigations { get; set; } = new List<Menu>();

    public virtual ICollection<MenuRol> MenuRolCreatedByNavigations { get; set; } = new List<MenuRol>();

    public virtual ICollection<MenuRol> MenuRolModifiedByNavigations { get; set; } = new List<MenuRol>();

    public virtual ICollection<MenuUser> MenuUserCreatedByNavigations { get; set; } = new List<MenuUser>();

    public virtual ICollection<MenuUser> MenuUserModifiedByNavigations { get; set; } = new List<MenuUser>();

    public virtual ICollection<MenuUser> MenuUserUsers { get; set; } = new List<MenuUser>();

    public virtual ICollection<MethodPayment> MethodPaymentCreatedByNavigations { get; set; } = new List<MethodPayment>();

    public virtual ICollection<MethodPayment> MethodPaymentModifiedByNavigations { get; set; } = new List<MethodPayment>();

    public virtual ICollection<Payment> PaymentCreatedByNavigations { get; set; } = new List<Payment>();

    public virtual ICollection<Payment> PaymentModifiedByNavigations { get; set; } = new List<Payment>();

    public virtual Rol Rol { get; set; } = null!;

    public virtual ICollection<Rol> RolCreatedByNavigations { get; set; } = new List<Rol>();

    public virtual ICollection<Rol> RolModifiedByNavigations { get; set; } = new List<Rol>();

    public virtual ICollection<Service> ServiceCreatedByNavigations { get; set; } = new List<Service>();

    public virtual ICollection<Service> ServiceModifiedByNavigations { get; set; } = new List<Service>();

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<Status> Statuses { get; set; } = new List<Status>();

    public virtual ICollection<Turn> TurnCreatedByNavigations { get; set; } = new List<Turn>();

    public virtual ICollection<Turn> TurnModifiedByNavigations { get; set; } = new List<Turn>();

    public virtual ICollection<Turn> TurnUserGestors { get; set; } = new List<Turn>();

    public virtual User? UserApprovalNavigation { get; set; }

    public virtual ICollection<Cash> Cashes { get; set; } = new List<Cash>();
}
