using Practice.Core.Entities;
using Practice.Core.Interface.Base;
using Practice.Core.Interface.Service;
using Practice.Core.Services.Base;

namespace Practice.Core.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerSerivce
    {
        public CustomerService(IBaseRepository<Customer> baseRepository) : base(baseRepository)
        {
        }
    }
}
