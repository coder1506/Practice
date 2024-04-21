using Microsoft.AspNetCore.Mvc;
using Practice.Api.Controllers.Base;
using Practice.Core.Entities;
using Practice.Core.Interface.Base;
using Practice.Core.Interface.Service;
using Practice.Core.Model;
using Practice.Core.Services.Base;
using Practice.Core.Util;

namespace Practice.Api.Controllers
{
    [ApiController]
    [Route("v1/Accounts")]
    public class AccountController : BaseController<Account>
    {
        public AccountController(IAccountService accountService) : base(accountService)
        {
        }
    }
}
