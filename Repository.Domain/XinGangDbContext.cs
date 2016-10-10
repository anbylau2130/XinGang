using Com.XinGang.Model;
using Com.XinGang.Model.Model;
/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：XinGangDbContext
// 文件功能描述：
//
// 创建标识：xycui 2014/8/26 14:28:02
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

namespace Repository.Domain
{
    public class XinGangDbContext:DbContext
    {
        public XinGangDbContext()
            : base("DefaultConnection")
       {
           Database.SetInitializer<XinGangDbContext>(null);
       } 
        public DbSet<User> Users { get; set; }
        public DbSet<Company> CompanyInfo { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Content> Contents { get; set; }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Page> Pages { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<ContentType> ContentTypes { get; set; }
    } 
}
