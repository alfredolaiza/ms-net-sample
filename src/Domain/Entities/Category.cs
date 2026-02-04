namespace backend_api.Domain.Entities;

public class Category : BaseAuditableEntity
{
    public string? Name { get; set; }

    public string? Description { get; set; }
}
