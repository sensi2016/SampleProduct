namespace SampleProduct.Domain.Entities;

public class Product : BaseAuditableEntity
{

    public string Name { get; set; }

    public string Note { get; set; }
    public string Image { get; set; }

    public Price Price { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; } 
}
