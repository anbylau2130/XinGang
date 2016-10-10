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
    public class ContentTypeController : ControllersBase
    {
           private ContentTypeRepository contentTypeRepository;

           public ContentTypeController()
        {
            contentTypeRepository=new ContentTypeRepository(DbContext);
        }


        //
        // GET: /Content/
        public ActionResult ContentTypeManager()
        {
            return View();
        }

        public ActionResult List()
        {
            var temp = contentTypeRepository.Query(null).ToList();
            return Json(temp);
        }

        [HttpPost]
        public ActionResult Add(ContentType contentType)
        {

            contentTypeRepository.Insert(contentType);

            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
        [HttpPost]
        public ActionResult Update(ContentType contentType)
        {

            contentTypeRepository.Update(contentType);
            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
        [HttpPost]
        public ActionResult Delete(ContentType contentType)
        {
            contentTypeRepository.Delete(contentType);
            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
    }
}
