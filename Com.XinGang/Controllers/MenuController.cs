using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.XinGang.Class;
using Com.XinGang.Model.Model;
using Repository.DAL.Repository;

namespace Com.XinGang.Controllers
{
    public class MenuController : ControllersBase
    {
        private MenuRepository menuRepository;
        public MenuController()
        {
            menuRepository = new MenuRepository(DbContext);
        }
        //
        // GET: /MenuManager/
        public ActionResult MenuManager()
        {
            return View(); 
        }


        public ActionResult List()
        {
            var temp = menuRepository.Query(null).ToList();
            return Json(temp);
        }

        [HttpPost]
        public ActionResult Add(Menu menu)
        {

            menuRepository.Insert(menu);

            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
        [HttpPost]
        public ActionResult Update(Menu menu)
        {
            menuRepository.Update(menu);
            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
        [HttpPost]
        public ActionResult Delete(Menu menu)
        {
            menuRepository.Delete(menu);
            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
    }
}
