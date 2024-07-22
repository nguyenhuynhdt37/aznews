using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aznews.Models;

[Table("tblMenu")]
public partial class TblMenu
{
    [Key]
    public int MenuId { get; set; }

    public string MenuName { get; set; } = null!;

    public bool IsActive { get; set; }

    public string? ControllerName { get; set; }

    public string? ActionName { get; set; }

    public int? Levels { get; set; }

    public int? ParentId { get; set; }

    public string? Link { get; set; }

    public int? MenuOrder { get; set; }

    public int? Position { get; set; }
}
