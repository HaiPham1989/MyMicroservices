using EventBus.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Commands;
using Ordering.Application.Mapper;
using Ordering.Application.Responses;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;
using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Handlers
{
    public class CheckoutOrderHandler : IRequestHandler<CheckoutOrderCommand, OrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<CheckoutOrderHandler> _logger;

        public CheckoutOrderHandler(IOrderRepository orderRepository, ILogger<CheckoutOrderHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _logger = logger;
        }

        public async Task<OrderResponse> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = OrderMapper.Mapper.Map<Order>(request);
            if (orderEntity == null)
            {
                throw new ApplicationException("not mapped");
            }

            var evt = new IntegrationEvent();
            var newOrder = await _orderRepository.AddAsync(orderEntity, evt);

            var orderResponse = OrderMapper.Mapper.Map<OrderResponse>(newOrder);
            return orderResponse;
        }
    }
}
