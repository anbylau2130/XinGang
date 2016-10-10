using Com.XinGang.Class;
using Com.XinGang.Common;
using Com.XinGang.Model.Model;
using Repository.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Com.XinGang.Controllers
{
    public class HomeBehindController : ControllersBase
    {
        private CompanyRepository companyRespository;
 
        public HomeBehindController()
        {
            companyRespository = new CompanyRepository(DbContext);
        }

        /// <summary>
        /// 后台主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (null != CurrentUser)
            {
                ViewBag.UserName = CurrentUser.UserName;
            }
            return View();
        }

        /// <summary>
        /// 公司介绍
        /// </summary>
        /// <returns></returns>
        public ActionResult CompanyProfile()
        {
            return View();
        }

         


        [HttpPost]
        public ActionResult GetCompanyProfile()
        {
            var company = companyRespository.GetCompanyInfo();
            if (null == company)
            {
                return Json("");
            }
            return Json(company);
        }


        [HttpPost]
        public ActionResult AddCompanyProfile(string profile)
        {
            if (companyRespository.AddCompanyProfile(profile) && UnitOfWork.Save() == 1)
            {
                return Content("{success:true}");
            }
            return Content("{success:false}");
        }


        [HttpPost]
        public ActionResult GetMenuItems()
        {
           return Content("{success:true,msg:"+new MenuXmlHelper(Server.MapPath(ConstHelper.MenuXmlPath)).GetJson(this)+"}");
        }
    }
}
