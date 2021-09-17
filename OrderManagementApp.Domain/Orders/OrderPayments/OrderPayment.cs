using OrderManagementApp.Domain.Orders.OrderPayments.Enums;
using System;

namespace OrderManagementApp.Domain.Orders.OrderPayments
{
    public class OrderPayment : BaseOrder
    {
        public string PaymentType { get; private set; }
        public decimal Price { get; private set; }

        public static DomainResult<OrderPayment> Create(Guid orderId, PaymentType paymentType, decimal price)
        {
            if (orderId == Guid.Empty)
            {
                return DomainResult<OrderPayment>.Fail(nameof(OrderPayment.OrderId));
            }

            if (paymentType == Enums.PaymentType.None)
            {
                return DomainResult<OrderPayment>.Fail(nameof(OrderPayment.PaymentType));
            }

            if (price <= decimal.Zero)
            {
                return DomainResult<OrderPayment>.Fail(nameof(OrderPayment.Price));
            }

            var orderPayment = new OrderPayment
            {
                OrderId = orderId,
                PaymentType = paymentType.ToString(),
                Price = price
            };

            return DomainResult<OrderPayment>.Ok(orderPayment);
        }
    }
}
