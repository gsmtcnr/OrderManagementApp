using OrderManagementApp.Domain.Users.UserAddresses;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagementApp.Domain.Users
{
    public class User
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public IReadOnlyCollection<UserAddress> UserAddresses => _userAddresses.ToList();
        private ICollection<UserAddress> _userAddresses { get; set; }

        public static DomainResult<User> Create(string name, string surname)
        {
           
            if (!string.IsNullOrEmpty(name))
            {
                return DomainResult<User>.Fail(nameof(User.Name));
            }

            if (!string.IsNullOrEmpty(surname))
            {
                return DomainResult<User>.Fail(nameof(User.Surname));
            }

            var user = new User
            {
                Name = name,
                Surname = surname
            };

            return DomainResult<User>.Ok(user);
        }
        public void AddAddress(UserAddress userAddress)
        {
            _userAddresses.Add(userAddress);
        }
    }
}
