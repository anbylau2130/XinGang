using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.XinGang.Class;
using Com.XinGang.Model.Model;
using Newtonsoft.Json;
using Repository.DAL.Repository;

namespace Com.XinGang.Controllers
{
    public class MenuContentController : ControllersBase
    {
        private MenuRepository menuRepository;
        private ContentRepository contentRepository;
        private PageRepository pageRepository;
        private ContentTypeRepository contentTypeRepository;
        public MenuContentController()
        {
            menuRepository = new MenuRepository(DbContext);
            contentRepository = new ContentRepository(DbContext);
            pageRepository=new PageRepository(DbContext);
            contentTypeRepository = new ContentTypeRepository(DbContext);
        }

        //
        // GET: /MenuContent/

        public ActionResult MenuContentManager() 
        {
            return View();
        }

        public ActionResult TreeNodeJson()
        {
            //Response.ContentType = "application/json";
            List<Page> pages = pageRepository.Query(null).ToList();
            List<ExtTreeNode> nodeList = new List<ExtTreeNode>();
            ;
            if (pages.Count() <= 0)
            {
                return null;
            }
            foreach (var page in pages)
            {
                ExtTreeNode node = new ExtTreeNode()
                                       {
                                           id = page.ID.ToString(),
                                           text = page.PageName,
                                           leaf = false,
                                           type = "page"
                                       };
                List<Menu> menus = menuRepository.Query(menu => menu.PageID == page.ID).ToList();
                foreach (var menu in menus)
                {
                    ExtTreeNode subtreenode = new ExtTreeNode()
                                                  {
                                                      id = menu.ID.ToString(),
                                                      text = menu.Text,
                                                      leaf = true,
                                                      type = "menu"
                                                  };

                    node.children.Add(subtreenode);
                }
                nodeList.Add(node);
            }
            return Json(nodeList);

//            return Content(@"[{
//    text: 'To Do', 
//    cls: 'folder',
//    children: [{
//        text: 'Go jogging',
//        leaf: true,
//        checked: false
//    },{
//        text: 'Take a nap',
//        leaf: true,
//        checked: false
//    },{
//        text: 'Climb Everest',
//        leaf: true,
//        checked: false
//    }]
//},{
//    text: 'Grocery List',
//    cls: 'folder',
//    children: [{
//        text: 'Bananas',
//        leaf: true,
//        checked: false
//    },{
//        text: 'Milk',
//        leaf: true,
//        checked: false
//    },{
//        text: 'Cereal',
//        leaf: true,
//        checked: false
//    },{
//        text: 'Energy foods',
//        cls: 'folder',
//        children: [{
//            text: 'Coffee',
//            leaf: true,
//            checked: false
//        },{
//            text: 'Red Bull',
//            leaf: true,
//            checked: false
//        }]
//    }]
//},{
//    text: 'Remodel Project', 
//    cls: 'folder',
//    children: [{
//        text: 'Finish the budget',
//        leaf: true,
//        checked: false
//    },{
//        text: 'Call contractors',
//        leaf: true,
//        checked: false
//    },{
//        text: 'Choose design',
//        leaf: true,
//        checked: false
//    }]
//}]");
          
        }

           

        public ActionResult ContentTypeCombobox()
        {
            List<ContentType> contentTypes = contentTypeRepository.Query(null).ToList();
                return Json(contentTypes);
        }

       

        public ActionResult PageCombobox()
        {
            List<Page> pages = pageRepository.Query(null).ToList();
            return Json(pages);
        }
    }
}
