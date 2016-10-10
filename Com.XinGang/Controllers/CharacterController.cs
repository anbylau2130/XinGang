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
    public class CharacterController : ControllersBase
    {
        private CharacterRepository characterRepository;

        public CharacterController()
        {
            characterRepository = new CharacterRepository(DbContext);
        }
        //
        // GET: /Character/

        public ActionResult CharacterManager()
        { 
            return View();
        }
        public ActionResult List()
        {
            var temp = characterRepository.Query(null).ToList();
            return Json(temp);
        }

        [HttpPost]
        public ActionResult Add(Character character)
        {
            character.CreateTime = DateTime.Now;
            character.UpdateTime = DateTime.Now;
            characterRepository.Insert(character);

            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
        [HttpPost]
        public ActionResult Update(Character character)
        {
            character.UpdateTime = DateTime.Now;
            characterRepository.Update(character);
            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
        [HttpPost]
        public ActionResult Delete(Character content)
        {
            characterRepository.Delete(content);
            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }

    }
}
