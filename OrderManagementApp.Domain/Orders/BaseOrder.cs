using System;

namespace OrderManagementApp.Domain.Orders
{
    public class BaseOrder : BaseModel
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
