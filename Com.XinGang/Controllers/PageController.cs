using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.XinGang.Class;
using Com.XinGang.Model.Model;
using Repository.DAL.Repository;

namespace Com.XinGang.Controllers
{
    public class PageController : ControllersBase
    {
        //
        // GET: /Page/


          private PageRepository pagerRepository;

          public PageController()
        {
            pagerRepository = new PageRepository(DbContext);
        }
        //
        // GET: /Character/

        public ActionResult PageManager()
        { 
            return View();
        }
        public ActionResult List()
        {
            var temp = pagerRepository.Query(null).ToList();
            return Json(temp);
        }

        [HttpPost]
        public ActionResult Add(Page page)
        {

            pagerRepository.Insert(page);

            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
        [HttpPost]
        public ActionResult Update(Page page)
        {
            pagerRepository.Update(page);
            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
        [HttpPost]
        public ActionResult Delete(Page page)
        {
            pagerRepository.Delete(page);
            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }

    }
}
