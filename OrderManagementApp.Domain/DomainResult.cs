using System.Collections.Generic;

namespace OrderManagementApp.Domain
{
    public class DomainResult<T>
         where T : class
    {
        private DomainResult(T result)
        {
            Result = result;
            IsSuccess = true;
        }

        private DomainResult(List<string> errorMessages)
        {
            _errorList = errorMessages;
            IsSuccess = false;
        }

        public static DomainResult<T> Ok(T result)
        {
            return new DomainResult<T>(result);
        }

        public static DomainResult<T> Fail(List<string> errorMessages)
        {
            return new DomainResult<T>(errorMessages);
        }
        public static DomainResult<T> Fail(string errorMessage)
        {
            return new DomainResult<T>(new List<string>
            {

            errorMessage
            });
        }

        public T Result { get; private set; }
        public bool IsSuccess { get; private set; }

        private List<string> _errorList { get; }
        public IReadOnlyCollection<string> ErrorList
        {
            get
            {
                return _errorList;
            }
        }
    }
}
