using Com.XinGang.Class;
using Com.XinGang.Common;
using Com.XinGang.Model;
using Repository.DAL.Repository;
using Repository.Domain;
using Repository.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Com.XinGang.Controllers
{
    public class AccountController : Controller
    {
        VolidateImage image = new VolidateImage(25, 60, Color.White, Color.Red, "", 12, 0, 0);

        private UserRepository userRepository;

        private string randCode;

        public AccountController()
        {
            userRepository = new UserRepository(new XinGangDbContext());
        }

        /// <summary>
        /// 登陆视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            var user= new CookieManage().ReadFromCookie(ConstHelper.UserCookie) as User;
            if (user != null)
            {
                return RedirectToAction("Index", "HomeBehind");
            }
            return View();
        }

        /// <summary>
        /// 注销登陆
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Logout()
        {
            //var user = new CookieManage().ReadFromCookie(ConstHelper.UserCookie) as User;
            new CookieManage().WriteCookie(ConstHelper.UserCookie, "",0);
            return Content("OK");
        }

        /// <summary>
        /// 登陆方法，用于验证用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult OnLogin(string username, string password,string randCode)
        {
            User user = new User() { UserName=username,PassWord=password};

            if (new CookieManage().ReadCookie(ConstHelper.UserValidateCode) != randCode)
            {
                return Content("{success:false,msg:'验证码错误'}");
            }

            if (user.UserName.IsNullOrEmpty() || user.PassWord.IsNullOrEmpty())
            {
                return Content("{success:false,msg:'用户名密码不能为空'}");
            }

            if (null != userRepository.GetUserByUserName(user.UserName, user.PassWord))
            {
                new CookieManage().WriteObject2Cookie(ConstHelper.UserCookie, user, 1);
                return Content("{success:true}");
            }
            else
            {
                return Content("{success:false,msg:'账号或密码不匹配'}");
            }
            
        }

        /// <summary>
        /// 验证码图片
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidationImage()
        {
            var randCode = image.CreateShowString();
            new CookieManage().WriteCookie(ConstHelper.UserValidateCode, randCode,1);
            MemoryStream ms = new MemoryStream();
            image.CreateImage(randCode).Save(ms, ImageFormat.Jpeg);
            return File(ms.ToArray(), "image/jpep");
        }

    }
}
