/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：IQueryableEx
// 文件功能描述：
//
// 创建标识：xycui 2014/8/29 14:17:21
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Domain.Infrastructure
{
    public static class IQueryableEx
    {

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, bool ascending)
            where T : class
        {
            Type type = typeof(T);

            PropertyInfo property = type.GetProperty(propertyName);

            if (property == null)
                throw new ArgumentException("propertyName", "Not Exist");

            ParameterExpression param = Expression.Parameter(type, "p");
            Expression propertyAccessExpression = Expression.MakeMemberAccess(param, property);
            LambdaExpression orderByExpression = Expression.Lambda(propertyAccessExpression, param);

            string methodName = ascending ? "OrderBy" : "OrderByDescending";

            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), methodName,
                                                             new Type[] { type, property.PropertyType }, source.Expression,
                                                             Expression.Quote(orderByExpression));

            return source.Provider.CreateQuery<T>(resultExp);
        }
    }
}
