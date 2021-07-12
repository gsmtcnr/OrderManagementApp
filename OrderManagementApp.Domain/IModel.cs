using System;

namespace OrderManagementApp.Domain
{
    public interface IModel
    {
        Guid Id { get; set; }
        public DateTime CreatedDate { get; }
        public bool IsActive { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
