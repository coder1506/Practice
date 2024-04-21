using Practice.Core.Attributes;
using Practice.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Core.Entities
{
    public class Account : BaseEntity
    {
        [NotDuplicate("Tài khoản đã tồn tại")]
        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Avatar { get; set; }
    }
}
