using System;

namespace OrderManagementApp.Domain.Orders.OrderDetails
{
    public class OrderDetail : BaseOrder
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; private set; }

        public static DomainResult<OrderDetail> Create(Guid orderId, string productName, decimal productPrice)
        {
            if (orderId == Guid.Empty)
            {
                return DomainResult<OrderDetail>.Fail(nameof(OrderDetail.OrderId));
            }

            if (productPrice <= decimal.Zero)
            {
                return DomainResult<OrderDetail>.Fail(nameof(OrderDetail.ProductPrice));
            }

            if (!string.IsNullOrEmpty(productName))
            {
                return DomainResult<OrderDetail>.Fail(nameof(OrderDetail.ProductName));
            }

            var orderDetail = new OrderDetail
            {
                OrderId = orderId,
                ProductPrice = productPrice,
                ProductName = productName
            };

            return DomainResult<OrderDetail>.Ok(orderDetail);
        }
    }
}
