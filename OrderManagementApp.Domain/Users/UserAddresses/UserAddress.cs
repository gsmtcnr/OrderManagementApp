using System;

namespace OrderManagementApp.Domain.Users.UserAddresses
{
    public class UserAddress : BaseModel
    {
        public User User { get; private set; }
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }
        public string AddressText { get; private set; }

        public static DomainResult<UserAddress> Create(Guid userId, string name, string country, string city, string addresssText)
        {
            if (userId == Guid.Empty)
            {
                return DomainResult<UserAddress>.Fail(nameof(UserAddress.UserId));
            }

            if (!string.IsNullOrEmpty(name))
            {
                return DomainResult<UserAddress>.Fail(nameof(UserAddress.Name));
            }

            if (!string.IsNullOrEmpty(country))
            {
                return DomainResult<UserAddress>.Fail(nameof(UserAddress.Country));
            }

            if (!string.IsNullOrEmpty(city))
            {
                return DomainResult<UserAddress>.Fail(nameof(UserAddress.City));
            }

            if (!string.IsNullOrEmpty(addresssText))
            {
                return DomainResult<UserAddress>.Fail(nameof(UserAddress.AddressText));
            }

            UserAddress userAddress = new UserAddress
            {
                UserId = userId,
                AddressText = addresssText,
                Name = name,
                City = city,
                Country = country
            };

            return DomainResult<UserAddress>.Ok(userAddress);
        }
    }
}
