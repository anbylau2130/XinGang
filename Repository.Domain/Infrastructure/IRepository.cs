/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：IRepository
// 文件功能描述：
//
// 创建标识：xycui 2014/8/26 14:30:37
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Domain.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IList<TEntity> List();

        IQueryable<TEntity> QueryByPage(Expression<Func<TEntity, bool>> FunWhere,
                                               Expression<Func<TEntity, string>> FunOrder,
                                    int PageSize, int PageIndex, out int recordsCount);
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter);
       
        
    }
}
