namespace SampleProduct.Domain.Entities;

public class Role : BaseAuditableEntity
{
    public string Name { get; set; }

    public string? Note { get; set; }
}
