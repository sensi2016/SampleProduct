namespace SampleProduct.Domain.Entities;

public class Order : BaseAuditableEntity
{
    public OrderStatus OrderStatus { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; }

    public User User { get; set; }
    public int UserId { get; set; }

}
