using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace aznews.Models;

[Table("tblPost")]
public partial class TblPost
{
    [Key]
    public long PostId { get; set; }

    public string? Title { get; set; }

    public string? Abstract { get; set; }

    public string? Contents { get; set; }

    public string? Images { get; set; }

    public string? Link { get; set; }

    public string? Author { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? IsActive { get; set; }

    public int? PostOrder { get; set; }

    public int? MenuId { get; set; }

}
