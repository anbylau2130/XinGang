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
    public class ContentController : ControllersBase
    {
        private ContentRepository contentRepository;

        public ContentController()
        {
            contentRepository=new ContentRepository(DbContext);
        }


        //
        // GET: /Content/
        public ActionResult ContentManager()
        {
            return View();
        }

        public ActionResult List()
        {
            var temp = contentRepository.Query(null).ToList();
            return Json(temp);
        }

        [HttpPost]
        public ActionResult Add(Content content)
        {
            content.CreateTime = DateTime.Now;
            content.UpdateTime = DateTime.Now;
            contentRepository.Insert(content);

            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
        [HttpPost]
        public ActionResult Update(Content content)
        {
            content.UpdateTime = DateTime.Now;
            contentRepository.Update(content);
            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
        [HttpPost]
        public ActionResult Delete(Content content)
        {
            contentRepository.Delete(content);
            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
    }
}
