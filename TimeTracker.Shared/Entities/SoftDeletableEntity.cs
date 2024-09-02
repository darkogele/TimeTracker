namespace TimeTracker.Shared.Entities;

public class SoftDeletableEntity : BaseEntity
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }
}