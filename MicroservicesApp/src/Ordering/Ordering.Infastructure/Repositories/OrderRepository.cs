using IntegrationEventLogEF.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;
using Ordering.Infastructure.Data;
using Ordering.Infastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext, Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory) : base(dbContext, integrationEventLogServiceFactory)
        {

        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders.Where(o => o.UserName == userName).ToListAsync();
            return orderList;
        }
    }
}
