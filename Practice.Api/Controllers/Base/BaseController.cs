using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practice.Core.Attributes;
using Practice.Core.Interface.Base;
using Practice.Core.Model;
using Practice.Core.Util;

namespace Practice.Api.Controllers.Base
{
    [TokenRequired]
    [ApiController]
    public class BaseController<T> : Controller
    {
        IBaseService<T> _baseService;

        public BaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public ServiceResult Get()
        {
            var result = new ServiceResult();
            try
            {
                result = _baseService.GetAll();
            }
            catch (Exception ex)
            {
                HandleUtil.HandleException(ex, result);
            }

            return result;
        }
        [HttpPost]
        public ServiceResult Add(T item)
        {
            var result = new ServiceResult();
            try
            {
                result = _baseService.Add(item);
            }
            catch (Exception ex)
            {
                HandleUtil.HandleException(ex, result);
            }

            return result;
        }
    }
}
