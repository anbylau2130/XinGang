﻿/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：ProductType
// 文件功能描述：
//
// 创建标识：xycui 2014/9/5 11:26:06
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.XinGang.Model.Model
{
    public class ProductType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TypeCode { get; set; }
        public List<Product> Products { get; set; }
    }
}
