using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI_V1.Controllers
{
    public class ProductCatagoryManagerController : Controller
    {
        ProductCatagoryRepository context;
        public ProductCatagoryManagerController()
        {
            context = new ProductCatagoryRepository();

        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductCatagory> productCatagory = context.Collection().ToList();
            return View(productCatagory);
        }

        public ActionResult Create()
        {
            ProductCatagory productCatagory = new ProductCatagory();
            return View(productCatagory);
        }
        [HttpPost]
        public ActionResult Create(ProductCatagory productCatagory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCatagory);
            }
            else
            {
                context.Insert(productCatagory);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ProductCatagory productCatagory = context.Find(Id);
            if (productCatagory == null)
                return HttpNotFound();
            else
            {
                return View(productCatagory);
            }
        }
        [HttpPost]
        public ActionResult Edit(ProductCatagory productCatagory, string Id)
        {
            ProductCatagory productCatagoryToEdit = context.Find(Id);
            if (productCatagoryToEdit == null)
                return HttpNotFound();
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCatagory);
                }
                productCatagoryToEdit.Catagory = productCatagory.Catagory;


                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            ProductCatagory productCatagoryToDelete = context.Find(Id);
            if (productCatagoryToDelete == null)
                return HttpNotFound();
            else
            {
                return View(productCatagoryToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCatagory productCatagoryToDelete = context.Find(Id);
            if (productCatagoryToDelete == null)
                return HttpNotFound();
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}