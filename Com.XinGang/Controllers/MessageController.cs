using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.XinGang.Class;
using Com.XinGang.Model.Model;
using Repository.DAL.Repository;
using Repository.Domain;

namespace Com.XinGang.Controllers
{
    public class MessageController : ControllersBase
    {
        private MessageRepository messageRepository;
        public MessageController()
        {
            messageRepository = new MessageRepository(DbContext);
        }


        // GET: /Message/
        public ActionResult MessageManager()
        {
            return View();
        }
        

        public ActionResult List()
        {
            var temp = messageRepository.Query(u => u.InUse == true).ToList();
            return Json(temp);
        }

        [HttpPost]
        public ActionResult Add(Message msg)
        {
            msg.CreateTime = DateTime.Now;
            msg.UpdateTime = DateTime.Now;
            messageRepository.Insert(msg);

            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
        [HttpPost]
        public ActionResult Update(Message msg)
        {
            msg.UpdateTime = DateTime.Now;
            messageRepository.Update(msg);
            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
        [HttpPost]
        public ActionResult Delete(Message msg)
        {
            messageRepository.Delete(msg);
            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }


    }
}
