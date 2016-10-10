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
    public class HomeController : HomeControllerBase
    {
        private CharacterRepository characterRepository;
        private MenuRepository menuRepository;
        private ContentRepository contentRepository;
        private ProductTypeRepository productTypeRepository;
        private ProductRepository productRepository;
        private ContentTypeRepository contentTypeRepository;
        public HomeController()
        {
            characterRepository = new CharacterRepository(DbContext);
            menuRepository=new MenuRepository(DbContext);
            contentRepository=new ContentRepository(DbContext);
            productTypeRepository=new ProductTypeRepository(DbContext);
            productRepository = new ProductRepository(DbContext);
            contentTypeRepository=new ContentTypeRepository(DbContext);
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Template(string PageName,string ID)
        {

            var contenttype= contentTypeRepository.Query(p => p.Menu.Text == PageName).FirstOrDefault();
            ViewData["ID"] = ID;
            return View(contenttype);
        }

        public ActionResult BusinessScope()
        {
            return View(); 
        }

        public ActionResult Offers()
        {

            return View();
        }

        public ActionResult Honours()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }

        public ActionResult PartialMenu(string PageCode)
        {
            var menus = menuRepository.Query(menu => menu.Page.PageCode == PageCode).ToList();
            return View(menus);
        }

        public ActionResult PartialProductList(string id)
        {
            ViewData["id"] = id;
            var producttypes = productTypeRepository.Query(null).ToList();
            return View(producttypes);
        }
        
        //无格式的文本模板
        public ActionResult PartialContent(string PageName, string PageTitle)
        { 
            var characters = characterRepository.Query(p => p.CharacterType.Equals(PageName)).ToList();
            ViewData["PageTitle"] = PageTitle;
            ViewData["PageName"] = PageName;
            return View(characters);
        }

        //文本索引页，包含文本内容显示
        public ActionResult PartialMenuList(string PageName, string PageTitle,string MenuID,string MenuName)
        {
            var menus = menuRepository.Query(menu => menu.Page.PageCode == PageName).ToList();
            var contents = contentRepository.Query(content => content.Menu.Page.PageName == PageName).ToList();
            ViewData["PageTitle"] = PageTitle;
            ViewData["PageName"] = PageName;
            ViewData["MenuID"] = menus.FirstOrDefault().ID;
            ViewData["MenuName"] = menus.FirstOrDefault().Text;
            return View(menus);
        }

        //文章模板内容页
        public ActionResult PartialCharacter(string PageName,string PageTitle,string id)
        { 
            var characters = characterRepository.Query(p => p.CharacterType.Equals(PageName)).ToList();
            ViewData["PageTitle"] = PageTitle;
            ViewData["PageName"] = PageName;
            if (string.IsNullOrEmpty(id))
            {
                var firstOrDefault = characters.FirstOrDefault();
                if (firstOrDefault != null) 
                    ViewData["id"] = firstOrDefault.ID;
            }
            else
            {
                  ViewData["id"] = id;
            }
            return View(characters);
        }
        

        [HttpPost]
        public ActionResult GetCharacter(string id)
        {
            int ID;
            Character character=null;
            if (int.TryParse(id, out ID))
            {
                character = characterRepository.Query(p => p.ID == ID).FirstOrDefault();

            }
            if (ID==0)
            {
                character = characterRepository.Query(null).FirstOrDefault();
            }
            return Json(character);
        }

        [HttpPost]
        public ActionResult GetProduct(string id)
        {
            int ID;
            List<Product> product = null;
            if (int.TryParse(id, out ID))
            {
                product = productRepository.Query(p => p.ProductType.ID == ID).ToList();

            }
            else
            {
                var firstOrDefault = productTypeRepository.Query(null).FirstOrDefault();
                if (firstOrDefault != null)
                {
                      ID = firstOrDefault.ID; 
                     product = productRepository.Query(p => p.ProductType.ID == ID).ToList();
                }
                  
            }
            return Json(product);
        }


        [HttpPost]
        public ActionResult GetProductType(string id) 
        {
            int ID;
            ProductType producttype = null; 
            if (int.TryParse(id, out ID))
            {
                producttype = productTypeRepository.Query(p => p.ID == ID).FirstOrDefault();

            }
            if (ID == 0)
            {
                producttype = productTypeRepository.Query(null).FirstOrDefault();
            }
            return Json(producttype);
        }

        [HttpPost]
        public ActionResult GetContentPager(string menuid,int pagesize,int pageindex)
        {
            int ID;
            var allcount = 0;
            List<Content> contents=new List<Content>();
            if (int.TryParse(menuid, out ID))
            {
                 contents = contentRepository.QueryByPage(p => p.Menu.ID == ID, p => p.CreateTime.ToString(), pagesize, pageindex, out allcount).ToList();
            }

            return Json(new { totalcount = allcount, content = contents });
        }
       
        [HttpPost]
        public ActionResult GetMenu(string menuid)
        { 
            int ID; 
            Menu menu = null;
            if (int.TryParse(menuid, out ID))
            {
                menu = menuRepository.Query(m => m.ID == ID).FirstOrDefault();
            }
            if (ID == 0)
            {
                menu = menuRepository.Query(null).FirstOrDefault();
            }
            return Json(menu);
        }

        [HttpPost]
        public ActionResult GetContent(string contentid)
        { 
            int ID;
            Content content = null;
            if (int.TryParse(contentid, out ID))
            {
                content = contentRepository.Query(c => c.ID == ID).FirstOrDefault();
            }
            if (ID == 0)
            {
                content = contentRepository.Query(null).FirstOrDefault();
            }
            return Json(content);
        }
    }
}
