using Practice.Core.Entities.Base;
using Practice.Core.Interface.Base;
using Practice.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Xml.Linq;

namespace Practice.Core.Services.Base
{
    public class BaseService<T> : IBaseService<T>
        where T : BaseEntity
    {
        private IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #region add
        public ServiceResult Add(T item)
        {
            var result = new ServiceResult();
            handleAddCommon(item);
            BeforeAdd(item);
            var validateData = ValidateAddData(item);
            if (!string.IsNullOrEmpty(validateData))
            {
                var sql = BuildSqlAdd(item);
                var param = BuildParamAdd(item);
                result.Data = _baseRepository.Execute(sql, param) > 0;
                AfterAdd(item);
            }
            else
            {
                result.Data = false;
                result.UserMsg = validateData;
            }
            return result;
        }
        private string ValidateAddData(T item) {
            return "";
        }
        private void handleAddCommon(T item) {
            item.ID = Guid.NewGuid();
            item.CreatedDate = DateTime.Now;
            item.UpdatedDate = DateTime.Now;
        }
        public virtual void BeforeAdd(T item) { }
        public virtual void AfterAdd(T item) { }
        private string BuildSqlAdd(T item) {
            var type = typeof(T);
            var name = type.Name;
            var result = "insert into {0}({1}) values ({2})";
            var columnsAdd = new List<string>();
            var properties = type.GetProperties();
            foreach(var property in properties)
            {
                var propertyName = property.Name;
                if (IsAllowAdd(property))
                {
                    columnsAdd.Add(propertyName);
                }
            }
            result = string.Format(result, name, string.Join(", ", columnsAdd), string.Join(", ", columnsAdd.Select(_ => "@" + _)));
            return result;
        }
        private bool IsAllowAdd(PropertyInfo property) {
            if (property != null)
            {
                var attributes = property.GetCustomAttribute(typeof(NotMappedAttribute), true);
                if(attributes != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        private Dictionary<string, object> BuildParamAdd(T item) {
            var type = typeof(T);
            var properties = type.GetProperties();
            var result = new Dictionary<string, object>();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var value = property.GetValue(item, null);
                if (IsAllowAdd(property))
                {
                    result.Add("@" + propertyName, value);
                }
            }
            return result; 
        }
        #endregion
        #region get
        public ServiceResult GetAll()
        {
            var result = new ServiceResult();
            var sql = $"select * from {typeof(T).Name}";
            result.Data = _baseRepository.Query(sql, new Dictionary<string, object>() { });
            return result;
        }
        #endregion

    }
}
