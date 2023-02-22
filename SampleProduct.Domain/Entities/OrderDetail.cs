namespace SampleProduct.Domain.Entities;

public class OrderDetail : BaseAuditableEntity
{
    public int Quantity { get; set; }
    public int Discount { get; set; }

    public Order Order { get; set; }
    public int OrderId { get; set; }
    public Price Price { get; set; }

    public Product Product { get; set; }
    public int ProductId { get; set; }
}
