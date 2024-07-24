using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace aznews.Areas.Admin.Models
{
    [Table("AdminMenu")]
    public class AdminMenu
    {
        [Key]
        public int AdminMenuID { set; get; }
        public string? ItemName { set; get; }
        public int? ItemLevel { set; get; }
        public int? ParentLevel { set; get; }
        public int? ItemOrder { set; get; }
        public bool? IsActive { set; get; }
        public string? ItemTarget { set; get; }
        public string? AreaName { set; get; }
        public string? ActionName { set; get; }
        public string? Icon { set; get; }
        public string? IdName { set; get; }
    }
}