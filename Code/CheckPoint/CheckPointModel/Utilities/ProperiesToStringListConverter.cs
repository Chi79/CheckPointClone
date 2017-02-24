using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CheckPointModel.Utilities
{
    public static class ProperiesToStringListConverter<T> where T : class
    { 
        public static List<string> ConvertPropertiesToStringList(T entity)
        {
            List<string> propertyList = new List<string>();
        
            foreach (PropertyInfo property in entity.GetType().GetProperties())
            {
                bool propertyIsAStringOrInt = property.PropertyType == typeof(string) || property.PropertyType == typeof(int);
                if (propertyIsAStringOrInt)
                {
                    propertyList.Add(property.GetValue(entity).ToString());
                }
            }
            return propertyList;
        }
    }
}
