using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Practice.Core.Attributes
{
    public class TokenRequiredAttribute : TypeFilterAttribute
    {
        public TokenRequiredAttribute() : base(typeof(TokenRequiredHandlerAttribute))
        {
        }
    }
}
