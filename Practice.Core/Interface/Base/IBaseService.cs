using Practice.Core.Model;

namespace Practice.Core.Interface.Base
{
    public interface IBaseService<T>
    {
        public ServiceResult GetAll();
        public ServiceResult Add(T item);
    }
}
