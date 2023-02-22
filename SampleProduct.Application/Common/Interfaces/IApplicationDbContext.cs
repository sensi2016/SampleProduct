using Microsoft.EntityFrameworkCore;
using SampleProduct.Domain.Entities;

namespace SampleProduct.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Order> Order { get; }
    public DbSet<OrderDetail> OrderDetail { get; }
    public DbSet<Product> Product { get; }
    public DbSet<User> User { get; }
    public DbSet<UserRole> UserRole { get; }
    public DbSet<Role> Role { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
