using System.Text;
using Com.XinGang.Common;
using Com.XinGang.Model;
using Repository.DAL.Repository;
using Repository.Domain;
using Repository.Domain.Infrastructure;
/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：ControllerBase
// 文件功能描述：
//
// 创建标识：xycui 2014/8/26 15:40:14
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Com.XinGang.Class
{
    public class ControllersBase:Controller
    {
        protected IUnitOfWork UnitOfWork;
        protected XinGangDbContext DbContext; 

        public ControllersBase()
        {
            DbContext = new XinGangDbContext();
            UnitOfWork = new UnitOfWork(DbContext);
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding)
        {
            return new CustomJsonResult { Data = data, ContentType = contentType, ContentEncoding = contentEncoding };
        }
        public new JsonResult Json(object data, JsonRequestBehavior jsonRequest)
        {
            return new CustomJsonResult { Data = data, JsonRequestBehavior = jsonRequest };
        }
        public new JsonResult Json(object data)
        {
            return new CustomJsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// 权限验证
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (null == CurrentUser)
            {
               filterContext.Result=RedirectToAction("Login","Account");
            }
        }

        /// <summary>
        /// 当前用户信息
        /// </summary>
        public User CurrentUser
        {
            get
            {
                return new CookieManage().ReadFromCookie(ConstHelper.UserCookie) as User;
            }
        }


    }
}