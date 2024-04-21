using Practice.Core.Entities;
using Practice.Core.Interface.Base;
using Practice.Core.Interface.Service;
using Practice.Core.Services.Base;
using Practice.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Core.Services
{
    public class AccountService : BaseService<Account>, IAccountService
    {
        public AccountService(IBaseRepository<Account> baseRepository) : base(baseRepository)
        {
        }
        public override void BeforeAdd(Account item) {
            if (!string.IsNullOrEmpty(item.Password)){
                item.Password = MD5Util.EnCode(item.Password);
            }
        }
    }
}
