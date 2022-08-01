using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_NguyenHoangNam.Controllers
{
    public class ProductController : Controller
    {
        private NorthWindDataClassesDataContext da = new NorthWindDataClassesDataContext();
        
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductManagement()
        {
            var p = da.Products.Select(s => s).ToList();
            return View(p);
        }

        public ActionResult CreateProduct()
        {
            ViewData["SupplierDropDownList"] = new SelectList(da.Suppliers, "SupplierID", "CompanyName");
            ViewData["CategoryDropDownList"] = new SelectList(da.Categories, "CategoryID", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(FormCollection formCollection, Product product)
        {
            da.Products.InsertOnSubmit(product);
            da.SubmitChanges();
            return RedirectToAction("ProductManagement");
            //return this.CreateProduct();
        }

        public ActionResult ProductDetails(int id)
        {
            var p = da.Products.FirstOrDefault(productItem => productItem.ProductID == id);
            return View(p);
        }

        public ActionResult Delete(int id)
        {
            var p = da.Products.FirstOrDefault(productItem => productItem.ProductID == id);
            da.Products.DeleteOnSubmit(p);
            da.SubmitChanges();
            return RedirectToAction("ProductManagement");
        }

        public ActionResult Edit(int id)
        {
            var p = da.Products.FirstOrDefault(productItem => productItem.ProductID == id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection formCollection, Product product)
        {
            var p = da.Products.FirstOrDefault(productItem => productItem.ProductID == product.ProductID);
            p.ProductName = formCollection["ProductName"];
            p.UnitPrice = decimal.Parse(formCollection["UnitPrice"]);
            p.CategoryID = int.Parse(formCollection["SupplierID"]);
            p.SupplierID = int.Parse(formCollection["SupplierID"]);
            p.UnitsInStock = short.Parse(formCollection["UnitsInStock"]);
            p.QuantityPerUnit = formCollection["QuantityPerUnit"];

            UpdateModel(p);
            da.SubmitChanges();
            return RedirectToAction("ProductManagement");
            //return this.CreateProduct();
        }

    }
}