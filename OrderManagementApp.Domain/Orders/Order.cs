using OrderManagementApp.Domain.Orders.OrderDetails;
using OrderManagementApp.Domain.Orders.OrderDiscounts;
using OrderManagementApp.Domain.Orders.OrderPayments;
using OrderManagementApp.Domain.Users;
using OrderManagementApp.Domain.Users.UserAddresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementApp.Domain.Orders
{
    public class Order : BaseModel
    {
        #region Relations
        public User User { get; private set; }
        public Guid UserId { get; private set; }
        #endregion

        #region Collections
        public IReadOnlyCollection<OrderDetail> OrderDetails => _orderDetails.ToList();
        private ICollection<OrderDetail> _orderDetails { get; set; }

        public IReadOnlyCollection<OrderPayment> OrderPayments => _orderPayments.ToList();
        private ICollection<OrderPayment> _orderPayments { get; set; }

        public IReadOnlyCollection<OrderDiscount> OrderDiscounts => _orderDiscounts.ToList();
        private ICollection<OrderDiscount> _orderDiscounts { get; set; }
        #endregion

        #region Properties
        public string Name { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }
        public string AddressText { get; private set; }

        #region ReadOnly
        public decimal SubTotal
        {
            get
            {
                return OrderDetails.Where(s => s.IsDeleted == false && s.IsActive).Sum(s => s.ProductPrice);
            }
        }

        public decimal TotalDiscount
        {
            get
            {
                return OrderDiscounts.Where(s => s.IsDeleted == false && s.IsActive).Sum(s => s.Price);
            }
        }
        public decimal TotalPayment
        {
            get
            {
                return OrderPayments.Where(s => s.IsDeleted == false && s.IsActive).Sum(s => s.Price);
            }
        }
        public decimal RemainingPrice
        {
            get
            {
                return SubTotal - (TotalPayment + TotalDiscount);
            }
        }
        #endregion

        #endregion

        #region Methods
        public void SetAddress(UserAddress userAddress)
        {
            Name = userAddress.Name;
            Country = userAddress.Country;
            City = userAddress.City;
            AddressText = userAddress.AddressText;
        }

        public void AddDetail(OrderDetail orderDetail)
        {
            _orderDetails.Add(orderDetail);
        }

        public void AddPayment(OrderPayment orderPayment)
        {
            _orderPayments.Add(orderPayment);
        }
        public void AddDiscount(OrderDiscount orderDiscount)
        {
            _orderDiscounts.Add(orderDiscount);
        }
        #endregion
    }
}
