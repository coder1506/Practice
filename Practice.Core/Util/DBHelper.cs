using System.Collections;
using System.Data;

namespace Practice.Core.Util
{
    public class DBHelper
    {
        public static IList MapReaderToData(Type type, IList result, IDataReader dataReader)
        {

            if (dataReader == null)
            {
                return result;
            }

            var properties = type.GetProperties();
            while (dataReader.Read())
            {
                var item = Activator.CreateInstance(type);
                for (int i = 0; i < properties.Length; i++)
                {
                    var property = properties[i];
                    if (property != null && dataReader[property.Name] != null && !string.IsNullOrEmpty(dataReader[property.Name].ToString()))
                    {
                        item?.GetType().GetProperty(property.Name)?.SetValue(item, dataReader[property.Name]);
                    }
                }

                result.Add(item);
            }
            return result;
        }
    }
}
