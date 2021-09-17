using System;

namespace OrderManagementApp.Domain.Orders.OrderDiscounts
{
    public class OrderDiscount : BaseOrder
    {
        public decimal Price { get; private set; }
        public static DomainResult<OrderDiscount> Create(Guid orderId,  decimal price)
        {
            if (orderId == Guid.Empty)
            {
                return DomainResult<OrderDiscount>.Fail(nameof(OrderDiscount.OrderId));
            }

            if (price <= decimal.Zero)
            {
                return DomainResult<OrderDiscount>.Fail(nameof(OrderDiscount.Price));
            }

            var orderDiscount = new OrderDiscount
            {
                OrderId = orderId,
                Price = price
            };

            return DomainResult<OrderDiscount>.Ok(orderDiscount);
        }
    }
}
