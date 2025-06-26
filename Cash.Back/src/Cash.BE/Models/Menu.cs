using System;
using System.Collections.Generic;

namespace Cash.BE.Models;

public partial class Menu
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public string Path { get; set; } = null!;

    public int StatusId { get; set; }

    public int? PaternId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Menu> InversePatern { get; set; } = new List<Menu>();

    public virtual ICollection<MenuRol> MenuRols { get; set; } = new List<MenuRol>();

    public virtual ICollection<MenuUser> MenuUsers { get; set; } = new List<MenuUser>();

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual Menu? Patern { get; set; }

    public virtual Status Status { get; set; } = null!;
}
