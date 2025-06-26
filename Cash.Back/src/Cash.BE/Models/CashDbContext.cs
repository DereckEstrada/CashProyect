using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cash.BE.Models;

public partial class CashDbContext : DbContext
{
    public CashDbContext()
    {
    }

    public CashDbContext(DbContextOptions<CashDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Attention> Attentions { get; set; }

    public virtual DbSet<AttentionType> AttentionTypes { get; set; }

    public virtual DbSet<Cash> Cashes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<MenuUser> MenuUsers { get; set; }

    public virtual DbSet<MethodPayment> MethodPayments { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Turn> Turns { get; set; }

    public virtual DbSet<User> Users { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum("status_entityType_enum", new[] { "USER", "CONTRACT", "ATTENTION", "CONFIGURATION" });

        modelBuilder.Entity<Attention>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("attention_pkey");

            entity.ToTable("attention");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("clientId");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedDate");
            entity.Property(e => e.StatusId).HasColumnName("statusId");
            entity.Property(e => e.TurnId).HasColumnName("turnId");
            entity.Property(e => e.TypeId).HasColumnName("typeId");

            entity.HasOne(d => d.Client).WithMany(p => p.Attentions)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("attention_clientId_fkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AttentionCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("attention_createdBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.AttentionModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("attention_modifiedBy_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Attentions)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("attention_statusId_fkey");

            entity.HasOne(d => d.Turn).WithMany(p => p.Attentions)
                .HasForeignKey(d => d.TurnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("attention_turnId_fkey");

            entity.HasOne(d => d.Type).WithMany(p => p.Attentions)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("attention_typeId_fkey");
        });

        modelBuilder.Entity<AttentionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("attentionType_pkey");

            entity.ToTable("attentionType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedDate");
            entity.Property(e => e.StatusId).HasColumnName("statusId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AttentionTypeCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("attentionType_createdBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.AttentionTypeModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("attentionType_modifiedBy_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.AttentionTypes)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("attentionType_statusId_fkey");
        });

        modelBuilder.Entity<Cash>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cash_pkey");

            entity.ToTable("cash");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedDate");
            entity.Property(e => e.StatusId).HasColumnName("statusId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CashCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cash_createdBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.CashModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("cash_modifiedBy_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Cashes)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cash_statusId_fkey");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_pkey");

            entity.ToTable("client");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .HasColumnName("address");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Identification)
                .HasMaxLength(14)
                .HasColumnName("identification");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("lastName");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedDate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(13)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.ReferencesAddress)
                .HasMaxLength(150)
                .HasColumnName("referencesAddress");
            entity.Property(e => e.StatusId).HasColumnName("statusId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ClientCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_createdBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ClientModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("client_modifiedBy_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Clients)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_statusId_fkey");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contract_pkey");

            entity.ToTable("contract");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("clientId");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.EndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("endDate");
            entity.Property(e => e.MethodPaymentId).HasColumnName("methodPaymentId");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedDate");
            entity.Property(e => e.ServiceId).HasColumnName("serviceId");
            entity.Property(e => e.StartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("startDate");
            entity.Property(e => e.StatusId).HasColumnName("statusId");

            entity.HasOne(d => d.Client).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contract_clientId_fkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ContractCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contract_createdBy_fkey");

            entity.HasOne(d => d.MethodPayment).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.MethodPaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contract_methodPaymentId_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ContractModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("contract_modifiedBy_fkey");

            entity.HasOne(d => d.Service).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contract_serviceId_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contract_statusId_fkey");
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("device_pkey");

            entity.ToTable("device");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedDate");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.ServiceId).HasColumnName("serviceId");
            entity.Property(e => e.StatusId).HasColumnName("statusId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.DeviceCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("device_createdBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.DeviceModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("device_modifiedBy_fkey");

            entity.HasOne(d => d.Service).WithMany(p => p.Devices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("device_serviceId_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Devices)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("device_statusId_fkey");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("menu_pkey");

            entity.ToTable("menu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .HasColumnName("icon");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedDate");
            entity.Property(e => e.PaternId).HasColumnName("paternId");
            entity.Property(e => e.Path)
                .HasMaxLength(150)
                .HasColumnName("path");
            entity.Property(e => e.StatusId).HasColumnName("statusId");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MenuCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menu_createdBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.MenuModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("menu_modifiedBy_fkey");

            entity.HasOne(d => d.Patern).WithMany(p => p.InversePatern)
                .HasForeignKey(d => d.PaternId)
                .HasConstraintName("menu_paternId_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Menus)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menu_statusId_fkey");
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => new { e.MenuId, e.RolId }).HasName("menuRol_pkey");

            entity.ToTable("menuRol");

            entity.Property(e => e.MenuId).HasColumnName("menuId");
            entity.Property(e => e.RolId).HasColumnName("rolId");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedDate");
            entity.Property(e => e.StatusId).HasColumnName("statusId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MenuRolCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menuRol_createdBy_fkey");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menuRol_menuId_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.MenuRolModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("menuRol_modifiedBy_fkey");

            entity.HasOne(d => d.Rol).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menuRol_rolId_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menuRol_statusId_fkey");
        });

        modelBuilder.Entity<MenuUser>(entity =>
        {
            entity.HasKey(e => new { e.MenuId, e.UserId }).HasName("menuUser_pkey");

            entity.ToTable("menuUser");

            entity.Property(e => e.MenuId).HasColumnName("menuId");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedDate");
            entity.Property(e => e.StatusId).HasColumnName("statusId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MenuUserCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menuUser_createdBy_fkey");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuUsers)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menuUser_menuId_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.MenuUserModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("menuUser_modifiedBy_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.MenuUsers)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menuUser_statusId_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.MenuUserUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menuUser_userId_fkey");
        });

