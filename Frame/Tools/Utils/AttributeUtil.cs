using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Utils
{
    public static class AttributeUtil
    {
        static AttributeUtil() { }

        public static TValue GetPropertyValue<T, TOut, TAttribute, TValue>(
            Expression<Func<T, TOut>> propertyExpression, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
        {
            var expression = (MemberExpression)propertyExpression.Body;
            var propertyInfo = (PropertyInfo)expression.Member;

            return propertyInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() is TAttribute attr
                ? valueSelector(attr) : default;
        }
    }
}
