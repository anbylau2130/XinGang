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
    public class ProductController : ControllersBase
    {
        private ProductRepository productRepository;
        private ProductTypeRepository productTypeRepository;
        public ProductController()
        {
            productRepository = new ProductRepository(DbContext);
              productTypeRepository=new ProductTypeRepository(DbContext);
        }
        //
        // GET: /Product/
        public ActionResult ProductManager()
        {
            return View();
        }


      

        #region List
        public ActionResult ProductList()
        {
            var temp = productRepository.Query(null).ToList();
            return Json(temp);
        }

        public ActionResult ProductTypeList()
        {
            var temp = productTypeRepository.Query(null).ToList();
            return Json(temp);
        }
        #endregion
        #region Add
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            productRepository.Insert(product);

            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
        [HttpPost]
        public ActionResult AddProductType(ProductType  productType)
        {
            productTypeRepository.Insert(productType);

            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
        #endregion
        #region Update
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            productRepository.Update(product);
            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
        [HttpPost]
        public ActionResult UpdateProductType(ProductType productType)
        {
            productTypeRepository.Update(productType);
            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
        #endregion
        #region Delete
        [HttpPost]
        public ActionResult DeleteProduct(Product product)
        {
            productRepository.Delete(product);
            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
        [HttpPost]
        public ActionResult DeleteProductType(ProductType productType)
        {
            productTypeRepository.Delete(productType);
            if (UnitOfWork.Save() != 1)
            {
                return Content("{success:false}");
            }

            return Content("{success:true}");
        }
        #endregion


        public ActionResult TreeNodeJson()
        {
            List<ProductType> productTypes = productTypeRepository.Query(null).ToList();
            List<ExtTreeNode> nodeList = new List<ExtTreeNode>();
            
            if (productTypes.Count() <= 0)
            {
                return null;
            }
         
            foreach (var type in productTypes)
            {
                nodeList.Add(new ExtTreeNode()
                {
                    id = type.ID.ToString(),
                    text = type.Name,
                    leaf = true,
                    type=type.TypeCode
                });
            }
          
            return Json(nodeList);
        }
    }
}
