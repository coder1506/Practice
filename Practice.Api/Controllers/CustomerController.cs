using Microsoft.AspNetCore.Mvc;
using Practice.Api.Controllers.Base;
using Practice.Core.Entities;
using Practice.Core.Interface.Base;

namespace Practice.Api.Controllers
{
    [ApiController]
    [Route("v1/customers")]
    public class CustomerController : BaseController<Customer>
    {
        public CustomerController(IBaseService<Customer> baseService) : base(baseService)
        {

        }
    }
}
