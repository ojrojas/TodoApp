using System.ComponentModel.DataAnnotations;

namespace TodoApp.BuildingBlocks.Entities;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
}