        modelBuilder.Entity<MethodPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("methodPayment_pkey");

            entity.ToTable("methodPayment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedDate");
            entity.Property(e => e.StatusId).HasColumnName("statusId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MethodPaymentCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("methodPayment_createdBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.MethodPaymentModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("methodPayment_modifiedBy_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.MethodPayments)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("methodPayment_statusId_fkey");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payment_pkey");

            entity.ToTable("payment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("clientId");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedDate");
            entity.Property(e => e.StatusId).HasColumnName("statusId");

            entity.HasOne(d => d.Client).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_clientId_fkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PaymentCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_createdBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.PaymentModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("payment_modifiedBy_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Payments)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_statusId_fkey");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rol_pkey");

            entity.ToTable("rol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedDate");
            entity.Property(e => e.StatusId).HasColumnName("statusId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RolCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rol_createdBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.RolModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("rol_modifiedBy_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Rols)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rol_statusId_fkey");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("service_pkey");

            entity.ToTable("service");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedDate");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(18, 2)
                .HasColumnName("price");
            entity.Property(e => e.StatusId).HasColumnName("statusId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ServiceCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("service_createdBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ServiceModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("service_modifiedBy_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Services)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("service_statusId_fkey");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_pkey");

            entity.ToTable("status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedDate");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.Statuses)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("status_modifiedBy_fkey");
        });

        modelBuilder.Entity<Turn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("turn_pkey");

            entity.ToTable("turn");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CashId).HasColumnName("cashId");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedDate");
            entity.Property(e => e.StatusId).HasColumnName("statusId");
            entity.Property(e => e.UserGestorId).HasColumnName("userGestorId");

            entity.HasOne(d => d.Cash).WithMany(p => p.Turns)
                .HasForeignKey(d => d.CashId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("turn_cashId_fkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TurnCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("turn_createdBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.TurnModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("turn_modifiedBy_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Turns)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("turn_statusId_fkey");

            entity.HasOne(d => d.UserGestor).WithMany(p => p.TurnUserGestors)
                .HasForeignKey(d => d.UserGestorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("turn_userGestorId_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprovalDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("approvalDate");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.RolId).HasColumnName("rolId");
            entity.Property(e => e.StatusId).HasColumnName("statusId");
            entity.Property(e => e.UserApproval).HasColumnName("userApproval");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("userName");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_createdBy_fkey");

            entity.HasOne(d => d.Rol).WithMany(p => p.Users)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_rolId_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_statusId_fkey");

            entity.HasOne(d => d.UserApprovalNavigation).WithMany(p => p.InverseUserApprovalNavigation)
                .HasForeignKey(d => d.UserApproval)
                .HasConstraintName("user_userApproval_fkey");

            entity.HasMany(d => d.Cashes).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserCash",
                    r => r.HasOne<Cash>().WithMany()
                        .HasForeignKey("CashId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("userCash_cashId_fkey"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("userCash_userId_fkey"),
                    j =>
                    {
                        j.HasKey("UserId", "CashId").HasName("userCash_pkey");
                        j.ToTable("userCash");
                        j.IndexerProperty<int>("UserId").HasColumnName("userId");
                        j.IndexerProperty<int>("CashId").HasColumnName("cashId");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
