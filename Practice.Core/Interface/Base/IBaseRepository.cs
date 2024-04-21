namespace Practice.Core.Interface.Base
{
    public interface IBaseRepository<T>
    {
        public List<T> Query(string sqlQuery, Dictionary<string, object> param);
        public int Execute(string sqlQuery, Dictionary<string, object> param);
    }
}
