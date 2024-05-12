namespace Sughd.Auto.Domain.Abstract;

public abstract class EntityBase
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddMinutes(300);

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.AddMinutes(300);
    
    public DateTime DeletedAt { get; set; } = DateTime.UtcNow.AddMinutes(300);
}