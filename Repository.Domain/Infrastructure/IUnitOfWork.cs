/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：IUnitOfWork
// 文件功能描述：
//
// 创建标识：xycui 2014/8/26 14:32:44
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Domain.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        int Save();
        bool IsDisposed { get; }
    }
}
