using System;

namespace OrderManagementApp.Domain
{
    public abstract class BaseModel : IModel
    {
        protected BaseModel()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; private set; }
        public bool IsActive { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
