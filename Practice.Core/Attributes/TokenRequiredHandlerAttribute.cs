using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Practice.Core.Model;
using System.Net;
using System.Resources;
using System.Web.Http.Results;

namespace Practice.Core.Attributes
{
    public class TokenRequiredHandlerAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(context != null && context.HttpContext != null && context.HttpContext.Request != null && !string.IsNullOrEmpty(context.HttpContext.Request.Headers["Authorization"].ToString()))
            {
                var token = context.HttpContext.Request.Headers["Authorization"].ToString();
                if (IsValidToken(token))
                {

                }
                else
                {
                    HandleInvalidToken(context);
                }
            }
        }

        private bool IsValidToken(string token) {
            return true;
        }

        private void HandleInvalidToken(AuthorizationFilterContext context)
        {
            if(context == null)
            {
                return;
            }

            context.HttpContext.Response.Headers.Add("AuthStatus", "NotAuthorized");
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            context.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Not Authorized";

            context.Result = new JsonResult("NotAuthorized")
            {
                Value = new ServiceResult
                {
                    Success = false,
                    ErrorCode = 401,
                    DevMsg = "NotAuthorized",
                    UserMsg = "Bạn không có quyền truy cập vào tài nguyên này!"
                },
            };
        }
    }
}
