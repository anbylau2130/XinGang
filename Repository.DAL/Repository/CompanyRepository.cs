using Com.XinGang.Model.Model;
using Repository.Domain;
using Repository.Domain.Infrastructure;
/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：CompanyRepository
// 文件功能描述：
//
// 创建标识：xycui 2014/8/28 15:47:57
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAL.Repository
{
    public class CompanyRepository :Repository<Company>
    {
        public CompanyRepository(XinGangDbContext dbcontext)
            : base(dbcontext)
        { 

        }

        public Company GetCompanyInfo()
        { 
            return dbContext.CompanyInfo.ToList().FirstOrDefault();
        }
        

        public bool AddCompanyProfile(string profile)
        {
            if (string.IsNullOrEmpty(profile))
            {
                return false;
            }

            if (dbContext.CompanyInfo.Count() <= 0)
            {
                 base.Insert(new Company()
                {
                    Profile = profile,
                    UpdateTime = DateTime.Now
                });
            }
            else
            {
                Company com = GetCompanyInfo();
                com.Profile = profile;
                com.UpdateTime = DateTime.Now;
                Update(com);
            }
            return true;
        }
    }
}
