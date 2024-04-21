using Microsoft.Extensions.Configuration;
using Practice.Core.Entities;
using Practice.Core.Interface.Base;
using Practice.Core.Interface.Repository;

namespace Practice.Repo.Repo
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
