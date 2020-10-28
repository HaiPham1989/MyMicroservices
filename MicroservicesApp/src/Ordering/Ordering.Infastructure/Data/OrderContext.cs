using Microsoft.EntityFrameworkCore;
using Ordering.Core.Entities;

namespace Ordering.Infastructure.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
