﻿/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：ContentRepository
// 文件功能描述：
//
// 创建标识：xycui 2014/9/1 11:07:15
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.XinGang.Model.Model;
using Repository.Domain;
using Repository.Domain.Infrastructure;

namespace Repository.DAL.Repository
{
   public  class ContentRepository :Repository<Content>
    {
       public ContentRepository(XinGangDbContext dbContext) : base(dbContext)
       {
       }

    }
}
